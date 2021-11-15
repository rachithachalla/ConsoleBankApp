using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    public class Account
    {
        /*static int id = 0;
        public int accNo;
        public string accName;
        public int pin;
        public double bal;*/

        //static int Id = 0;
        public string UserId { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public List<Transaction> Transactions { get; set; }



        public Account(string Name, string Password, string ContactNo, string Address)
        {
            //Id = Id + 1;
            this.UserId = Name.Substring(0, 3) + DateTime.Today.ToShortDateString();
            this.Password = Password;
            this.Name = Name;
            this.Balance = 0;
            this.Address = Address;
            this.ContactNo = ContactNo;
        }
       /* public Account()
        {
            id = id + 1;
            this.accNo = id;
        }*/
    }
}
