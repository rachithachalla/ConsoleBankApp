using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        static int id = 0;
        public int accNo;
        public string accName { get; set; }
        public int pin { get; set; }

        public double bal;
        
        

        public Account()
        {
            id = id + 1;
            this.accNo = id;
        }
    }
}
