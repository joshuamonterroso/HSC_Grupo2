using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class clsSentencias
    {
        clsConexion cn = new clsConexion(); //crear objeto
        OdbcCommand com; //variable para querys

        public OdbcDataReader consulta(string tabla)
        {
            try
            {
                cn.conexion();
                string consulta = "SELECT * FROM " + tabla + ";";
                com = new OdbcCommand(consulta, cn.conexion());
                OdbcDataReader respuesta = com.ExecuteReader();
                return respuesta;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
    }
}
