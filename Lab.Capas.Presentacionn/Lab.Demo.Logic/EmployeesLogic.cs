using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    class EmployeesLogic : BaseLogic, ILogic<Employees>
    {
        public void Delete(int id)
        {
            Employees employeeToDelete = GetOne(id);
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employees GetOne (int id)
        {
            return context.Employees.FirstOrDefault(r => r.EmployeeID.Equals(id));
        }

        public Employees Insert(Employees entity)
        {
            int lastId = (from emp in context.Employees
                          orderby emp.EmployeeID descending
                          select emp.EmployeeID).FirstOrDefault();
            lastId += 1;

            Employees newEmployee = context.Employees.Add(entity);
            context.SaveChanges();
            return newEmployee;
        }

        public void Update(Employees entity)
        {
            Employees employeToEdit = GetOne(entity.EmployeeID);
            employeToEdit.FirstName = entity.FirstName;
            employeToEdit.LastName = entity.LastName;
            context.SaveChanges();
        }
    }

    
}
