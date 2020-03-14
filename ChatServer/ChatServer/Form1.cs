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

namespace ChatServer
{
    public partial class Form1 : Form
    {
        StreamReader StreamReader;
        StreamWriter StreamWriter;
        TcpClient tcpClient;
        List<User> users = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startListn();
        }

        private async void startListn()
        {
            IPAddress IP = IPAddress.Parse("192.168.1.17");
            TcpListener tcpListener = new TcpListener(IP, 5000);
            tcpListener.Start();
            while (true)
            {
                tcpClient = await tcpListener.AcceptTcpClientAsync();
                NetworkStream networkStream = tcpClient.GetStream();
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
            StreamWriter.WriteLine("#SuccessfulLogin# Login Successfully with "+item.Email+"  "+ item.Address+ "#SuccessfulLogin#");

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
    }
}
