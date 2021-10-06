using System;
using BankApp.Services;

namespace BankApplication.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BankServices bankServices = new BankServices();
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
                            Console.WriteLine("Enter your pin: ");
                            int p = Convert.ToInt32(Console.ReadLine());
                            int acNo = bankServices.addAccount(name, p);
                            if (acNo != 0)
                            {
                                Console.WriteLine("Account created Successfully");
                                Console.WriteLine("Your Account Number is: " + acNo);
                            }
                            break;
                        }
                    case UserOptions.displayAccounts:
                        {
                            foreach (var acc in bankServices.accounts)
                            {
                                Console.WriteLine("Accounts: {0},{1},{2},{3}", acc.accNo, acc.accName, acc.pin, acc.bal);
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
        }

        public enum UserOptions
        {
            createAccount=1,
            deposite,
            witdraw,
            displayAccounts,
            exit
        }
    }
}
