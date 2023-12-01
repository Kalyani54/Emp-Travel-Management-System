using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2_DAL
{
    public interface IEMP_DAL
    {
        int AddEmployee_DAl(int EmpId, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB);

        int DeleteEmployee_DAl(int EmpId);

        int EditEmployee_DAl(Employee2 emp);
        void ViewEmployee_DAL();

        Employee2 GetEmployeeById_DAL(int EmpId);
    }
}
