using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.DBModel
{
    public class DBOperateTestSelect : AbstractDBOperater
    {
        override public bool Execute()
        {
            m_Cmd.CommandText = "SELECT NOW();";
            m_Cmd.CommandType = System.Data.CommandType.Text;
            m_Result = 1;
            try
            {
                m_Reader = m_Cmd.ExecuteReader();

            }
            catch (Exception e)
            {
                m_Result = null;
                ErrorText = ErrorLogText(e);
                return false;
            }
            finally
            {
                if (m_Reader != null)
                {
                    m_Reader.Close();
                }
                m_Conn.Close();
            }
            return true;
        }
    }

    public class DBOperateTestInsert : AbstractDBOperater
    {
        int id;

        public DBOperateTestInsert(int id)
        {
            this.id = id;
        }

        override public bool Execute()
        {
            m_Cmd.CommandText = @"INSERT INTO Test id VALUES(@id); ";
            m_Cmd.CommandType = System.Data.CommandType.Text;

            m_Cmd.Parameters.AddWithValue("@id", id);

            m_Result = 1;
            try
            {
                m_Result = m_Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                m_Result = null;
                ErrorText = ErrorLogText(e);
                return false;
            }
            finally
            {
                m_Conn.Close();
            }
            return true;
        }
    }
}
