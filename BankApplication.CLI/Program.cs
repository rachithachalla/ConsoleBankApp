using System;
using System.Collections.Generic;
using Technovert.BankApp.Services;

namespace Technovert.BankApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, decimal> currency = new Dictionary<string, decimal>();

            Console.WriteLine("Enter your Option: \n" +
                "1. Bank Employee\n" +
                "2. Account Holder");
            int choice = Convert.ToInt32(Console.ReadLine());
            decimal SameBankRGTSCharge=0, SameBankSIMPSCharge=5,OtherBankRGTSCharge=2,OtherBankIMPSCharge=6;
            BankServices bankServices = new BankServices();
            

            var employee = bankServices.AddEmployee("Rachitha", "E1", "1234", "Manager", "9876543210", "Hyderabad");
            if(choice == 1)
            {
                EmployeeOptions employeeOptions;
                Services services;
                do
                {
                    Console.WriteLine("Enter your option: \n" +
                        "1. Create Account\n" +
                        "2. Upadate Amount\n" +
                        "3. Delete Account\n" +
                        "4. Add Currency\n" +
                        "5. Add Service Charge\n" +
                        "6. View Transaction History\n" +
                        "7. Revert Transaction\n" +
                        "8. Exit\n");
                    int opt = Convert.ToInt32(Console.ReadLine());
                    employeeOptions = (EmployeeOptions)Convert.ToInt32(opt);

                    switch (employeeOptions)
                    {
                        case EmployeeOptions.CreateAccount:
                            {
                                Console.WriteLine("Enter Account holder name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string password = Console.ReadLine();
                                Console.WriteLine("Enter Contact Number:");
                                string contactNo = Console.ReadLine();
                                Console.WriteLine("Enter the Address:");
                                string address = Console.ReadLine();
                                string acNo = bankServices.AddAccount(name, password,contactNo,address);
                                if (acNo != null)
                                {
                                    Console.WriteLine("Account created Successfully");
                                    Console.WriteLine("Account Number is: " + acNo);
                                }
                                break;
                            }
                        case EmployeeOptions.UpdateAccount:
                            {
                                Console.WriteLine("Enter Account Number: ");
                                string accountNo = Console.ReadLine();
                                Console.WriteLine("Enter Account holder's new name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter new contact number: ");
                                string contactNo = Console.ReadLine();
                                Console.WriteLine("Enter new Address: ");
                                string address = Console.ReadLine();
                                Console.WriteLine(bankServices.UpdateAccount(accountNo, name, contactNo, address));
                                break;
                            }
                        case EmployeeOptions.DeleteAccount:
                            {
                                Console.WriteLine("Enter Account holder name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine(bankServices.DeleteAccount(name));
                                break;
                            }
                        case EmployeeOptions.AddCurrency:
                            {
                                Console.WriteLine("Enter new currency: ");
                                string curr = Console.ReadLine();
                                Console.WriteLine("Enter the currency value:");
                                decimal value = Convert.ToDecimal(Console.ReadLine());
                                currency.Add(curr, value);
                                break;
                            }
                        case EmployeeOptions.AddServiceCharge:
                            {
                                Console.WriteLine("1.Add Service charge for Same Bank\n" +
                                    "2. Add Service charge for diffent Bank");
                                int c = Convert.ToInt32(Console.ReadLine());  
                                if (c == 1)
                                {
                                    Console.WriteLine("1.RTGS\n 2.IMPS\n");
                                    int ch = Convert.ToInt32(Console.ReadLine());
                                    services = (Services)Convert.ToInt32(ch);
                                    switch (services)
                                    {
                                        case Services.RTGS:
                                            {
                                                Console.WriteLine("Enter the charge:");
                                                SameBankRGTSCharge = Convert.ToDecimal(Console.ReadLine());
                                                break;
                                            }
                                        case Services.IMPS:
                                            {
                                                Console.WriteLine("Enter the charge:");
                                                SameBankSIMPSCharge = Convert.ToDecimal(Console.ReadLine());
                                                break;
                                            }
                                    }
                                }
                                else if (c == 2)
                                {
                                    Console.WriteLine("1.RTGS\n 2.IMPS\n");
                                    int ch = Convert.ToInt32(Console.ReadLine());
                                    services = (Services)Convert.ToInt32(ch);
                                    switch (services)
                                    {
                                        case Services.RTGS:
                                            {
                                                Console.WriteLine("Enter the charge:");
                                                OtherBankRGTSCharge = Convert.ToDecimal(Console.ReadLine());
                                                break;
                                            }
                                        case Services.IMPS:
                                            {
                                                Console.WriteLine("Enter the charge:");
                                                OtherBankIMPSCharge = Convert.ToDecimal(Console.ReadLine());
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case EmployeeOptions.ViewTransactionHistory:
                            {
                                Console.WriteLine("Enter Account Number: ");
                                string sourceAccountNo = Console.ReadLine();

                                var transactionAccount = bankServices.TransactionHistory(sourceAccountNo);
                                if (transactionAccount != null)
                                {
                                    foreach (var account in transactionAccount)
                                    {
                                        Console.WriteLine(".......Transaction History......\n" +
                                            "from:        " + account.SourceAcccountId + "\n" +
                                            "to:          " + account.DestinationAccountId + "\n" +
                                            "description: " + account.Type + "\n" +
                                            "time:        " + account.Time + "\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invald Account Number!!");
                                }
                                break;
                            }
                        case EmployeeOptions.RevertTransaction:
                            {
                                Console.WriteLine("Enter the BankId: ");
                                String bankId = Console.ReadLine();
                                Console.WriteLine("Enter the Transaction Id: ");
                                string transactionId = Console.ReadLine();
                                Console.WriteLine(bankServices.RevertTransaction(bankId, transactionId));
                                break;
                            }
                        case EmployeeOptions.Exit:
                            {
                                break;
                            }
                    }

                } while (employeeOptions != EmployeeOptions.Exit);
            }
            else if(choice == 2){
                UserOptions userOptions;
                do
                {

                    Console.WriteLine("Enter your option: \n" +
                        "1. Create Account\n" +
                        "2. Deposite Amount\n" +
                        "3. Withdraw Money\n" +
                        "4. Tranfer Amount\n" +
                        "5. Transaction History\n" +
                        "6. exit");

                    int opt = Convert.ToInt32(Console.ReadLine());
                    userOptions = (UserOptions)Convert.ToInt32(opt);

                    switch (userOptions)
                    {
                        case UserOptions.createAccount:
                            {
                                Console.WriteLine("Enter Account holder name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string  password = Console.ReadLine();
                                Console.WriteLine("Enter Contact Number:");
                                string contactNo = Console.ReadLine();
                                Console.WriteLine("Enter the Address:");
                                string address = Console.ReadLine();
                                string accountNo = bankServices.AddAccount(name, password, contactNo, address);
                                if (accountNo != null)
                                {
                                    Console.WriteLine("Account created Successfully");
                                    Console.WriteLine("Your Account Number is: " + accountNo);
                                }
                                break;
                            }
                        case UserOptions.deposite:
                            {
                                Console.WriteLine("Enter the BankId: ");
                                String bankId = Console.ReadLine();
                                Console.WriteLine("Enter Account Number: ");
                                string accountNo = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string password = Console.ReadLine();
                                Console.WriteLine("Enter Amount to deposite: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Enter the currency:\n" +
                                    "such as $,Rs,etc...");
                                string curr = Console.ReadLine();
                                Console.WriteLine("Select the service: ");
                                Console.WriteLine("1.RTGS\n 2.IMPS\n");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                Services services = (Services)Convert.ToInt32(ch);
                                amount *= currency[curr];
                                if (services == Services.RTGS)
                                {
                                    amount -= (SameBankRGTSCharge / 100);
                                }
                                else if (services == Services.IMPS)
                                {
                                    amount -= (SameBankSIMPSCharge / 100);
                                }

                                Console.WriteLine(bankServices.Deposit(bankId,accountNo, password, amount));
                                break;
                            }
                        case UserOptions.witdraw:
                            {

                                Console.WriteLine("Enter the BankId: ");
                                String bankId = Console.ReadLine();
                                Console.WriteLine("Enter Account Number: ");
                                string accountNo = Console.ReadLine();
                                Console.WriteLine("Enter your pin: ");
                                string password = Console.ReadLine();
                                Console.WriteLine("Enter Amount to withdraw: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Enter the currency:\n" +
                                    "such as $,Rs,etc...");
                                string curr = Console.ReadLine();
                                Console.WriteLine("Select the service: ");
                                Console.WriteLine("1.RTGS\n 2.IMPS\n");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                Services services = (Services)Convert.ToInt32(ch);
                                amount *= currency[curr];
                                if (services == Services.RTGS)
                                {
                                    amount -= (SameBankRGTSCharge / 100);
                                }
                                else if (services == Services.IMPS)
                                {
                                    amount -= (SameBankSIMPSCharge / 100);
                                }
                                Console.WriteLine(bankServices.Withdraw(bankId, accountNo, password, amount));
                                break;
                            }
                        case UserOptions.transferAmount:
                            {
                                Console.WriteLine("Enter your BankId: ");
                                String sourcebankId = Console.ReadLine();
                                Console.WriteLine("Enter your Account Number: ");
                                string sourceAccountNo = Console.ReadLine();
                                Console.WriteLine("Enter destination BankId: ");
                                String destinationbankId = Console.ReadLine();
                                Console.WriteLine("Enter receiver Account Number: ");
                                string destinationAccountNo = Console.ReadLine();
                                Console.WriteLine("Enter your pin: ");
                                string password = Console.ReadLine();
                                Console.WriteLine("Enter Amount to transfer: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());
                                Console.WriteLine("Enter the currency:\n" +
                                    "such as $,Rs,etc...");
                                string curr = Console.ReadLine();
                                Console.WriteLine("Select the service: ");
                                Console.WriteLine("1.RTGS\n 2.IMPS\n");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                Services services = (Services)Convert.ToInt32(ch);
                                amount  *= currency[curr];
                                if(sourcebankId == destinationbankId && services == Services.RTGS)
                                {
                                    amount -= (SameBankRGTSCharge / 100); 
                                }
                                else if(sourcebankId == destinationbankId && services == Services.IMPS)
                                {
                                    amount -= (SameBankSIMPSCharge / 100);
                                }
                                else if(sourcebankId != destinationbankId && services == Services.RTGS)
                                {
                                    amount -= (OtherBankRGTSCharge / 100);
                                }
                                else if(sourcebankId != destinationbankId && services == Services.IMPS)
                                {
                                    amount -= (OtherBankIMPSCharge / 100);
                                }

                                Console.WriteLine(bankServices.TransferAmount(sourcebankId,sourceAccountNo, destinationAccountNo, password, amount));

                                break;
                            }
                        case UserOptions.transactionHistory:
                            {
                                Console.WriteLine("Enter your Account Number: ");
                                string sourceAccountNo = Console.ReadLine();
                                Console.WriteLine("Enter your password: ");
                                string password = Console.ReadLine();

                                var transactionAccount = bankServices.TransactionHistory(sourceAccountNo, password);
                                if (transactionAccount != null)
                                {
                                    foreach (var account in transactionAccount)
                                    {
                                        Console.WriteLine(".......Transaction History......\n" +
                                            "from:        " + account.SourceAcccountId + "\n" +
                                            "to:          " + account.DestinationAccountId + "\n" +
                                            "description: " + account.Type + "\n" +
                                            "time:        " + account.Time + "\n");
                                    }
                                } else
                                {
                                    Console.WriteLine("Invald Password!!");
                                }
                                break;
                            }
                        case UserOptions.exit:
                            {
                                Console.WriteLine("Thank you for using our aplication!!!");
                                break;
                            }

                    }
                } while (userOptions != UserOptions.exit);
            } else
            {
                Console.WriteLine("Invalid Option!!!");
            }
        }
    }
}
