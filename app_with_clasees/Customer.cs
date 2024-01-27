using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_with_clasees
{
    internal class Customer
    {
        public Customer(string username,string password,string CustomerName, string events,string date,string time,string status,string planner,float bill)
        {
            this.Username = username;
            this.password = password;
            this.CustomerName = CustomerName;
            this.events = events;
            this.date = date;
            this.time = time;
            this.status = status;
            this.planner = planner;
            this.bill = bill;
        }
        public string Username;
        public string password;
        public string CustomerName;
        public string events;
        public string date;
        public string time;
        public string status;
        public string planner;
        public float bill;

    }
}
