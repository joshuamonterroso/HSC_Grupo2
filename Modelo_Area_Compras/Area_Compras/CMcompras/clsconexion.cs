using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CMcompras
{
    class clsconexion
    {
        public OdbcConnection conexion()
        {
            //creacion de la conexion via ODBC
            //Adolfo Monterroso 0901-18-50 09/10/2021
            OdbcConnection conn = new OdbcConnection("Dsn=Prueba");
            try
            {
                conn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("NO Conectó");
            }
            return conn;
        }
        //metodo para cerrar la conexion
        //Adolfo Monterroso 0901-18-50 09/10/2021
        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }
    }
}
