using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser
{
    
    public partial class ChatForm : Form
    {
        StreamReader streamReader;
        StreamWriter streamWriter;
        NetworkStream networkStream;
        TcpClient tcpClient;

        User user;
        string userEmail="";

        int panelWidth;
        bool Hidden;
        public ChatForm(string LoginEmail)
        {
            userEmail = LoginEmail;
            InitializeComponent();


            
            panelWidth = panelSide.Width;
            Hidden = false;


            user = new User();
            user.Friends = new List<User>();
            user.Chats = new List<Chat>();

            //loginUC1.SendMsg += LoginUC1_SendMsg;

        }


        //private void LoginUC1_SendMsg(object sender, EventArgs e)
        //{
        //    string Info = "#Log#" + loginUC1.name + "#Log#" + loginUC1.password + "#Log#";
        //    streamWriter.WriteLine(Info);
        //}

        private void ChatUC1_SendMsg(object sender, EventArgs e)
        {
            doConnection();
            string Msg = "#AllMsg#" + chatUC1.MsgText + "#AllMsg#";
            
            streamWriter.WriteLine(Msg);
            ReadMsgs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                panelSide.Width = panelSide.Width + 10;
                if (panelSide.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                panelSide.Width = panelSide.Width - 10;
                if (panelSide.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void doConnection()
        {
            tcpClient = new TcpClient("192.168.1.5", 5000);
            networkStream = tcpClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;

        }


        private async void ReadMsgs()
        {
            while (true)
            {

                string msg = await streamReader.ReadLineAsync();
                if (msg.StartsWith("#AllMsg#") && msg.EndsWith("#AllMsg#"))
                {
                    string[] Msg = msg.Split(new string[] { "#AllMsg#" }, StringSplitOptions.None);
                    MessageBox.Show(Msg[1]);
                }
                else if (msg.StartsWith("#UserName#") && msg.EndsWith("#UserName#"))
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
                    for (int i = 1; i < Msg.Length - 1; i++)
                    {
                        string[] data = Msg[i].Split(new string[] { "#m#" }, StringSplitOptions.None);
                        bool tempStatus = false;
                        if (data[3].Equals("true"))
                        {
                            tempStatus = true;
                        }
                        User tempUser = new User { Name = data[0], Email = data[1], Address = data[2], Status = tempStatus };
                        user.Friends.Add(tempUser);
                    }
                }
                else if (msg.StartsWith("#UserChat#") && msg.EndsWith("#UserChat#"))
                {

                    string[] AllChats = msg.Split(new string[] { "#UserChat#" }, StringSplitOptions.None);
                    for (int i = 1; i < AllChats.Length - 1; i++)
                    {
                        Chat TempChat = new Chat();
                        TempChat.Members = new List<User>();
                        TempChat.Msgs = new List<Msg>();
                        string[] ChatDetails = AllChats[i].Split(new string[] { "###m###" }, StringSplitOptions.None);

                        string[] ChatMembers = ChatDetails[0].Split(new string[] { "#MemberInfo#" }, StringSplitOptions.None);
                        for (int j = 1; j < ChatMembers.Length - 1; j++)
                        {
                            string[] MemberInfo = ChatMembers[j].Split(new string[] { "#m#" }, StringSplitOptions.None);
                            bool tempStatus = false;
                            if (MemberInfo[2].Equals("true"))
                                tempStatus = true;
                            User TempUser = new User
                            {
                                Name = MemberInfo[0],
                                Email = MemberInfo[1],
                                Status = tempStatus,
                                Address = MemberInfo[3]
                            };
                            TempChat.Members.Add(TempUser);
                        }
                        string[] ChatMsgs = ChatDetails[1].Split(new string[] { "#MsgInfo#" }, StringSplitOptions.None);
                        for (int j = 1; j < ChatMsgs.Length - 1; j++)
                        {
                            string[] MsgInfo = ChatMsgs[j].Split(new string[] { "#m#" }, StringSplitOptions.None);
                            Msg TempMsg = new Msg
                            {
                                Sender = MsgInfo[0],
                                DateTime = DateTime.Now,
                                Content = MsgInfo[2]
                            };
                            TempChat.Msgs.Add(TempMsg);
                        }
                        user.Chats.Add(TempChat);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user.Email);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doConnection();
            string Msg = "#AllMsg#" + "hi" + "#AllMsg#";
            streamWriter.WriteLine(Msg);
            ReadMsgs();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            doConnection();
            streamWriter.WriteLine("#GetUserInfo#" + userEmail + "#GetUserInfo#");
            ReadMsgs();
            chatUC1.SendMsg += ChatUC1_SendMsg;
            

        }
    }
}
