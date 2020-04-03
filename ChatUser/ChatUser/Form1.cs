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
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;


namespace ChatUser
{
    public partial class Form1 : Form
    {
        StreamReader streamReader;
        StreamWriter streamWriter;
        NetworkStream networkStream;
        TcpClient tcpClient;
        //IFormatter formatter;
        bool LogedIn = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void doConnection()
        {
            tcpClient = new TcpClient("192.168.1.5", 5000);
            networkStream = tcpClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;
            
        }
        private void btnReg_Click(object sender, EventArgs e)
        {
            doConnection();

            doRegist();

            ReadMsgs();
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
            
            while (!LogedIn)
            {
                string msg = await streamReader.ReadLineAsync();
                if (msg.StartsWith("#SuccessfulLogin#")&&msg.EndsWith("#SuccessfulLogin#")) 
                {
                    
                    //User u = (User)formatter.Deserialize(networkStream);
                    string[] Msg = msg.Split(new string[] { "#SuccessfulLogin#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]); //+ " "+ u.Email);
                    //networkStream.Close();
                    //tcpClient.Close();
                    //streamReader.Close();
                    //streamWriter.Close();
                    ChatForm chatForm = new ChatForm(Msg[2]);
                    chatForm.Show();
                    //this.Hide();
                    LogedIn = true;
                    
                    //tcpClient.Close();
                }
                else if (msg.StartsWith("#FailLogin#") && msg.EndsWith("#FailLogin#"))
                {
                    string[] Msg = msg.Split(new string[] { "#FailLogin#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);

                }
                else if (msg.StartsWith("#SuccessfulRegistration#") && msg.EndsWith("#SuccessfulRegistration#"))
                {
                    string[] Msg = msg.Split(new string[] { "#SuccessfulRegistration#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);
                }
                else if (msg.StartsWith("#FailRegistration#") && msg.EndsWith("#FailRegistration#"))
                {
                    string[] Msg = msg.Split(new string[] { "#FailRegistration#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);
                }
                
                
            }
        }

        private void OpenChat(string msg)
        {
            User user = new User();
            if (msg.StartsWith("#UserName#")&&msg.EndsWith("#UserName#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserName#" }, StringSplitOptions.None);
                user.Name = Msg[1];
            }
            else if (msg.StartsWith("#UserPassword#") && msg.EndsWith("#UserPassword#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserPassword#" }, StringSplitOptions.None);
                user.Password = Msg[1];
            }
            else if (msg.StartsWith("#UserPhone#") && msg.EndsWith("#UserPhone#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserPhone#" }, StringSplitOptions.None);
                user.Phone = Msg[1];
            }
            else if (msg.StartsWith("#UserStatus#") && msg.EndsWith("#UserStatus#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserStatus#" }, StringSplitOptions.None);
                if (Msg[1].Equals("true"))
                {
                    user.Status = true;
                }
                else
                {
                    user.Status = false;
                }
            }
            else if (msg.StartsWith("#UserEmail#") && msg.EndsWith("#UserEmail#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserEmail#" }, StringSplitOptions.None);
                user.Email = Msg[1];
            }
            else if (msg.StartsWith("#UserAddress#") && msg.EndsWith("#UserAddress#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserAddress#" }, StringSplitOptions.None);
                user.Address = Msg[1];
            }
            else if (msg.StartsWith("#UserFriend#") && msg.EndsWith("#UserFriend#"))
            {
                string[] Msg = msg.Split(new string[] { "#UserFriend#" }, StringSplitOptions.None);
                for (int i = 1; i < Msg.Length-1; i++)
                {
                    string[] data = msg.Split(new string[] { "#m#" }, StringSplitOptions.None);
                    bool tempStatus = false;
                    if (data[3].Equals("true"))
                    {
                        tempStatus = true;
                    }
                    User tempUser = new User { Name = data[0], Email = data[1], Address = data[2], Status = tempStatus };
                    user.Friends.Add(tempUser);
                }
            }



        }
    }
}
