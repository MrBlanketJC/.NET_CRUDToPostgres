using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<EmployeesEntity> GetAll()
        {
            return employeesD.GetAllEmployees();
        }
    }
}
