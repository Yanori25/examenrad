using Examen.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen.Controlador
{
    class VehiculoController
    {
        public VehiculoController() { }

        public DataTable Getcolor()
        {
            SqlConnection Con = new Conexion().GetConexion("BDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Colorshow", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dataTable);


            Con.Close();
            return dataTable;


        }


        public DataTable Getmarca()
        {
            SqlConnection Con = new Conexion().GetConexion("BDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Marcasshow", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dataTable);


            Con.Close();
            return dataTable;


        }


        public DataTable Getmodelo()
        {
            SqlConnection Con = new Conexion().GetConexion("BDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Modeloshow", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dataTable);


            Con.Close();
            return dataTable;


        }



        public DataTable GetVehiculo()
        {
            SqlConnection Con = new Conexion().GetConexion("BDConexion");
            Con.Open();




            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Vehiculoshow", Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dataTable);


            Con.Close();
            return dataTable;


        }

        public bool Crear(VehiculoModelo model)
        {
            try
            {
                using (SqlConnection Con = new Conexion().GetConexion("BDConexion"))
                {
                    Con.Open();

                    string sql = "execute vehiculoeventos "
                        + model.ind + " , "
                    + model.IdVehiculo + " , '"
                    + model.descripcion + "' , "
                    + model.idmarcar + " , "
                    + model.idmodelo + " , "
                    + model.idcolor + " ,  "
                    + model.precio + " , "
                    + model.anio + " , '"
                    + model.motor + "' ,  '"
                    + model.ruedas + "' "

                    ;


                    using (SqlCommand cmd = new SqlCommand(sql, Con))
                    {
                        cmd.CommandTimeout = 600;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Se agrego exitosamente");

                    Con.Close();
                }

                return true;
            }
            catch (Exception errores)
            {
                MessageBox.Show(errores.Message, "Informacion del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

    }
}
