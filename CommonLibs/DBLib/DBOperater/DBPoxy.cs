using LogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib
{
    public enum DBOperateType
    {
        Write = 1,
        Read = 2
    }

    public enum DBTableParamType
    {
        Character = 1,
    }
    public struct DBProxyDefault
    {
        public const string DefaultTableName = "Role";
        public const DBOperateType DefaultOperateType = DBOperateType.Write;
        public const int TableBaseCount = 20;
    }

    public class DBProxy
    {

        // key db nick name
        public Dictionary<string, DBWorkPool> DBNameList = new Dictionary<string, DBWorkPool>();
        // key tableName, value DBManagerPool
        public Dictionary<string, DBWorkPool> WriteTableList = new Dictionary<string, DBWorkPool>();
        public Dictionary<string, DBWorkPool> ReadTableList = new Dictionary<string, DBWorkPool>();

        public void AddTableDb(string table_name, DBWorkPool db, DBOperateType operate_type)
        {
            switch (operate_type)
            {
                case DBOperateType.Write:
                    WriteTableList.Add(table_name, db);
                    break;
                case DBOperateType.Read:
                    ReadTableList.Add(table_name, db);
                    break;
                default:
                    Console.WriteLine("add table db failed: got invalid opetate type {0}", operate_type);
                    break;
            }
        }

        public void AddNameDb(string nick_name, DBWorkPool db)
        {
            DBNameList.Add(nick_name, db);
        }

        public DBWorkPool GetDbByName(string nick_name)
        {
            DBWorkPool db = null;
            DBNameList.TryGetValue(nick_name, out db);
            return db;
        }

        public DBWorkPool GetWriteDbByName(string table_name)
        {
            DBWorkPool db = null;
            WriteTableList.TryGetValue(table_name, out db);
            return db;
        }

        public DBWorkPool GetReadDbByName(string table_name)
        {
            DBWorkPool db = null;
            ReadTableList.TryGetValue(table_name, out db);
            return db;
        }

        public DBWorkPool GetDbByTable(string table_name, DBOperateType type)
        {
            DBWorkPool db = null;
            switch (type)
            {
                case DBOperateType.Write:
                    WriteTableList.TryGetValue(table_name, out db);
                    break;
                case DBOperateType.Read:
                    ReadTableList.TryGetValue(table_name, out db);
                    break;
                default:
                    break;
            }
            return db;
        }

        public void Abort()
        {
            foreach (var db in DBNameList)
            {
                try
                {
                    db.Value.Abort();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public bool Exit()
        {
            foreach (var db in DBNameList)
            {
                try
                {
                    db.Value.Exit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
            return true;
        }

        public void Call(AbstractDBOperater query, string table_name = DBProxyDefault.DefaultTableName, DBOperateType type = DBProxyDefault.DefaultOperateType, DBCallback callback = null)
        {
            DBWorkPool dbPool = GetDbByTable(table_name, type);
            if (dbPool == null)
            {
                Log.Error("db call {0} failed: can not find table {1} type {2} db", query.GetCmd(), table_name, type.ToString());
                return;
            }
            dbPool.Call(query, callback);
        }

        public void Call(AbstractDBOperater query, int index, string table_name = DBProxyDefault.DefaultTableName, DBOperateType type = DBProxyDefault.DefaultOperateType, DBCallback callback = null)
        {
            DBWorkPool dbPool = GetDbByTable(table_name, type);
            if (dbPool == null)
            {
                Log.Error("db call {0} failed: can not find table {1} type {2} db", query.GetCmd(), table_name, type.ToString());
                return;
            }
            dbPool.Call(query, index, callback);
        }

        public string GetTableName(string table_name, int param, DBTableParamType type)
        {
            switch (type)
            {
                case DBTableParamType.Character:
                    int suffix = param % DBProxyDefault.TableBaseCount;
                    if (suffix >= 10)
                    {
                        table_name = string.Format("{0}_{1}", table_name, suffix.ToString());
                    }
                    else
                    {
                        table_name = string.Format("{0}_0{1}", table_name, suffix.ToString());
                    }
                    break;
                default:
                    Log.Warn("get table name failed: invalid db table param type {0}", type);
                    break;
            }
            return table_name;
        }

    }
}
