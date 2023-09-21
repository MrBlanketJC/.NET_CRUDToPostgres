using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Npgsql;
using CAE;

namespace CAD
{
    //CLase que hereda de ConnectionToPostgreSQL
    public class EmployeesData: ConnectionToPostgreSQL
    {
        //Listar
        public List<EmployeesEntity> GetAllEmployees()
        {
            List<EmployeesEntity> misListas = new List<EmployeesEntity>();

            using(var connection = GetConnection())
            {
                connection.Open();
                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from empleados";
                    cmd.CommandType = System.Data.CommandType.Text;
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            EmployeesEntity miLista = new EmployeesEntity();

                            miLista.IDEmpleados = reader.GetInt32(0);
                            miLista.Apellidos = reader.GetString(1);
                            miLista.Nombres = reader.GetString(2);
                            miLista.Telefonos = reader.GetString(3);
                            miLista.Correo = reader.GetString(4);
                            miLista.Provincia = reader.GetString(5);
                            miLista.Canton = reader.GetString(6);
                            miLista.Direccion = reader.GetString(7);
                            miLista.Estado = reader.GetBoolean(8);
                            misListas.Add(miLista);
                        }
                    }
                }
            }

            return misListas;
        }
    }
}
