using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    class Employee
    {
        static int Id = 0;

        public string Name { get; set; }

        public string EmployeeId { get; set; }

        public string Password { get; set; }

        public Employee(string Name, string EmployeeId,string Password )
        {
            Id = Id + 1;
            this.Name = Name;
            this.EmployeeId = EmployeeId;
            this.Password = Password;
        }
    }

    
}
