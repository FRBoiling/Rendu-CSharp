namespace SimpleClient
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_AccountName = new System.Windows.Forms.Label();
            this.label_ProtocolName = new System.Windows.Forms.Label();
            this.textBox_AccentName = new System.Windows.Forms.TextBox();
            this.comboBox_ProtocolName = new System.Windows.Forms.ComboBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.dataGridView_Protocol = new System.Windows.Forms.DataGridView();
            this.Column_DateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_MainShow = new System.Windows.Forms.TextBox();
            this.button_MakeProtocol = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_LoadProtocol = new System.Windows.Forms.Button();
            this.button_CleanMainShow = new System.Windows.Forms.Button();
            this.groupBox_Protocol = new System.Windows.Forms.GroupBox();
            this.groupBox_Login = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Protocol)).BeginInit();
            this.groupBox_Protocol.SuspendLayout();
            this.groupBox_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_AccountName
            // 
            this.label_AccountName.AutoSize = true;
            this.label_AccountName.Location = new System.Drawing.Point(14, 23);
            this.label_AccountName.Name = "label_AccountName";
            this.label_AccountName.Size = new System.Drawing.Size(53, 12);
            this.label_AccountName.TabIndex = 0;
            this.label_AccountName.Text = "输入账号";
            // 
            // label_ProtocolName
            // 
            this.label_ProtocolName.AutoSize = true;
            this.label_ProtocolName.Location = new System.Drawing.Point(15, 34);
            this.label_ProtocolName.Name = "label_ProtocolName";
            this.label_ProtocolName.Size = new System.Drawing.Size(53, 12);
            this.label_ProtocolName.TabIndex = 1;
            this.label_ProtocolName.Text = "协议名称";
            // 
            // textBox_AccentName
            // 
            this.textBox_AccentName.Location = new System.Drawing.Point(76, 18);
            this.textBox_AccentName.Name = "textBox_AccentName";
            this.textBox_AccentName.Size = new System.Drawing.Size(194, 21);
            this.textBox_AccentName.TabIndex = 2;
            // 
            // comboBox_ProtocolName
            // 
            this.comboBox_ProtocolName.FormattingEnabled = true;
            this.comboBox_ProtocolName.Location = new System.Drawing.Point(76, 30);
            this.comboBox_ProtocolName.Name = "comboBox_ProtocolName";
            this.comboBox_ProtocolName.Size = new System.Drawing.Size(276, 20);
            this.comboBox_ProtocolName.TabIndex = 3;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(291, 16);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 4;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // dataGridView_Protocol
            // 
            this.dataGridView_Protocol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Protocol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_DateType,
            this.Column_VariableName,
            this.Column_Value});
            this.dataGridView_Protocol.Location = new System.Drawing.Point(12, 69);
            this.dataGridView_Protocol.Name = "dataGridView_Protocol";
            this.dataGridView_Protocol.RowTemplate.Height = 23;
            this.dataGridView_Protocol.Size = new System.Drawing.Size(452, 358);
            this.dataGridView_Protocol.TabIndex = 5;
            // 
            // Column_DateType
            // 
            this.Column_DateType.HeaderText = "数据类型";
            this.Column_DateType.Name = "Column_DateType";
            this.Column_DateType.ReadOnly = true;
            // 
            // Column_VariableName
            // 
            this.Column_VariableName.HeaderText = "变量名";
            this.Column_VariableName.Name = "Column_VariableName";
            this.Column_VariableName.ReadOnly = true;
            // 
            // Column_Value
            // 
            this.Column_Value.HeaderText = "值";
            this.Column_Value.Name = "Column_Value";
            // 
            // textBox_MainShow
            // 
            this.textBox_MainShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MainShow.Location = new System.Drawing.Point(624, 8);
            this.textBox_MainShow.Multiline = true;
            this.textBox_MainShow.Name = "textBox_MainShow";
            this.textBox_MainShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_MainShow.Size = new System.Drawing.Size(246, 503);
            this.textBox_MainShow.TabIndex = 6;
            // 
            // button_MakeProtocol
            // 
            this.button_MakeProtocol.Location = new System.Drawing.Point(366, 21);
            this.button_MakeProtocol.Name = "button_MakeProtocol";
            this.button_MakeProtocol.Size = new System.Drawing.Size(98, 37);
            this.button_MakeProtocol.TabIndex = 7;
            this.button_MakeProtocol.Text = "生成可发送协议";
            this.button_MakeProtocol.UseVisualStyleBackColor = true;
            this.button_MakeProtocol.Click += new System.EventHandler(this.button_MakeProtocol_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(507, 93);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(98, 38);
            this.button_Send.TabIndex = 8;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(507, 316);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(98, 23);
            this.button_Connect.TabIndex = 9;
            this.button_Connect.Text = "连接服务器";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(507, 356);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(98, 23);
            this.button_Disconnect.TabIndex = 10;
            this.button_Disconnect.Text = "断开服务器";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_LoadProtocol
            // 
            this.button_LoadProtocol.Location = new System.Drawing.Point(507, 213);
            this.button_LoadProtocol.Name = "button_LoadProtocol";
            this.button_LoadProtocol.Size = new System.Drawing.Size(98, 31);
            this.button_LoadProtocol.TabIndex = 11;
            this.button_LoadProtocol.Text = "载入协议dll";
            this.button_LoadProtocol.UseVisualStyleBackColor = true;
            this.button_LoadProtocol.Click += new System.EventHandler(this.button_LoadProtocol_Click);
            // 
            // button_CleanMainShow
            // 
            this.button_CleanMainShow.Location = new System.Drawing.Point(507, 465);
            this.button_CleanMainShow.Name = "button_CleanMainShow";
            this.button_CleanMainShow.Size = new System.Drawing.Size(98, 34);
            this.button_CleanMainShow.TabIndex = 12;
            this.button_CleanMainShow.Text = "清空显示";
            this.button_CleanMainShow.UseVisualStyleBackColor = true;
            this.button_CleanMainShow.Click += new System.EventHandler(this.button_CleanMainShow_Click);
            // 
            // groupBox_Protocol
            // 
            this.groupBox_Protocol.Controls.Add(this.button_MakeProtocol);
            this.groupBox_Protocol.Controls.Add(this.label_ProtocolName);
            this.groupBox_Protocol.Controls.Add(this.comboBox_ProtocolName);
            this.groupBox_Protocol.Controls.Add(this.dataGridView_Protocol);
            this.groupBox_Protocol.Location = new System.Drawing.Point(12, 72);
            this.groupBox_Protocol.Name = "groupBox_Protocol";
            this.groupBox_Protocol.Size = new System.Drawing.Size(477, 438);
            this.groupBox_Protocol.TabIndex = 13;
            this.groupBox_Protocol.TabStop = false;
            this.groupBox_Protocol.Text = "发送协议主体";
            // 
            // groupBox_Login
            // 
            this.groupBox_Login.Controls.Add(this.label_AccountName);
            this.groupBox_Login.Controls.Add(this.textBox_AccentName);
            this.groupBox_Login.Controls.Add(this.button_Login);
            this.groupBox_Login.Location = new System.Drawing.Point(12, 7);
            this.groupBox_Login.Name = "groupBox_Login";
            this.groupBox_Login.Size = new System.Drawing.Size(381, 52);
            this.groupBox_Login.TabIndex = 14;
            this.groupBox_Login.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 519);
            this.Controls.Add(this.groupBox_Login);
            this.Controls.Add(this.groupBox_Protocol);
            this.Controls.Add(this.button_CleanMainShow);
            this.Controls.Add(this.button_LoadProtocol);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_MainShow);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Protocol)).EndInit();
            this.groupBox_Protocol.ResumeLayout(false);
            this.groupBox_Protocol.PerformLayout();
            this.groupBox_Login.ResumeLayout(false);
            this.groupBox_Login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_AccountName;
        private System.Windows.Forms.Label label_ProtocolName;
        private System.Windows.Forms.TextBox textBox_AccentName;
        private System.Windows.Forms.ComboBox comboBox_ProtocolName;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.DataGridView dataGridView_Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_VariableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
        private System.Windows.Forms.TextBox textBox_MainShow;
        private System.Windows.Forms.Button button_MakeProtocol;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_LoadProtocol;
        private System.Windows.Forms.Button button_CleanMainShow;
        private System.Windows.Forms.GroupBox groupBox_Protocol;
        private System.Windows.Forms.GroupBox groupBox_Login;
    }
}

