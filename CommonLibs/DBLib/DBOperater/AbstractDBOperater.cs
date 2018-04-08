using MySql.Data.MySqlClient;

namespace DBLib
{
    public delegate void DBCallback(object msg);
    public class AbstractDBOperater
    {

        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected DBCallback m_callback;
        protected object m_result;
        public string ErrorText;
        protected MySqlDataReader reader;

        internal void Init(DBManager db_manager)
        {
            dbManager = db_manager;
            conn = new MySqlConnection(dbManager.ConnStr);
            cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandTimeout = 0;
            try
            {
                conn.Open();
                dbManager.ReconnectInfo.Reset();
            }
            catch (Exception e)
            {
                dbManager.AddExceptionLog(e.ToString());
                dbManager.ReconnectInfo.NeedReconnect = true;
            }
        }

        public void OnCall(DBCallback callback)
        {
            m_callback = callback;
        }

        public void PostUpdate()
        {
            if (m_callback != null)
                m_callback(m_result);
        }

        abstract public bool Execute();

        public string ErrorLogText(Exception exception)
        {
            string logText = string.Empty;

            if (cmd != null)
            {
                logText = "CommandText: " + cmd.CommandText + "\r\n";
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    var item = cmd.Parameters[i];
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
            return cmd.ToString();
        }
    }
}
