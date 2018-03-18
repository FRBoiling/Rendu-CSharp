using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var height = Height;
            var width = Width;
            MinimumSize = new Size(width, height);
            MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, height);
        }

        private void button_LoadProtocol_Click(object sender, EventArgs e)
        {

        }

        private void button_Connect_Click(object sender, EventArgs e)
        {

        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {

        }

        private void button_CleanMainShow_Click(object sender, EventArgs e)
        {

        }

        private void button_Send_Click(object sender, EventArgs e)
        {

        }

        private void button_Login_Click(object sender, EventArgs e)
        {

        }

        private void button_MakeProtocol_Click(object sender, EventArgs e)
        {

        }
    }
}
