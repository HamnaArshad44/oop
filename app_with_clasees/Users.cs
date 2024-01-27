using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_with_clasees
{
    internal class Users
    {
        public Users(string username,string password,string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }  
        public string username;
        public string password;
        public string role;
    }
}
