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
    public partial class ListUC : UserControl
    {
        public ListUC()
        {
            InitializeComponent();
        }

        internal void AddToList(string name, string status)
        {
            ContactUC contact = new ContactUC();
            contact.txtName = name;
            if (status.Equals("True"))
            {
                contact.txtState = "Online";
            }
            else
            {
                contact.txtState = "Offline";
            }
            contact.DoubleClick += ChatForm.Contact_DoubleClick;//Contact_DoubleClick;
            
            flowLayoutPanel1.Controls.Add(contact);

            
        }

        //private void Contact_DoubleClick(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
