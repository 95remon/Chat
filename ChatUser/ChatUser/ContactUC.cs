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
    public partial class ContactUC : UserControl
    {
        public ContactUC()
        {
            InitializeComponent();
        }
        public Image Img 
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; } 
        }

        public string txtName 
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }

        public string txtState 
        {
            get { return labelState.Text; }
            set { labelState.Text = value; } 
        }

    }
}
