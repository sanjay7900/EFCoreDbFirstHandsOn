using EFCoreDbFirstClassLibraryFile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDbFirstClassLibraryFile
{
    public class CRUDoperations
    {
        EfCoreDbFirstContext efCoreDbFirstContext;
        public CRUDoperations()
        {
            efCoreDbFirstContext=new EfCoreDbFirstContext();    
        }

        public void InsertDataOFEmployeeANdItsEducation(Employee employee,List<EmployeeEducation> EduList)
        {
            var addemp = new Employee
            {
                EmpName = employee.EmpName,
                EmpAddress = employee.EmpAddress,
                EmployeeEducations = EduList
            };
            efCoreDbFirstContext.Employees.Add(addemp);
            efCoreDbFirstContext.SaveChanges();
            Console.WriteLine("Employee Successfully Added...");
        }
        public void DeleteEmployeeById(int Id)
        {
            var employee = efCoreDbFirstContext.Employees.Where(emp => emp.EmpId == Id).Include(edu => edu.EmployeeEducations).FirstOrDefault();
            if(employee != null)
            {
                employee.EmployeeEducations.Clear();
                efCoreDbFirstContext.Employees.Remove(employee);
                efCoreDbFirstContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("record not found...");
            }
        }

        public void UpdateEmployee(int id,string empname,string empaddress,List<EmployeeEducation> updateEducation)
        {
            var updateemp = efCoreDbFirstContext.Employees.Where(emp => emp.EmpId == id).Include(e => e.EmployeeEducations).FirstOrDefault();
            if(updateemp != null)
            {
                updateemp.EmpName = empname;
                updateemp.EmpAddress = empaddress;
                updateemp.EmployeeEducations=updateEducation;
                efCoreDbFirstContext.Employees.Update(updateemp);
                efCoreDbFirstContext.SaveChanges();
                Console.WriteLine("Updated...");
            }
            else
            {
                Console.WriteLine("No Record Available For The ID "+id);
            }
        }
        public void ShowAllEmployee()
        {
            var getAllEmp= efCoreDbFirstContext.Employees.Include(e=>e.EmployeeEducations).ToList();    
           if(getAllEmp != null)
            {
                foreach (var emp in getAllEmp)
                {
                    Console.WriteLine("Employee Name :" + emp.EmpName);
                    Console.WriteLine("Employee Address : " + emp.EmpAddress);
                    Console.WriteLine();
                    Console.WriteLine("Employee Education :");
                    foreach (var edu in emp.EmployeeEducations)
                    {
                        Console.WriteLine("     Employee Educations :" + edu.EducationName);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------");
                }

            }
            else
            {
                Console.WriteLine("No Record Found...");
            }
        }
    }
}
