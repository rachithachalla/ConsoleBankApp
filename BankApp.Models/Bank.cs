using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    class Bank
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Account> Accounts { get; set; }


        public Bank(string Name)
        {
            this.Id = Name.Substring(0, 3) + DateTime.Today.ToShortDateString();
            this.Name = Name;
        }
    }
}
