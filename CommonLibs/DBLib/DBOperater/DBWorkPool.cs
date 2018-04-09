using LogLib;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DBLib
{
    public class DBWorkPool
    {
        private int _poolCount = 0;
        private int _index = 0;

        private List<DBManager> _dbManagerList = new List<DBManager>();
        public List<DBManager> DBManagerList
        { get { return _dbManagerList; } }

        private List<Thread> _dbThreadList = new List<Thread>();
        public Dictionary<int, int> DBCallCountList = new Dictionary<int, int>();
        public Dictionary<string, int> DBCallNameList = new Dictionary<string, int>();

        private string _ip;
        private string _dbName;
        private string _dbAccount;
        private string _password;
        private string _port;

        public DBWorkPool(int count)
        {
            _poolCount = count;
            for (int i = 0; i < _poolCount; i++)
            {
                DBManager db = new DBManager();
                _dbManagerList.Add(db);
                DBCallCountList.Add(i, 0);
            }
        }

        public bool Init(string ip, string database, string id, string pw, string port)
        {
            this._ip = ip;
            _dbName = database;
            _dbAccount = id;
            _password = pw;
            this._port = port;
            foreach (var db in _dbManagerList)
            {
                if (db.Init(ip, database, id, pw, port) == false)
                {
                    return false;
                }
                Thread dbThread = new System.Threading.Thread(db.Run);
                _dbThreadList.Add(dbThread);
                dbThread.Start();
            }
            return true;
        }

        public int Call(AbstractDBOperater query, DBCallback callback = null)
        {
            int dbIndex = GetDBIndex();
            _dbManagerList[dbIndex].Call(query, callback);
            return dbIndex;
        }

        public int Call(AbstractDBOperater query, int force_index, DBCallback callback = null)
        {
            int dbIndex = 0;
            if (force_index > 0 && force_index < _dbManagerList.Count)
            {
                _dbManagerList[force_index].Call(query, callback);
                DBCallCountList[force_index]++;
            }
            else
            {
                _dbManagerList[0].Call(query, callback);
                DBCallCountList[0]++;
            }
            if (DBCallNameList.ContainsKey(query.ToString()) == false)
            {
                DBCallNameList.Add(query.ToString(), 1);
            }
            else
            {
                DBCallNameList[query.ToString()]++;
            }
            return dbIndex;
        }

        public int GetNextDBIndex()
        {
            return ((_index + 1) % DBManagerList.Count);
        }

        public int GetDBIndex()
        {
            _index++;
            if (_index >= 10000)
            {
                _index = 0;
            }
            return _index % _dbManagerList.Count;
        }

        public void Abort()
        {
            foreach (var thread in _dbThreadList)
            {
                thread.Abort();
            }
            _dbThreadList.Clear();
        }

        public bool Exit()
        {
            foreach (var db in _dbManagerList)
            {
                try
                {
                    db.Exit();
                }
                catch (MySqlException e)
                {
                    Log.Error(e.ToString());
                    return false;
                }
            }
            return true;
        }

        public DBManager GetOneDBManager()
        {
            int curIndex = GetDBIndex();
            return _dbManagerList[curIndex];
        }
    }

}