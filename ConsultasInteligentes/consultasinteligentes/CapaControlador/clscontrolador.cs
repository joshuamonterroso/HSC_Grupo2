using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;
using System.Data;
using System.Data.Odbc;

namespace CapaControlador
{
    public class clscontrolador
    {
        clsSentencias sn = new clsSentencias();
        //Llenar una tabla capa controlador
        public DataTable llenartb1(string tabla)
        {
            OdbcDataAdapter dt = sn.llenartb1(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public OdbcDataReader llenarcbo()
        {
            string sql = "show full tables from prototipo_area_compras;";
            return sn.llenarcbotabla(sql);
        }

        public OdbcDataReader llenarcbo2(string tabla)
        {
            string sql = "show columns from "+ tabla +";";
            return sn.llenarcbotabla(sql);
        }

        public OdbcDataReader llenarcboq(string tabla)
        {
            string sql = "select nombre, consulta from " + tabla + ";";
            return sn.llenarcbotabla(sql);
        }
        public void ingresarconsulta(string nombre, string consulta)
        {
            string sql = "insert into registro_consultas (nombre,consulta) values ( '"+nombre+"', '"+consulta+  "') ;";
            Console.WriteLine(sql);
            sn.insertarconsulta(sql);
        }
        
    }

}
