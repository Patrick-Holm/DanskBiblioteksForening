using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassLogin
    {
        private string _id;
        private string _user;

        public ClassLogin()
        {

        }

        public string id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

        public string user
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                }
            }
        }

        public ClassPerson GetUserData(int id, string user)
        {
            ClassPerson person = new ClassPerson();

            return person;
        }
    }
}