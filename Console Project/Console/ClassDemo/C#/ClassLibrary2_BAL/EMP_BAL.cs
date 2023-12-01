using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2_ClassModel;
using ClassLibrary2_DAL;

namespace ClassLibrary2_BAL
{
    public class EMP_BAL : IEMP_BAL
    {

        private static readonly EMP_DAL employee = new EMP_DAL();
        public void ViewEmployee_BAL()
        {


            employee.ViewEmployee_DAL();
        }

        public int DeleteEmployee_BAl(int EmpId)

        {

            employee.DeleteEmployee_DAl(EmpId);

            return 1;
        }

        public int AddEmployee_BAl(int EmpId, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB)
        {

            employee.AddEmployee_DAl(EmpId, FirstName, LastName, Contact, Address, Dept, DOB);
            return 1;
        }

        public Employee2 GetEmployeeById_BAL(int EmpId)
        {

            Employee2 emp = employee.GetEmployeeById_DAL(EmpId);
            return emp;
        }

        public void EditEmployee_BAL(Employee2 emp_to_change)
        {

            employee.EditEmployee_DAl(emp_to_change);
        }
    }
}
