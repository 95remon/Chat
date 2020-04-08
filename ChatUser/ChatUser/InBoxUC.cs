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
    public partial class InBoxUC : UserControl
    {
        public InBoxUC()
        {
            InitializeComponent();
        }
        public string txtMember
        {
            get { return labelMember.Text; }
            set { labelMember.Text = value; }
        }
        public string txtMsg
        {
            get { return labelState.Text; }
            set { labelState.Text = value; }
        }
        public string txtDate
        {
            get { return labelDate.Text; }
            set { labelDate.Text = value; }
        }

        public new event EventHandler DoubleClick
        {
            add
            {
                base.DoubleClick += value;
                foreach (Control control in Controls)
                {
                    control.DoubleClick += value;
                }
            }
            remove
            {
                base.DoubleClick -= value;
                foreach (Control control in Controls)
                {
                    control.DoubleClick -= value;
                }
            }
        }
    
    }

}
