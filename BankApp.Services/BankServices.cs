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
        public List<Bank> banks = new List<Bank>();
        public List<Account> accounts = new List<Account>();
        public List<Transaction> transactions = new List<Transaction>();
        public List<Employee> employees = new List<Employee>();


         public List<Employee> AddEmployee(string Name, string EmployeeId, string Password, string Designation, String ContactNo, String Address)
        {
            Employee employee = new Employee(Name, EmployeeId, Password, Designation, ContactNo, Address);
            this.employees.Add(employee);
            return employees;
        }

        public void CreateBank(string name)
        {
            Bank bank = new Bank(name);
            this.banks.Add(bank);
        }

        public string AddAccount(string name, string password,string contactNo,string address)
        {
            Account acc = new Account(name, password,contactNo,address);
            this.accounts.Add(acc);
            if (acc.UserId != null)
            {
                return acc.UserId;
            }
            else
            {
                return "";
            }

        }

        public void AddTransaction(string bankId, string sourceAcccountId, string destinationAccountId, decimal previousamount,decimal updatedAmount, TransactionType type)
        {
            Transaction transaction = new Transaction(bankId,sourceAcccountId,destinationAccountId,previousamount,updatedAmount,type);
            this.transactions.Add(transaction);
        }

        public string Deposit(string bankId, string accountNo, string password, decimal amt)
        {
            //int fl = 0;
            var account = this.accounts.Single(x => x.UserId == accountNo);
            if (account is null)
            {
                return "Invalid Account Number!!!";
            }

            if (account.Password != password)
            {
                return "Invalid Password!!!";
            }
            decimal perviousBalance = account.Balance;
            account.Balance = account.Balance + amt;

            if (account.Balance == perviousBalance + amt)
                    {
                        AddTransaction(bankId,accountNo, accountNo,perviousBalance,account.Balance,TransactionType.Credit);
                        return "Amount is deposited succesfully!!!\n" +
                            "your balance is: " + account.Balance;
                    }
                    else
                    {
                        return "Amount is not Deposited!!..Try again later..";
                    }
        }

        public string Withdraw(string bankId,string accountNo, string password, decimal amount)
        {
            var account = this.accounts.Single(x => x.UserId == accountNo);

            if (account is null)
            {
                return "Invalid Account Number!!!";
            }

            if (account.Password != password)
            {
                return "Invalid Pin!!!";
            }

            if (account.Balance >= amount)
            {
                account.Balance = account.Balance - amount;
                AddTransaction(bankId, accountNo, accountNo,account.Balance-amount,account.Balance, TransactionType.Debit);
                return "Withdraw succesfull!!!\n" +
                            "your balance is: " + account.Balance;
            }
            else
            {
                return "Withdraw Unsucessfull!!!...Try Again..";
            }

        }
        public string UpdateAccount(string accountNo,string name,string contactNo,string address)
        {
            var account = this.accounts.Single(x => x.UserId == accountNo);
            if(account != null)
            {
                account.Name = name;
                account.ContactNo = contactNo;
                account.Address = address;

                return "Account is updated Successfully!!\n" +
                    "Account number: " + account.UserId + "\n" +
                    "Account Holder Name: " + account.Name + "\n" +
                    "Contact Number: " + account.ContactNo + "\n" +
                    "Adress: " + account.Address + "\n";
            } else
            {
                return "Account does not exist!!";
            }
        }

        public string DeleteAccount(string accountNo)
        {
            var account = this.accounts.Single(x => x.UserId == accountNo);
            this.accounts.Remove(account);
            if(this.accounts.Contains(account))
            {
                return "Account is Not Deleted!!";
            }
            return "Account Deleted Successfully";
        }

        public string RevertTransaction(string bankId,string transactionId)
        {
            var transaction = this.transactions.Single(x => x.Id == transactionId);
            var sourceAccount = this.accounts.Single(x => x.UserId == transaction.SourceAcccountId);
            var destinationAccount = this.accounts.Single(x => x.UserId == transaction.DestinationAccountId);
            decimal previousAmount = sourceAccount.Balance;
            if(transaction != null)
            {
                sourceAccount.Balance = sourceAccount.Balance + transaction.PreviousAmount - transaction.UpdatedAmount;
                destinationAccount.Balance = destinationAccount.Balance - (transaction.UpdatedAmount - transaction.PreviousAmount);
                AddTransaction(bankId, transaction.SourceAcccountId, transaction.DestinationAccountId, previousAmount, sourceAccount.Balance, TransactionType.Revert);
                return "Transaction is reverted successfully!!!";
            } else
            {
                return "Invalid Transaction Id!!";
            }

        }

        public string TransferAmount(string bankId,string sourceAccountNo, string destinationAccountNo, string password, decimal amount)
        {
            var sourceAccount = this.accounts.Single(x => x.UserId == sourceAccountNo);
            var destinatonAccount = this.accounts.Single(x => x.UserId == destinationAccountNo);

            if (sourceAccount.Password == password)
            {
                destinatonAccount.Balance = destinatonAccount.Balance + amount;
                sourceAccount.Balance = sourceAccount.Balance - amount;

                AddTransaction(bankId, sourceAccountNo, destinationAccountNo,sourceAccount.Balance -amount,sourceAccount.Balance,TransactionType.Debit);
                return "Amount " + amount + "Rs transferred succesfully to " + destinatonAccount.Name + "\n" +
                            "your balance is: " + sourceAccount.Balance;
            }
            else
            {
                return "Error in tranfering amount!!!...Try again later...";
            }

        }

        public IEnumerable<Transaction> TransactionHistory(string sourceAccountNo, string password)
        {
            var transactionAccount = this.transactions.Where(x => x.SourceAcccountId == sourceAccountNo);//.Select(m => new { sourceAccount = m.SourceAcccountId});
            var acc = this.accounts.Single(x => x.UserId == sourceAccountNo);
            if (acc.Password == password)
            {
                return transactionAccount;
                /*foreach (var account in transactionAccount) {
                    return ".......Transaction History......\n" +
                        "from:        " + account.SourceAcccountId + "\n" +
                        "to:          " + account.DestinationAccountId + "\n" +
                        "description: " + account.Type + "\n" +
                        "time:        " + account.Time + "\n";
                }*/
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Transaction> TransactionHistory(string sourceAccountNo)
        {
            var transactionAccount = this.transactions.Where(x => x.SourceAcccountId == sourceAccountNo);
            var acc = this.accounts.Single(x => x.UserId == sourceAccountNo);
            if(transactionAccount != null) { 
                return transactionAccount;
             
            }
            else
            {
                return null;
            }
        }
    }
}
