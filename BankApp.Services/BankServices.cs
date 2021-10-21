using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;


namespace Technovert.BankApp.Services
{
    public class BankServices
    {
        public List<Account> accounts = new List<Account>();
        public List<Transaction> transactions = new List<Transaction>();

        public int addAccount(string name, int p)
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
            }
            else
            {
                return 0;
            }

        }

        public void addTransaction(int sAcNo, int rAcNo, double amt, string ds, string time)
        {
            Transaction transaction = new Transaction(sAcNo, rAcNo, amt, ds, time);
            this.transactions.Add(transaction);
        }

        public string deposit(int acNo, int p, double amt)
        {
            var acc = this.accounts.Single(x => x.accNo == acNo);
            if (acc.accNo != 0)
            {
                if (acc.pin == p)
                {
                    double prvbal = acc.bal;
                    acc.bal = acc.bal + amt;

                    if (acc.bal == prvbal + amt)
                    {
                        addTransaction(acNo, acNo, amt, "deposit", DateTime.Now.ToString("G"));
                        return "Amount is deposited succesfully!!!\n" +
                            "your balance is: " + acc.bal;
                    }
                    else
                    {
                        return "Amount is not Deposited!!..Try again later..";
                    }
                }
                else
                {
                    return "Invalid Pin!!!";
                }
            }
            else
            {
                return "Invalid Account Number!!!";
            }
        }

        public string withdraw(int acNo, int p, double amt)
        {
            var acc = this.accounts.Single(x => x.accNo == acNo);

            if (acc is null)
            {
                return "Invalid Account Number!!!";
            }

            if (acc.pin != p)
            {
                return "Invalid Pin!!!";
            }

            acc.bal = acc.bal - amt;
            addTransaction(acNo, acNo, amt, "withdrawn", DateTime.Now.ToString("G"));

            if (acc.accNo != 0)
            {
                if (acc.pin == p)
                {
                    if (acc.bal >= amt)
                    {
                        acc.bal = acc.bal - amt;
                        addTransaction(acNo, acNo, amt, "withdrawn", DateTime.Now.ToString("G"));
                        return "Withdraw succesfull!!!\n" +
                            "your balance is: " + acc.bal;
                    }
                    else
                    {
                        return "Withdraw Unsucessfull!!!...Try Again..";
                    }
                }
                else
                {
                    return "Invalid Pin!!!";
                }
            }
            else
            {
                return "Invalid Account Number!!!";
            }
        }

        public string transferAmount(int sAccNo, int rAccNo, int p, double amt)
        {
            var sAcc = this.accounts.Single(x => x.accNo == sAccNo);
            var rAcc = this.accounts.Single(x => x.accNo == rAccNo);

            if (sAcc.pin == p)
            {
                rAcc.bal = rAcc.bal + amt;
                sAcc.bal = sAcc.bal - amt;

                addTransaction(sAccNo, rAccNo, amt, "transfer", DateTime.Now.ToString("G"));
                return "Amount " + amt + "Rs transferred succesfully to " + rAcc.accName + "\n" +
                            "your balance is: " + sAcc.bal;
            }
            else
            {
                return "Error in tranfering amount!!!...Try again later...";
            }

        }

        public string transactionHistory(int acNo, int pin)
        {
            var trAcc = this.transactions.Where(x => x.sAccNo == acNo).Select(m => new { sourceAccount = m.sAccNo });
            var acc = this.accounts.Single(x => x.accNo == acNo);
            if (acc.pin == pin)
            {
                return ".......Transaction History......\n" +
                    "from:        " + trAcc.sAccNo + "\n" +
                    "to:          " + trAcc.rAccNo + "\n" +
                    "description: " + trAcc.desc + "\n" +
                    "time:        " + trAcc.time + "\n";
            }
            else
            {
                return "Invalid pin!!!";
            }
        }
    }
}
