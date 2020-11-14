using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    public class EmployeesLogic : BaseLogic, ILogic<Employees>
    {
        public void Delete(int id)
        {
            Employees employeeToDelete = GetOne(id);
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            List<Employees> result = new List<Employees>();
            try
            {
                result = context.Employees.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar todos los empleados");
            }

            return result;
        }

        public Employees GetOne(int id)
        {
            return context.Employees.FirstOrDefault(r => r.EmployeeID.Equals(id));
        }

        public Employees Insert(Employees entity)
        {
            int lastId = (from emp in context.Employees
                          orderby emp.EmployeeID descending
                          select emp.EmployeeID).FirstOrDefault();
            lastId += 1;
            entity.EmployeeID = lastId;
           
                Employees newEmployee = context.Employees.Add(entity);
            try
            {
                context.SaveChanges();
            }
            catch (Exception) {
                throw new Exception("algo mal ocurrio");
            }
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
