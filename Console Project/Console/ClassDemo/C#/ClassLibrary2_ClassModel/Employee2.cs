
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2_ClassModel
{
    public class Employee2
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Contact { get; set; }

        public string Address { get; set; }

        public string Dept { get; set; }

        public DateTime DOB { get; set; }

        // public Employee(int EmpId,string FirstName,string LastName,int Contact,string Address,string Dept,DateTime DOB) 
        //  {
        //    this.EmpId = EmpId;
        //   this.FirstName = FirstName;
        //    this.LastName = LastName;
        //   this.Contact = Contact;
        //   this.Address = Address;
        //   this.Dept = Dept;
        //   this.DOB = DOB;
        //  }

        public override string ToString()
        {
            return string.Format("Id: {0}, FirstName: {1}, LastName :{2}, Contact :{3}, Address :{4}, Dept :{5}, DOB: {6}",
                EmpId, FirstName, LastName, Contact, Address, Dept, DOB);
        }
    }
}
//hjhjh

