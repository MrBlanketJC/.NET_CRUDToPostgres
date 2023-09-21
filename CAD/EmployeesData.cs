using System.Collections.Generic;
//
using Npgsql;
using CAE;

namespace CAD
{
    //CLase que hereda de ConnectionToPostgreSQL
    public class EmployeesData: ConnectionToPostgreSQL
    {
        //Listar todo
        public List<EmployeesEntity> GetAllEmployees(bool pointer, string Filter)
        {
            List<EmployeesEntity> misListas = new List<EmployeesEntity>();

            using(var connection = GetConnection())
            {
                connection.Open();
                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;

                    cmd.CommandText = (pointer) ? "select * from empleados where ((apellidos ilike '%" + Filter + "%' or nombres ilike '%" + Filter + "%') and estado=true)" : "select * from empleados order by idempleados desc";
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

        //Listar uno
        public List<EmployeesEntity> GetEmployeeByID(int IDEmpleado)
        {
            List<EmployeesEntity> misListas = new List<EmployeesEntity>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from empleados where idempleados=@idempleados";
                    cmd.Parameters.AddWithValue("@idempleados", IDEmpleado);
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

        //Insertar
        public bool InsertEmployee(string Apellidos, string Nombres, string Telefono, string Correo, string Provincia, string Canton, string Direccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into empleados (apellidos, nombres, telefonos, correo, provincia, canton, direccion, estado)" +
                        "values (@apellidos, @nombres, @telefono, @correo, @provincia, @canton, @direccion, true)";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", Nombres);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@correo", Correo);
                    cmd.Parameters.AddWithValue("@provincia", Provincia);
                    cmd.Parameters.AddWithValue("@canton", Canton);
                    cmd.Parameters.AddWithValue("@direccion", Direccion);
                    var ok = cmd.ExecuteNonQuery();
                    return (ok == 1) ? true : false;
                }
            }
        }

        //Actualizar
        public bool UpdateEmployee(int IDEmpleado, string Apellidos, string Nombres, string Telefono, string Correo, string Provincia, string Canton, string Direccion)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "update empleados set apellidos=@apellidos, nombres=@nombres, telefonos=@telefono, correo=@correo, provincia=@provincia, canton=@canton, direccion=@direccion where idempleados=@idempleados";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@idempleados", IDEmpleado);
                    cmd.Parameters.AddWithValue("@apellidos", Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", Nombres);
                    cmd.Parameters.AddWithValue("@telefono", Telefono);
                    cmd.Parameters.AddWithValue("@correo", Correo);
                    cmd.Parameters.AddWithValue("@provincia", Provincia);
                    cmd.Parameters.AddWithValue("@canton", Canton);
                    cmd.Parameters.AddWithValue("@direccion", Direccion);
                    var ok = cmd.ExecuteNonQuery();
                    return (ok == 1) ? true : false;
                }
            }
        }

        //Delete
        public bool DeleteEmployee(int IDEmployee)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText= "update empleados set estado = false where idempleados=@idempleados";
                    cmd.Parameters.AddWithValue("@idempleados", IDEmployee);
                    var ok = cmd.ExecuteNonQuery();
                    return (ok == 1) ? true: false;
                }
            }
        }
    }
}
