
using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2_ClassModel;

namespace ClassLibrary2_BAL
{
    public interface IEMP_BAL
    {
        void ViewEmployee_BAL();

        int DeleteEmployee_BAl(int EmpId);

        int AddEmployee_BAl(int EmpId, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB);

        Employee2 GetEmployeeById_BAL(int EmpId);

        void EditEmployee_BAL(Employee2 emp_to_change);
    }
}
