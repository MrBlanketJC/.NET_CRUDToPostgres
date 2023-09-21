using System.Collections.Generic;
//
using CAD;
using CAE;

namespace CAM
{
    //Public
    public class EmployeesManager
    {
        EmployeesData employeesD = new EmployeesData();

        //Listar
        public List<EmployeesEntity> GetAll(bool pointer, string Filter)
        {
            return employeesD.GetAllEmployees(pointer, Filter);
        }

        //Listar uno
        public List<EmployeesEntity> GetEmployeeByID(int IDEmpleado)
        {
            return employeesD.GetEmployeeByID(IDEmpleado);
        }

        //Insertar
        public bool Insert(string Apellidos, string Nombres, string Telefono, string Correo, string Provincia, string Canton, string Direccion)
        {
            return employeesD.InsertEmployee(Apellidos, Nombres, Telefono, Correo, Provincia, Canton, Direccion);
        }

        //Editar
        public bool Update(int IDEmpleado, string Apellidos, string Nombres, string Telefono, string Correo, string Provincia, string Canton, string Direccion)
        {
            return employeesD.UpdateEmployee(IDEmpleado, Apellidos, Nombres, Telefono, Correo, Provincia, Canton, Direccion);
        }

        //Eliminar
        //Editar
        public bool Delete(int IDEmpleado)
        {
            return employeesD.DeleteEmployee(IDEmpleado);
        }
    }
}
