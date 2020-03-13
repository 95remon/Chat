using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace ChatUser
{
    public partial class Form1 : Form
    {
        StreamReader streamReader;
        StreamWriter streamWriter;

        public Form1()
        {
            InitializeComponent();
        }

        private void doConnection()
        {
            TcpClient tcpClient = new TcpClient("192.168.1.17", 5000);

            NetworkStream networkStream = tcpClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            doConnection();

            doRegist();
        }

        private void doRegist()
        {
            string Info = "#Reg#" + txtEmailReg.Text+ "#Reg#" + txtPasswordReg.Text+ "#Reg#" + txtPhoneReg.Text+ "#Reg#";
            streamWriter.WriteLine(Info);
            txtEmailReg.Text = "";
            txtPasswordReg.Text = "";
            txtPhoneReg.Text = "";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            doConnection();

            doLogin();

            ReadMsgs();
        }

        private void doLogin()
        {
            string Info = "#Log#" + txtEmailLog.Text + "#Log#" + txtPasswordLog.Text + "#Log#" ;
            streamWriter.WriteLine(Info);
            txtEmailLog.Text = "";
            txtPasswordLog.Text = "";
            
        }

        private async void ReadMsgs()
        {
            while (true)
            {
                string msg = await streamReader.ReadLineAsync();
                if (msg.StartsWith("#SuccessfulLogin#")&&msg.EndsWith("#SuccessfulLogin#")) 
                {
                    string[] Msg = msg.Split(new string[] { "#SuccessfulLogin#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);
                }
                if (msg.StartsWith("#FailLogin#") && msg.EndsWith("#FailLogin#"))
                {
                    string[] Msg = msg.Split(new string[] { "#FailLogin#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);
                }

            }
        }
    }
}
