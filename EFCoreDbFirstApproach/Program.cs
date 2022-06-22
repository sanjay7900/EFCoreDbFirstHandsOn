using EFCoreDbFirstClassLibraryFile;
using EFCoreDbFirstClassLibraryFile.Models;

namespace EFCoreDbFirstApproach
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Employee employee = new Employee { EmpName="sanjay", EmpAddress="Jhajhar"};
            List<EmployeeEducation> Educationlist = new List<EmployeeEducation>();
            Educationlist.Add(new EmployeeEducation { EducationName="BCA"});
            Educationlist.Add(new EmployeeEducation { EducationName="MCA"});
            CRUDoperations  cRUDoperations = new CRUDoperations();
            cRUDoperations.InsertDataOFEmployeeANdItsEducation(employee, Educationlist);
            cRUDoperations.DeleteEmployeeById(1);
            cRUDoperations.ShowAllEmployee();
            cRUDoperations.UpdateEmployee(3, "Rahul Sharama", "Mathura", new List<EmployeeEducation> { new EmployeeEducation { EducationName = "BCA" }, new EmployeeEducation { EducationName = "MCA" } });
            Console.ReadLine();


                
        }
    }
}