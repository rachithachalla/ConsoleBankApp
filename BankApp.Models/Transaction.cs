using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    public class Transaction
    {
        /*public int sAccNo;
        public int rAccNo;
        public double amt;
        public string desc;
        public string time;*/


        public string Id { get; set; }

        public string SourceAcccountId { get; set; }

        public string DestinationAccountId { get; set; }

        //public decimal Amount { get; set; }

        public decimal PreviousAmount { get; set; }

        public decimal UpdatedAmount { get; set; }
        //prev and updated amt

        public TransactionType Type { get; set; }

        public DateTime Time { get; set; }

        public Transaction(string BankId,  string SourceAcccountId, string DestinationAccountId, decimal PreviousAmount, decimal UpdatedAmount, TransactionType Type)
        {
            this.Id = "TXN" + BankId.ToString() + SourceAcccountId.ToString();
            this.SourceAcccountId = SourceAcccountId;
            this.DestinationAccountId = DestinationAccountId;
            this.PreviousAmount = PreviousAmount;
            this.UpdatedAmount = UpdatedAmount;
            this.Type = Type;
            this.Time = DateTime.Now;
        }



        /*public Transaction(int sAccNo,int rAccNo,double amt,string desc,string time)
        {
            this.sAccNo = sAccNo;
            this.rAccNo = rAccNo;
            this.amt = amt;
            this.desc = desc;
            this.time = time;
        }*/
    }

}
