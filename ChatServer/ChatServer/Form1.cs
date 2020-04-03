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

namespace ChatServer
{
    public partial class Form1 : Form
    {
        NetworkStream networkStream;
        StreamReader StreamReader;
        StreamWriter StreamWriter;
        TcpClient tcpClient;
        List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();

            User testUser = new User
            {
                Name = "remon",
                Email = "remon",
                Password = "123456",
                Phone = "010",
                Address = "11111",
                Status = false,
                Friends = new List<User>
                {
                    new User
                    {
                        Name = "Ali",
                        Email = "Ali",
                        Password = "123456",
                        Phone = "010",
                        Address = "123123",
                        Status = false
                    }
                },
                Chats = new List<Chat>
                {
                    new Chat
                    {
                        Members = new List<User>
                        {
                            new User
                            {
                                Name = "ali",
                                Email = "ali",
                                Password = "123456",
                                Phone = "010",
                                Address = "123444",
                                Status = false
                            },
                            new User
                            {
                                Name = "mostafa",
                                Email = "mostafa",
                                Password = "123456",
                                Phone = "010",
                                Address = "123455",
                                Status = false
                            }

                        },
                        Msgs = new List<Msg>
                        {
                            new Msg
                            {
                                Sender = "remon",
                                Content= "hello",
                                DateTime = DateTime.Now
                            },
                            new Msg
                            {
                                Sender = "ali",
                                Content= "bye",
                                DateTime = DateTime.Now
                            }
                        }
                    }
                },

            };

            users.Add(testUser);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startListn();
        }

        private async void startListn()
        {
            IPAddress IP = IPAddress.Parse("192.168.1.5");
            TcpListener tcpListener = new TcpListener(IP, 5000);
            tcpListener.Start();

            while (true)
            {
                tcpClient = await tcpListener.AcceptTcpClientAsync();
                networkStream = tcpClient.GetStream();
                StreamReader = new StreamReader(networkStream);
                StreamWriter = new StreamWriter(networkStream);
                StreamWriter.AutoFlush = true;
                Checkmsg();
            }

        }

        private async void Checkmsg()
        {
            string msg = await StreamReader.ReadLineAsync();
            if (msg.StartsWith("#Reg#") && msg.EndsWith("#Reg#"))
                doRegistration(msg);
            if (msg.StartsWith("#Log#") && msg.EndsWith("#Log#"))
                doLogin(msg);
            if (msg.StartsWith("#GetUserInfo#") && msg.EndsWith("#GetUserInfo#"))
                getUserInfo(msg);
            if (msg.StartsWith("#AllMsg#") && msg.EndsWith("#AllMsg#"))
                allMsg(msg);
        }

        private void allMsg(string msg)
        {
            foreach (User item in users)
            {
                item.MsgReceived(msg);
            }
        }

        private void getUserInfo(string msg)
        {
            string[] Msg = msg.Split(new string[] { "#GetUserInfo#" }, StringSplitOptions.None);
            User LogedUser= new User();
            foreach (User item in users)
            {
                if (item.Email.Equals(Msg[1]))
                {
                    item.Address = tcpClient.Client.RemoteEndPoint.ToString();
                    item.Tcp = tcpClient;
                    LogedUser = item;
                }
            }
            StreamWriter.WriteLine("#UserName#" + LogedUser.Name + "#UserName#");
            StreamWriter.WriteLine("#UserPassword#" + LogedUser.Password + "#UserPassword#");
            StreamWriter.WriteLine("#UserPhone#" + LogedUser.Phone + "#UserPhone#");
            StreamWriter.WriteLine("#UserStatus#" + LogedUser.Status + "#UserStatus#");
            //StreamWriter.WriteLine("#UserTcp#"+item.Tcp+"#UserTCP#");
            StreamWriter.WriteLine("#UserEmail#" + LogedUser.Email + "#UserEmail#");
            StreamWriter.WriteLine("#UserAddress#" + LogedUser.Address + "#UserAddress#");
            string UserFriends = "#UserFriend#";
            foreach (User friend in LogedUser.Friends)
            {
                UserFriends += friend.Name + "#m#" + friend.Email + "#m#" + friend.Address + "#m#" + friend.Status + "#UserFriend#";
            }
            StreamWriter.WriteLine(UserFriends);

            //string numOfChats = "#numOfChats#" + item.Chats.Count+ "#numOfChats#";
            //StreamWriter.WriteLine(numOfChats);

            string UserChats = "#UserChat#";
            foreach (Chat chat in LogedUser.Chats)
            {
                //string numOfMembers = "#numOfMembers#" + chat.Members.Count + "#numOfMembers#";
                //StreamWriter.WriteLine(numOfMembers);

                string MemberInfo = "#MemberInfo#";
                foreach (User user in chat.Members)
                {
                    MemberInfo += user.Name + "#m#" + user.Email + "#m#" + user.Status + "#m#" + user.Address + "#MemberInfo#";
                }
                //StreamWriter.WriteLine(MemberInfo);
                UserChats += MemberInfo + "###m###";

                //string numOfMsgs = "#numOfMsgs#" + chat.Msgs.Count + "#numOfMsgs#";
                //StreamWriter.WriteLine(numOfMsgs);

                string MsgInfo = "#MsgInfo#";
                foreach (Msg msgItem in chat.Msgs)
                {
                    MsgInfo += msgItem.Sender + "#m#" + msgItem.DateTime + "#m#" + msgItem.Content + "#MsgInfo#";
                }
                //StreamWriter.WriteLine(MsgInfo);
                UserChats += MsgInfo + "#UserChat#";
            }
            StreamWriter.WriteLine(UserChats);

        }

        private void doLogin(string msg)
        {
            string[] Msg = msg.Split(new string[] { "#Log#" }, StringSplitOptions.None);
       
            foreach (User item in users)
            {
                if (item.Email.Equals(Msg[1])&&item.Password.Equals(Msg[2]))
                {
                    successfullyLogin(item);
                    return;
                }
            }

            failLogin();

        }

        private void failLogin()
        {
            StreamWriter.WriteLine("#FailLogin# Fail Login Please Check Email or Passowrd #FailLogin#");
        }

        private void successfullyLogin(User item)
        {
            string userIp = tcpClient.Client.RemoteEndPoint.ToString();
            //item.Tcp = tcpClient;
            item.Address = userIp;
            item.Status = true;
            //formatter = new BinaryFormatter();
            //formatter.Serialize(networkStream, item);
            StreamWriter.WriteLine("#SuccessfulLogin# Login Successfully #SuccessfulLogin#" + item.Email + "#SuccessfulLogin#");
        }

        private void doRegistration(string msg)
        {
            bool exist = false;
            string [] Msg = msg.Split(new string[] { "#Reg#" }, StringSplitOptions.None);
            foreach (User item in users)
            {
                if (Msg[1].Equals(item.Email))
                    exist = true;
            }
            if (!exist)
            {
                User user = new User
                {
                    Email = Msg[1],
                    Password = Msg[2],
                    Phone = Msg[3],
                    Tcp = tcpClient,
                };
                users.Add(user);
                //SuccessfulRegistration
                StreamWriter.WriteLine("#SuccessfulRegistration# Successfully Registration #SuccessfulRegistration#");
            }
            else
            {
                StreamWriter.WriteLine("#FailRegistration# Sorry this email is already registered #FailRegistration#");
            }
            
            //for (int i = 0; i < Msg.Length; i++)
            //{
            //    MessageBox.Show(Msg[i]);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter.WriteLine("HELLO");
        }
    }
}
