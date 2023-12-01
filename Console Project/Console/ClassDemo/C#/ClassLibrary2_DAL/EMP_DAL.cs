using ClassLibrary2_ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary2_DAL
{
    public class EMP_DAL : IEMP_DAL
    {

        public List<Employee2> lstEmployees = new List<Employee2>()
        {
            new Employee2(){EmpId=1, FirstName="Sushant", LastName="Rajput", Contact=78788787, Address="Mumbai", Dept="IT", DOB=DateTime.Parse("01-01-2000")},
            new Employee2(){EmpId=2, FirstName="Komal", LastName="Khalokar", Contact=788865445, Address="Delhi", Dept="AIDS", DOB=DateTime.Parse("10-12-1999")},
            new Employee2(){EmpId=3, FirstName="Riya", LastName="Thakur", Contact=987676545, Address="Nagpur", Dept="CSE", DOB=DateTime.Parse("21-03-2001")},
            new Employee2(){EmpId=4, FirstName="Ram", LastName="Pajai", Contact=87665565, Address="Goa", Dept="Data Science", DOB=DateTime.Parse("05-08-2002")}
        };
        public int AddEmployee_DAl(int EmpId, string FirstName, string LastName, int Contact, string Address, string Dept, DateTime DOB)
        {
            // Employee emp=new Employee(EmpId, FirstName, LastName, Contact, Address, Dept, DOB);

            //  Console.WriteLine(emp.ToString());
            foreach(Employee2 ep in lstEmployees)
            {
                if(ep.EmpId == EmpId)
                {
                    Console.WriteLine("Employee Id already exists.Add another.");
                    return 0;
                }
            }

            lstEmployees.Add(new Employee2() { EmpId = EmpId, FirstName = FirstName, LastName = LastName, Contact = Contact, Address = Address, Dept = Dept, DOB = DOB });
            return 1;
        }

        public int EditEmployee_DAl(Employee2 modifiedEmp)
        {
            Employee2 emp_Main = lstEmployees.FirstOrDefault(X => X.EmpId == modifiedEmp.EmpId);
            if (emp_Main == null)
            {
                Console.WriteLine("Employee ID does not exist. Please enter a valid Employee ID.");
                return 0;
            }

            int index = lstEmployees.IndexOf(emp_Main);

            lstEmployees[index].FirstName = modifiedEmp.FirstName;
            lstEmployees[index].LastName = modifiedEmp.LastName;
            lstEmployees[index].Contact = modifiedEmp.Contact;
            lstEmployees[index].Address = modifiedEmp.Address;
            lstEmployees[index].Dept = modifiedEmp.Dept;
            lstEmployees[index].DOB = modifiedEmp.DOB;



            return 1;
        }

        public int DeleteEmployee_DAl(int EmpId)
        {


            Employee2 emp = lstEmployees.FirstOrDefault(e => e.EmpId == EmpId);
            if (emp != null)
            {
                lstEmployees.Remove(emp);
                Console.WriteLine("Data deleted successfully...");
            }
            else
            {
                Console.WriteLine("Employee Id not found");
            }
            ViewEmployee_DAL();
            return 1;
        }

        public void ViewEmployee_DAL()
        {
            Console.WriteLine("                                         ********** Employees Details  **********");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} | {6,-20}", " EmpId ", "FirstName", "LastName", " Contact", "Address", " Dept", " DOB");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Employee2 emp in lstEmployees)
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} | {6,-20}",
                    emp.EmpId, emp.FirstName, emp.LastName, emp.Contact, emp.Address, emp.Dept, emp.DOB);
            }
        }


        public Employee2 GetEmployeeById_DAL(int id)
        {
            Employee2 emp = lstEmployees.FirstOrDefault(e => e.EmpId == id);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }

    }
}
