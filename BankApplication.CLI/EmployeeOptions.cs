using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.CLI
{
    public enum EmployeeOptions
    {
        CreateAccount = 1,
        UpdateAccount,
        DeleteAccount,
        AddCurrency,
        AddServiceCharge,
        ViewTransactionHistory,
        RevertTransaction,
        Exit
    }
}
