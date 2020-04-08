using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ChatServer
{
    
    class User
    {

       
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public  TcpClient Tcp { get; set; }
        public List<User> Friends;
        public List<Chat> Chats;
        public Chat publicChat;
        public List<User> OnlineUsers;

        StreamReader StreamReader;
        StreamWriter StreamWriter;

        public event Action<string> MsgReceived;

        public void doConnection()
        {
            NetworkStream networkStream = Tcp.GetStream();
            StreamReader = new StreamReader(networkStream);
            StreamWriter = new StreamWriter(networkStream);
            StreamWriter.AutoFlush = true;
            ReadMsgs();
        }


        private async void ReadMsgs()
        {
            while (true)
            {
                string msg = await StreamReader.ReadLineAsync();
                if (MsgReceived != null)
                    MsgReceived(msg);
                if(msg.StartsWith("#OnlineUsers#") && msg.EndsWith("#OnlineUsers#"))
                {
                    string onlineUsers = "#OnlineUsers#";
                    foreach (User user in OnlineUsers)
                    {
                        onlineUsers += user.Email + "#m#" +user.Name + "#m#" + user.Status + "#OnlineUsers#";
                    }
                    SendMsg(onlineUsers);
                }
            }
        }

        

        internal void sendInfo()
        {
            doConnection();
            StreamWriter.WriteLine("#UserName#" + Name + "#UserName#");
            StreamWriter.WriteLine("#UserPassword#" + Password + "#UserPassword#");
            StreamWriter.WriteLine("#UserPhone#" + Phone + "#UserPhone#");
            StreamWriter.WriteLine("#UserStatus#" + Status + "#UserStatus#");
            //StreamWriter.WriteLine("#UserTcp#"+item.Tcp+"#UserTCP#");
            StreamWriter.WriteLine("#UserEmail#" + Email + "#UserEmail#");
            StreamWriter.WriteLine("#UserAddress#" + Address + "#UserAddress#");
            string UserFriends = "#UserFriend#";
            foreach (User friend in Friends)
            {
                UserFriends += friend.Name + "#m#" + friend.Email + "#m#" + friend.Address + "#m#" + friend.Status + "#UserFriend#";
            }
            StreamWriter.WriteLine(UserFriends);

            //string numOfChats = "#numOfChats#" + item.Chats.Count+ "#numOfChats#";
            //StreamWriter.WriteLine(numOfChats);

            string UserChats = "#UserChat#";
            foreach (Chat chat in Chats)
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
            //StreamWriter.WriteLine("#Done# done msg #Done#");
        }

        internal void SendMsg(string msg)
        {
            if (Status)
            {
                StreamWriter.WriteLine(msg);
            }
        }
    }
}
