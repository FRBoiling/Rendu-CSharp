using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using UtilityLib;

namespace DBLib
{
    public class DBManager
    {
        private Queue<AbstractDBOperater> _saveQueue;
        private Queue<AbstractDBOperater> _executionQueue = new Queue<AbstractDBOperater>();
        private Queue<AbstractDBOperater> _postUpdateQueue = new Queue<AbstractDBOperater>();
        private Queue<string> _exceptionLogQueue = new Queue<string>();
        public bool Opened = false;

        private string _ip;
        private string _database;
        private string _username;
        private string _password;
        private string _port;
        public string ConnStr = string.Empty;

        public ReconnectRecord ReconnectInfo;


        public bool Init(string ip, string database, string id, string pw, string port)
        {

            this._ip = ip;
            this._database = database;
            this._username = id;
            this._password = pw;
            this._port = port;
            ConnStr = string.Format("data source={0}; database={1}; user id={2}; password={3}; port={4}",
                ip, database, id, pw, port);

            Opened = true;

            // 重连等待时间 60ss
            ReconnectInfo = new ReconnectRecord();
            ReconnectInfo.Init(60 * 1000);
            _saveQueue = new Queue<AbstractDBOperater>();
            _postUpdateQueue = new Queue<AbstractDBOperater>();

            return true;
        }

        //public bool IsDisconneted()
        //{
        //    return (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken);
        //}

        public bool Exit()
        {
            Opened = false;
            return true;
        }

        public void Add(AbstractDBOperater query)
        {
            query.Init(this);
            lock (_saveQueue)
            {
                _saveQueue.Enqueue(query);
            }
        }

        public void Call(AbstractDBOperater query, DBCallback callback = null)
        {
            query.OnCall(callback);
            Add(query);
        }

        // Asynchronous
        double _lasttime;
        double _totaltime;

        public void Run()
        {
            var tempPostUpdateQueue = new Queue<AbstractDBOperater>();
            var time = new TimeUtil();
            time.Init();
            while (true)
            {
                var dt = time.Update();
                _lasttime = dt.TotalMilliseconds;

                if (_lasttime > 1)
                {
                }
                else
                {
                    Thread.Sleep(1);
                }

                if (_totaltime > 10000)
                {
                    _totaltime = 0;
                }
                else
                {
                    _totaltime += _lasttime;
                }
                lock (ReconnectInfo)
                {
                    if (ReconnectInfo.NeedReconnect)
                    {
                        Opened = false;
                        string log = String.Format("disconnect from db {0}, esplased {1} ms", _database, ReconnectInfo.TryConnectTime);
                        AddExceptionLog(log);

                        ReconnectInfo.TryConnectTime += _lasttime;
                        MySqlConnection conn = new MySqlConnection(ConnStr);
                        try
                        {
                            conn.Open();
                            Opened = true;
                            ReconnectInfo.Reset();
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine(e.ToString());
                            AddExceptionLog(e.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    else
                    {
                        try
                        {
                            lock (_saveQueue)
                            {
                                if (_saveQueue.Count == 0)
                                {
                                    continue;
                                }
                                while (_saveQueue.Count > 0)
                                {
                                    AbstractDBOperater query = _saveQueue.Dequeue();
                                    _executionQueue.Enqueue(query);
                                }
                            }

                            while (_executionQueue.Count != 0)
                            {
                                var query = _executionQueue.Dequeue();
                                bool success = query.Execute();
                                if (success == false)
                                {
                                    if (query.ErrorText != null)
                                    {
                                        AddExceptionLog(query.ErrorText);
                                    }
                                    tempPostUpdateQueue.Enqueue(query);
                                }
                                else
                                {
                                    tempPostUpdateQueue.Enqueue(query);
                                }
                            }

                            lock (_postUpdateQueue)
                            {
                                while (tempPostUpdateQueue.Count != 0)
                                {
                                    _postUpdateQueue.Enqueue(tempPostUpdateQueue.Dequeue());
                                }
                            }

                            tempPostUpdateQueue.Clear();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
        }

        public Queue<AbstractDBOperater> GetPostUpdateQueue()
        {
            Queue<AbstractDBOperater> ret = new Queue<AbstractDBOperater>();
            lock (_postUpdateQueue)
            {
                while (_postUpdateQueue.Count > 0)
                {
                    AbstractDBOperater query = _postUpdateQueue.Dequeue();
                    ret.Enqueue(query);
                }
            }
            return ret;
        }

        public Queue<string> GetExceptionLogQueue()
        {
            Queue<string> ret;
            lock (_exceptionLogQueue)
            {
                if (_exceptionLogQueue.Count != 0)
                {
                    ret = _exceptionLogQueue;
                    _exceptionLogQueue = new Queue<string>();
                }
                else
                {
                    return null;
                }
            }
            return ret;
        }

        public void AddExceptionLog(string log)
        {
            lock (_exceptionLogQueue)
            {
                _exceptionLogQueue.Enqueue(log);
            }
        }

        public MySqlConnection GetOneConnection()
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            return conn;
        }
    }
}
