using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo
{
    public class clsSentencias
    {
        //Obtener datos de una tabla capa Modelo
        clsconexion con = new clsconexion();
        public OdbcDataAdapter llenartb1(string tabla) //Metodo que obtiene el contenido de una tabla
        {
            string sql = tabla;
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());
            return datatable;
        }

        public OdbcDataReader llenarcbotabla(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, con.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public void insertarconsulta(string cadena)
        {
        try
            {
                OdbcCommand consulta = new OdbcCommand(cadena, con.conexion());
                consulta.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo" + Error);
            }
        }

        public OdbcDataReader validarconsulta(string sql)
        {
            try
            {
                OdbcCommand datos = new OdbcCommand(sql, con.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public OdbcDataAdapter llenartb2(string sql) //Metodo que obtiene el contenido de una tabla
        {
            OdbcDataAdapter datatable = new OdbcDataAdapter(sql, con.conexion());
            return datatable;
        }

    }
}
