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
    public partial class MsgUC : UserControl
    {
        public string Msg 
        { 
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public MsgUC()
        {
            InitializeComponent();
        }
    }
}
