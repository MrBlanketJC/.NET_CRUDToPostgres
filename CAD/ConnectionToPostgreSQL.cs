using Npgsql;
using System.Runtime.InteropServices;

namespace CAD
{
    //clase abstracta solo puede ser instanciada como una clase base
    public abstract class ConnectionToPostgreSQL
    {
        private readonly string _connectionString;

        //Constructor
        public ConnectionToPostgreSQL()
        {
            string servidor = "localhost";
            string db = "Nexus";
            string usuario = "postgres";
            string password = "12345";
            string puerto = "5432";

            _connectionString = "server=" + servidor + "; port=" + puerto + "; user id =" + usuario + "; password=" + password + "; database=" + db + ";";
        }

        //Creamos metodo protegido para obtener la conexion, solo acceder desde una clase derivada
        protected NpgsqlConnection GetConnection()
        {
            //retornar instancia de SQLConecction y enviamos parametro la cadena
            return new NpgsqlConnection(_connectionString);
        }
    }
}
