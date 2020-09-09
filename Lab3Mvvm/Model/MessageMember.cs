using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Mvvm.Model
{
    public class MessageMember : Member
    {
        /// Creates a new member.
        public MessageMember(string fName, string lName, string mail, string message) : base(fName, lName, mail)
        {
            Message = message;
        }
        /// A property that includes the message.
        /// </summary>
        public string Message { get; private set; }
    }
}


