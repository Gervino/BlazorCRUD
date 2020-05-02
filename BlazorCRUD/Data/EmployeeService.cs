using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get All Employees
        public List<EmployeeInfo> GetEmployee()
        {
            var emplist = _db.Employees.ToList();
            return emplist;
        }

        //Insert employe info
        public string Create(EmployeeInfo objEmp)
        {
            if (objEmp != null)
            {
                _db.Employees.Add(objEmp);
                _db.SaveChanges();
                return "Save Successfully";
            }
            else
            {
                return "Employee is NULL, save Failed...";
            }
        }

        //Get Employe by id
        public EmployeeInfo GetEmployeeById(long id)
        {
            EmployeeInfo employee = _db.Employees.FirstOrDefault(m => m.EmployeeId == id);
            return employee;
        }
        //Update Employee info
        public string UpdateEmployee(EmployeeInfo newEmp)
        {
            string result = "";
            if (newEmp != null)
            {
                result = "Update Successfully";
                _db.Employees.Update(newEmp);
                _db.SaveChanges();
                return result;
            }
            else
            {
                result = "Update Failed...";
                return result;
            }
        }

        //delete employe

        public string DeleteEmployee(EmployeeInfo deleteEmp)
        {
            string  result = "";
            
            if(deleteEmp != null)
            {
                _db.Employees.Remove(deleteEmp);
                //_db.Remove(deleteEmp);
                _db.SaveChanges();
                result = "Delete successsfully";
                return result;
            }
            else
            {
                result = "Delete Failed...";
                return result;
            }
            
        }
    }
}
