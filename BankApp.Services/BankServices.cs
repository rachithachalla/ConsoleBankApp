using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models;


namespace BankApp.Services
{
    public class BankServices
    {
        public List<Account> accounts = new List<Account>();

        public int addAccount(string name,int p)
        {
            Account acc = new Account
            {
                accName = name,
                pin = p,
                bal = 0
            };
            this.accounts.Add(acc);
            if (acc.accNo != 0)
            {
                return acc.accNo;
            } else
            {
                return 0;
            }

        }
    }
}
