using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCcompras;
using System.Data.Odbc;

namespace CVcompras
{
    public partial class Area_Compras : Form
    {
        clscontrolador cn = new clscontrolador();
        public Area_Compras()
        {
            InitializeComponent();
        }

     //Direccionamiento de formularios desde mdi
     //Adolfo Monterroso 0901-18-50 09/10/2021

        private void Area_Compras_Load(object sender, EventArgs e)
        {

        }

        private void ingresarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new Ingreso_Proveedores();
            formulario.Show();
            this.Hide();
        }

        private void ingresarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formulario = new Ingreso_Compra();
            formulario.Show();
            this.Hide();
        }
    }
}
