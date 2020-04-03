using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser
{
    public partial class ChatUC : UserControl
    {
        public event EventHandler SendMsg;
        public ChatUC()
        {
            InitializeComponent();
        }

        public string MsgText 
        {
            get 
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SendMsg != null)
                SendMsg(this, e);
            textBox1.Text="";
        }
    }
}
