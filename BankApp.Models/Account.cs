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
        public int getAccNo()
        {
            return this.accNo;
        }

        public bool deposit(double amt)
        {
            double prvbal = this.bal;
            this.bal = this.bal + amt;

            if(this.bal == prvbal + amt)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string dispBalance()
        {
            return "Your Account Balance is " + this.bal + "Rs";
        }

        public double withdraw(double amt)
        {
            if (this.bal > amt)
            {
                this.bal = this.bal - amt;
                //Console.WriteLine("Withdraw Successfull!!");
            }
            else
            {
                return 0;
            }
            return this.bal;
        }
    }
}
