using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaControlador
{
   public  class clsControlador
    {
        clsSentencias sn = new clsSentencias();
        public OdbcDataReader consultar(string tabla)
        {
            return sn.consulta(tabla);
        }
    }
}
