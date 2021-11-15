using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Models
{
    public class Employee
    {
        //static int Id = 0;

        public string Name { get; set; }

        public string EmployeeId { get; set; }

        public string Password { get; set; }

        public string Designation { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        // designation,contact,address

        public Employee(string Name, string EmployeeId,string Password,string Designation, String ContactNo, String Address)
        {
           // Id = Id + 1;
            this.Name = Name;
            this.EmployeeId = EmployeeId;
            this.Password = Password;
            this.Designation = Designation;
            this.ContactNo = ContactNo;
            this.Address = Address;
        }
    }

    
}
