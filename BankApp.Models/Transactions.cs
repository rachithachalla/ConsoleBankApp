using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Transactions
    {
        public int sAccNo;
        public int rAccNo;
        public double amt;
        public string desc;
        public string time;

        public Transactions(int sAccNo,int rAccNo,double amt,string desc,string time)
        {
            this.sAccNo = sAccNo;
            this.rAccNo = rAccNo;
            this.amt = amt;
            this.desc = desc;
            this.time = time;
        }
    }

}
