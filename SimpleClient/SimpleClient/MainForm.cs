using ApiLib;
using AssemblyLib;
using ClientLib;
using DataParserLib;
using GenerateCodeLib;
using LogLib;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLib;

namespace SimpleClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitLog();
            InitXml();
            InitApi();
        }

        IApi mApi;
        string curProtocolMsgName = "";
        string protocolMsgDllName = "ClientProtocol.dll";
        AssemblyResult mAssemblyResult;
        object curMsg;

        public void InitXml()
        {
            string[] files = Directory.GetFiles(@"..\Data\Xml", "*.xml", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                XmlDataManager.Inst.Parse(file);
            }
        }

        public void InitLog()
        {
            var logger = new WinFormLogger(this, true);
            logger.Init(true, @"..\Log\", "Client");
#if DEBUG
            logger.SetPriority(4);
#else
            logger.SetPriority(2);
#endif
            Log.InitLog(logger);
        }

        Thread workThread;
        public void InitApi()
        {
            Data data = XmlDataManager.Inst.GetData("GateList", 1);
            string ip = data.GetString("GateIp");
            ushort port = data.GetUInt16("GatePort");

            //mApi = new Api();
            mApi = new AssemblyApi();
            try
            {
                mApi.Init(ip, port);
                mApi.ReConnect();
            }
            catch (Exception e)
            {
                Log.Error("init failed:{0}", e.ToString());
                mApi.Exit();
                return;
            }

            workThread = new Thread(ThreadMethod);
            workThread.Start();


            Log.Info("client is ready...");
        }

        bool IsWorking = true;
        bool IsClosed = false;
        void ThreadMethod()
        {
            IsWorking = true;

            while (IsWorking)
            {
                mApi.Process();
            }
            mApi.Exit();

            Log.Info("client is exit...");
        }


        private bool LoadProtocol()
        {
            string code = ParseCode.AssemblyParseDll(protocolMsgDllName, out mAssemblyResult);

            //string soure = /*PathExt.workPath + @"\ClientLib\";*/";
            string sourePath = @"..\..\Libs\ClientLib\";
            string str1 = sourePath + @"GateServer.cs";
            string str2 = sourePath + @"GateServer_Code.cs";
            string str3 = sourePath + @"GateServer_Login_Requset.cs";
            string str4 = sourePath + @"GateServer_Login_Response.cs";
            string str5 = sourePath + @"HostInfo.cs";

            string[] files = new string[] { str1, str2, str3, str4, str5 };

            CompilerResults result = ParseCode.DebugRun(files, "ClientLib.dll");
            if (result.Errors.HasErrors)
            {
                Log.Write("编译错误");
                foreach (CompilerError err in result.Errors)
                {
                    Log.Error(err.ErrorText);
                }
                return false;
            }
            else
            {
                Log.Write("编译成功");
                return true;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            var height = Height;
            var width = Width;
            MinimumSize = new Size(width, height);
            MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, height);

            AssemblyHandler handler = new AssemblyHandler();

            mAssemblyResult = handler.GetClassName(protocolMsgDllName);
            foreach (var item in mAssemblyResult.ClassTypeList)
            {
                if (item.Key.Contains("Message") && item.Key.Contains("MSG_C2G"))
                {
                    comboBox_ProtocolName.Items.Add(item.Value.Name);
                }
            }
        }

        public void WinFormLog(string log, Color color)
        {
            if (textBox_MainShow.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                 {
                     textBox_MainShow.AppendText(x.ToString());
                     textBox_MainShow.AppendText(Environment.NewLine);
                     textBox_MainShow.ScrollToCaret();
                 };
                textBox_MainShow.Invoke(actionDelegate, log);
            }
            else
            {
                textBox_MainShow.AppendText(log);
                textBox_MainShow.AppendText(Environment.NewLine);
                textBox_MainShow.ScrollToCaret();
            }
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }


        public void WinFormLog(string log)
        {
            if (textBox_MainShow.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {
                    textBox_MainShow.AppendText(x.ToString());
                    textBox_MainShow.AppendText(Environment.NewLine);
                    textBox_MainShow.ScrollToCaret();
                };
                textBox_MainShow.Invoke(actionDelegate, log);
            }
            else
            {
                textBox_MainShow.AppendText(log);
                textBox_MainShow.AppendText(Environment.NewLine);
                textBox_MainShow.ScrollToCaret();
            }
        }


        private void button_LoadProtocol_Click(object sender, EventArgs e)
        {
            LoadProtocol();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (IsWorking)
            {
                Log.Info("already connected!");
                return;
            }
            mApi.ReConnect();
            workThread = new Thread(ThreadMethod);
            workThread.Start();
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            IsWorking = false;
            IsClosed = false;
        }

        private void button_CleanMainShow_Click(object sender, EventArgs e)
        {
            textBox_MainShow.Clear();
            textBox_MainShow.Refresh();
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            object msg = mApi.RouteGet(curProtocolMsgName);
            if (msg == null)
            {
                return;
            }

            int rowCount = this.dataGridView_Protocol.Rows.Count;
            int columnsCount = this.dataGridView_Protocol.ColumnCount;
            for (int i = 0; i < rowCount - 1; i++)
            {
                string dataType = "";
                string dataName = "";
                string dataValue = "";

                object objtmp;
                objtmp = this.dataGridView_Protocol.Rows[i].Cells[0].Value;
                if (objtmp != null)
                {
                    dataType = objtmp.ToString();
                }
                else
                {
                    string strLog = string.Format("row {0} dataType null", i);
                    Log.Warn(strLog);
                }

                objtmp = this.dataGridView_Protocol.Rows[i].Cells[1].Value;
                if (objtmp != null)
                {
                    dataName = objtmp.ToString();
                }
                else
                {
                    string strLog = string.Format("row {0} dataName null", i);
                    Log.Warn(strLog);
                }
                objtmp = this.dataGridView_Protocol.Rows[i].Cells[2].Value;

                if (objtmp != null)
                {
                    dataValue = objtmp.ToString();
                }
                else
                {
                    string strLog = string.Format("row {0} dataValue null", i);
                    Log.Warn(strLog);
                    return;
                }
                SetDateValue(msg, dataName, objtmp);

                string strText = dataName + ":" + dataValue + " " + DateTime.Now + System.Environment.NewLine;
                this.textBox_MainShow.AppendText(strText);
                this.textBox_MainShow.ScrollToCaret();
            }

            mApi.RouteSend(msg.GetType().Name, msg);
        }

        public void SetDateValue(object msg, string dataName, object value)
        {
            if (msg == null)
            {
                return;
            }
            Type t = msg.GetType();
            PropertyInfo info = t.GetProperty(dataName);
            switch (info.PropertyType.Name)
            {
                case PropertyType.Int32:
                    int n = Convert.ToInt32(value);
                    info.SetValue(msg, n, null);
                    return;
                case PropertyType.String:
                    string str = value.ToString();
                    info.SetValue(msg, str, null);
                    return;
                case PropertyType.UInt64:
                    UInt64 uInt = Convert.ToUInt64(value);
                    info.SetValue(msg, uInt, null);
                    break;
                case PropertyType.Float:
                    float fN = Convert.ToSingle(value);
                    info.SetValue(msg, fN, null);
                    break;
                case PropertyType.Bool:
                    bool bN = Convert.ToBoolean(value);
                    info.SetValue(msg, bN, null);
                    break;
                case PropertyType.List:
                    string tempString = value.ToString();
                    string[] sp = StringUtil.GetSplitString(tempString, '|');

                    var lst = info.GetValue(msg, null);
                    var addMethod = lst.GetType().GetMethod("Add");

                    var TType = lst.GetType().GetTypeInfo().GenericTypeArguments[0];
                    switch (TType.Name)
                    {
                        case PropertyType.Int32:
                            foreach (string item in sp)
                            {
                                addMethod.Invoke(lst, new object[] { Convert.ToInt32(item) });
                            }
                            return;
                        case PropertyType.String:
                            foreach (string item in sp)
                            {
                                addMethod.Invoke(lst, new object[] { item });
                            }
                            return;
                        case PropertyType.UInt64:
                            foreach (string item in sp)
                            {
                                addMethod.Invoke(lst, new object[] { Convert.ToUInt64(item) });
                            }
                            break;
                        case PropertyType.Float:
                            foreach (string item in sp)
                            {
                                addMethod.Invoke(lst, new object[] { Convert.ToSingle(item) });
                            }
                            break;
                        case PropertyType.Bool:
                            foreach (string item in sp)
                            {
                                addMethod.Invoke(lst, new object[] { Convert.ToBoolean(item) });
                            }
                            break;
                        default:
                            Log.Error("相关类型数据解析功能正在建设中！");
                            break;
                    }

                    break;
                default:
                    break;

            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {

        }

        private void button_MakeProtocol_Click(object sender, EventArgs e)
        {
            if (comboBox_ProtocolName.SelectedItem != null)
            {
                curProtocolMsgName = comboBox_ProtocolName.SelectedItem.ToString();
                curMsg = mApi.RouteInit(curProtocolMsgName);
                ClearDataGrid();
                Parse(curMsg);
            }
            else
            {

            }
        }

        private void ClearDataGrid()
        {
            this.dataGridView_Protocol.Rows.Clear();
        }

        private void Parse(object obj)
        {
            Type t = obj.GetType();
            foreach (var item in t.GetProperties())
            {
                SetDataGridValue(item);
            }
        }

        public void SetDataGridValue(PropertyInfo property)
        {
            int index = this.dataGridView_Protocol.Rows.Add();
            switch (property.PropertyType.Name)
            {
                case PropertyType.List:
                    this.dataGridView_Protocol.Rows[index].Cells[0].Value = property.PropertyType.Name;

                    int offset = property.PropertyType.FullName.IndexOf(",");
                    string strTemp = property.PropertyType.FullName.Substring(0, offset);
                    offset = strTemp.LastIndexOf(".");
                    strTemp = strTemp.Substring(offset + 1, strTemp.Length - offset - 1);
                    strTemp = string.Format("{0}<{1}>", property.PropertyType.Name, strTemp);
                    this.dataGridView_Protocol.Rows[index].Cells[0].Value = strTemp;
                    break;
                case PropertyType.Int32:
                case PropertyType.UInt64:
                case PropertyType.Float:
                case PropertyType.Bool:
                case PropertyType.String:
                default:
                    this.dataGridView_Protocol.Rows[index].Cells[0].Value = property.PropertyType.Name;
                    break;
            }
            this.dataGridView_Protocol.Columns[0].ReadOnly = true;
            this.dataGridView_Protocol.Rows[index].Cells[1].Value = property.Name;
            this.dataGridView_Protocol.Columns[1].ReadOnly = true;

        }


    }
}
