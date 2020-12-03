using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosConexionDB
    {
        #region Atributos
        public SqlConnection conexion;
        public string cadenaConexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = DBMercado; Integrated Security = True";
        #endregion

        #region Constructor
        public DatosConexionDB()
        {
            conexion = new SqlConnection(cadenaConexion);

        }
        #endregion
        #region metodos
        public void Abrirconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Broken || conexion.State ==
                 ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de abrir la conexion", e);
            }
        }

        public void Cerrarconexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }

        #endregion

    }
}

