using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Modelo
{
    internal class Conexion
    {
        public Conexion() { }


        public SqlConnection GetConexion(string Conexion)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[Conexion].ToString());
        }

    }
}
