using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUser
{
    // We need to add each Msg to the Server side to save it and resend it for each user when he relog 
    
    class Msg
    {
        public string Sender { get; set; }
        public string Content { get; set; }

        //public int Type { get; set; }   (enum) 

        // Attatch (for pic)
        public DateTime DateTime { get; set; }


    }
}
