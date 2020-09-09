using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Mvvm.Model
{
    public class Member : ObservableObject
    {
        private string firstName;
        private string lastName;
        private string email;
        public Member(string fName, string lName, string mail)
        {
            firstName = fName;
            lastName = lName;
            email = mail;
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                Set<string>(() => this.FirstName, ref firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                Set<string>(() => this.LastName, ref lastName, value);
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                Set<string>(() => this.Email, ref email, value);
            }
        }

        public string GetDisplayText
        {
            get { return firstName + " " + lastName + " - " + email; }
        }
    }
}