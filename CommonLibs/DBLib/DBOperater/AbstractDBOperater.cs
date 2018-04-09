using MySql.Data.MySqlClient;
using System;

namespace DBLib
{
    public delegate void DBCallback(object msg);
    public abstract class  AbstractDBOperater
    {
        DBManager _dBManager;
        protected MySqlConnection m_Conn;
        protected MySqlCommand m_Cmd;
        protected DBCallback m_Callback;
        protected object m_Result;
        public string ErrorText;
        protected MySqlDataReader m_Reader;

        internal void Init(DBManager db_manager)
        {
            _dBManager = db_manager;
            m_Conn = new MySqlConnection(_dBManager.ConnStr);
            m_Cmd = m_Conn.CreateCommand();
            m_Cmd.Connection = m_Conn;
            m_Cmd.CommandTimeout = 0;
            try
            {
                m_Conn.Open();
                _dBManager.ReconnectInfo.Reset();
            }
            catch (Exception e)
            {
                _dBManager.AddExceptionLog(e.ToString());
                _dBManager.ReconnectInfo.NeedReconnect = true;
            }
        }

        public void OnCall(DBCallback callback)
        {
            m_Callback = callback;
        }

        public void PostUpdate()
        {
            if (m_Callback != null)
                m_Callback(m_Result);
        }

        abstract public bool Execute();

        public string ErrorLogText(Exception exception)
        {
            string logText = string.Empty;

            if (m_Cmd != null)
            {
                logText = "CommandText: " + m_Cmd.CommandText + "\r\n";
                for (int i = 0; i < m_Cmd.Parameters.Count; i++)
                {
                    var item = m_Cmd.Parameters[i];
                    if (item.Value == null)
                    {
                        logText += string.Format("{0}: null; ", item.ParameterName);
                    }
                    else
                    {
                        logText += string.Format("{0}: {1}; ", item.ParameterName, item.Value);
                    }

                }
            }
            else
            {
                logText = "MySqlCommand is null \r\n";
            }
            logText += "\r\n";
            logText += "ERROR" + exception.ToString();
            return logText;
        }

        public string GetCmd()
        {
            return m_Cmd.ToString();
        }
    }
}
