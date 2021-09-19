
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
using System.Data.Odbc;


namespace CapaVista
{
    public partial class Form1 : Form
    {
        clsControlador logi = new clsControlador();
        public Form1()
        {
            InitializeComponent();
            cargardatos();
        }

        void cargardatos()
        {
            //combo1.llenarse("empleado", "codigo_empleado", "puesto");
            combo1.llenarse("empleado", "codigo_empleado", "nombre_completo");
        }

        public void mostrar_consulta()
        {
            OdbcDataReader mostrar = logi.consultar("empleado"); //envia el nombre de la tabla pa mostrar contenido
            try
            {


                while (mostrar.Read())
                    dgvCamposSeleccionados.Rows.Add(mostrar.GetString(0), mostrar.GetString(1), mostrar.GetString(2)); //anade fila con estos datos

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dgvCamposSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarCamposSeleccionados_Click(object sender, EventArgs e)
        {
            dgvCamposSeleccionados.Rows.Clear();
            mostrar_consulta();
        }
    }
}
