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
    public partial class ConsultasInteligentes : Form
    {
        string campo = "";
        string csimple = "";
        string where = "";
        string and = "";
        string group = "";
        string final = "";
        string orden = "";
        string validar = "";
        public ConsultasInteligentes()
        {
            InitializeComponent();
        }

        private void btnCancelarCamposSeleccionados_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitaciones();
        }
        clscontrolador cn = new clscontrolador();

        private void ConsultasInteligentes_Load(object sender, EventArgs e)
        {
            llenarcombo();
            llenarcboquery();           
        }

        string consulta = "";
        public void actualizardatagrid()
        {
            DataTable dt = cn.llenartb1(consulta);
            dgvCONSULTAS.DataSource = dt;
        }
        public void llenarcombo()
        {
            cboTabla.Items.Clear();
            OdbcDataReader datareader = cn.llenarcbo();
            while (datareader.Read())
            {
                cboTabla.Items.Add(datareader[0].ToString());
            }
        }

        public void llenarcboinsert(string prueba)
        {
                cbovalidar.Items.Clear();
                OdbcDataReader dataReader = cn.llenarinsert(prueba);
                    while (dataReader.Read())
                    {
                        cbovalidar.Items.Add(dataReader[0].ToString());
                    }
        }
        public void llenarcombo2()
        {
            cboCampos.Items.Clear();
            cboCampoLogica.Items.Clear();
            cboCampoComparacion.Items.Clear();
            cboCampoAgruparOrdenar.Items.Clear();
            OdbcDataReader datareader = cn.llenarcbo2(valortabla.Text);
            while (datareader.Read())
            {
                cboCampos.Items.Add(datareader[0].ToString());
                cboCampoLogica.Items.Add(datareader[0].ToString());
                cboCampoComparacion.Items.Add(datareader[0].ToString());
                cboCampoAgruparOrdenar.Items.Add(datareader[0].ToString());
            }
        }

        string query = "registro_consultas";
        public void llenarcboquery()
        {
            cboQuery.Items.Clear();
            cbocopiaquery.Items.Clear();
            OdbcDataReader datareader = cn.llenarcboq(query);
            while (datareader.Read())
            {
                cboQuery.Items.Add(datareader[0].ToString());
                cbocopiaquery.Items.Add(datareader[1].ToString());
            }
        }
        private void cboTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
           valortabla.Text = cboTabla.SelectedItem.ToString();
            llenarcombo2();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (chkSelectTodos.Checked == false)
            {            
                if (txtcamposelectos.Text.Equals(""))
                {
                    if (txtAlias.Text.Equals(""))
                    {
                        txtcamposelectos.Text = "";
                        campo = campo + cboCampos.SelectedItem.ToString() + " ";
                        txtcamposelectos.Text = campo;
                    } else
                    {
                        txtcamposelectos.Text = "";
                        campo = campo + cboCampos.SelectedItem.ToString() + " as "+ txtAlias.Text +" ";
                        txtcamposelectos.Text = campo;
                    }
                }
                else{
                    if (txtAlias.Text.Equals(""))
                    {
                        txtcamposelectos.Text = "";
                        campo =  campo +", " + cboCampos.SelectedItem.ToString() + " ";
                        txtcamposelectos.Text = campo;
                    }
                    else
                    {
                        txtcamposelectos.Text = "";
                        campo =  campo + ", " + cboCampos.SelectedItem.ToString() + " as " + txtAlias.Text + " ";
                        txtcamposelectos.Text = campo;
                    }
                }
            } else
            {
                txtcamposelectos.Text = "";
                campo = "";
                campo = " * ";
                txtcamposelectos.Text = "Todos los campos seleccionados";
                Console.WriteLine(campo);
            }
        }

        private void chkSelectTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectTodos.Checked == true)
            {
                txtAlias.Text = "";
                txtAlias.Enabled = false;
                cboCampos.Text = "";
                cboCampos.Enabled = false;
                txtcamposelectos.Text = "";
            } else
            {
                txtAlias.Text = "";
                txtAlias.Enabled = true;
                cboCampos.Text = "";
                cboCampos.Enabled = true;
            }
        }
        private void btprueba_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkcondiciones_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkcondiciones.Checked == true) && (csimple !=""))
            {
                gpbConsultaCompleja.Enabled = true;
                gpbAgruparUOrdenar.Enabled  = true;
            } else
            {
                gpbConsultaCompleja.Enabled =  false;
                gpbAgruparUOrdenar.Enabled  =  false;
                MessageBox.Show("Debe seleccionar campos");
                chkcondiciones.Checked = false;
            }
        }

        private void btnAgregarCamposSeleccionados_Click(object sender, EventArgs e)
        {
            csimple = "SELECT " + campo + "FROM " + valortabla.Text + " " ;
            MessageBox.Show("La cadena generada es: " + csimple);
            Console.WriteLine(csimple);
            txtCadenaGenerada.Text = csimple;
            campo = "";
            txtAlias.Text = "";
            cboCampos.Text = "";         
            txtcamposelectos.Text = "";
            cboTabla.Text = "";
            chkSelectTodos.Checked = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Boton de crear
            final = csimple + " " + where + " " + and + " " + group + " ;";
            MessageBox.Show("La consulta Generado fue: " + final);
            llenarcboinsert(final);
            validar = cbovalidar.Items[0].ToString();

            if (validar == "")
            {
                MessageBox.Show("Consulta invalida, el valor de validar es: "+ validar);
            } else
            {
                MessageBox.Show("Validar es " + validar);
                cn.ingresarconsulta(txtNombreConsulta.Text, final);
                llenarcboquery();
                limpiar();
                habilitaciones();

            }
        }

        public void limpiar()
        {
            chkcondiciones.Checked = false;
            txtCadenaGenerada.Text = "";
            txtcamposelectos.Text = "";
            txtAlias.Text = "";
            txtNombreConsulta.Text = "";
            valortabla.Text = "";
            txtValor.Text = "";
            txtValorComparacion.Text = "";
            cboAgruparOrdenar.Text = "";
            cboCampos.Text = "";
            cboTabla.Text = "";
            cboOperadorLogico.Text = "";
            cboCampoLogica.Text = "";
            cboTipoComparador.Text = "";
            cboCampoComparacion.Text = "";
            cboCampoAgruparOrdenar.Text = "";
            campo = "";
            csimple = "";
            where = "";
            and = "";
            group = "";
            final = "";
            validar = "";
        }

        public void habilitaciones()
        {
            gpbConsultaCompleja.Enabled = false;
            gpbAgruparUOrdenar.Enabled  = false;
            chkcondiciones.Checked      = false;
            chkSelectTodos.Checked      = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitaciones();
        }

        private void btnBuscarCONSULTAS_Click(object sender, EventArgs e)
        {
            actualizardatagrid();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cboQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbocopiaquery.SelectedIndex = cboQuery.SelectedIndex;
            txtCadenaGeneradaCONSULTAS.Text = cbocopiaquery.SelectedItem.ToString();
            consulta = txtCadenaGeneradaCONSULTAS.Text;
        }

        private void cbocopiaquery_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarComparacion_Click(object sender, EventArgs e)
        {
                where = cboTipoComparador.SelectedItem.ToString() + " " + cboCampoComparacion.SelectedItem.ToString() + "=" +
                '"' + txtValorComparacion.Text + '"' + " ";
                MessageBox.Show(csimple + where);
                txtCadenaGenerada.Text = csimple + where;
        }

        private void btnAgregarConsultaCompleja_Click(object sender, EventArgs e)
        {
            if (where != "")
            {

            
                and = and + cboOperadorLogico.SelectedItem.ToString() + " "
                + cboCampoLogica.SelectedItem.ToString() + "=" +
                '"' + txtValor.Text + '"' + " ";
            MessageBox.Show(csimple + where + and);
            } else
            {
                and = "";
                MessageBox.Show("Para agregar un comparador debe seleccionar un where");

            }
        }

        private void btnAgregarAgruparordenar_Click(object sender, EventArgs e)
        {
            if (rdbDesc.Checked == true)
            {
                orden = "desc";
            } else
            {
                orden = "asc";
            }
            if (cboAgruparOrdenar.SelectedIndex == 0)
            {
                group = "group by " + cboCampoAgruparOrdenar.SelectedItem.ToString();
                       
                MessageBox.Show(cboAgruparOrdenar.SelectedItem.ToString());
            } else if (cboAgruparOrdenar.SelectedIndex == 1)
            {
                group = "order by " + cboCampoAgruparOrdenar.SelectedItem.ToString() + " " + orden;

            }
            MessageBox.Show(csimple + where + and + group);
            txtCadenaGenerada.Text = csimple + where + and + group;
        }

        private void cboAgruparOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAgruparOrdenar.SelectedIndex == 1)
            {
                gpbOrdenamiento.Enabled = true;
            } else
            {
                gpbOrdenamiento.Enabled = false;
                rdbAsc.Checked = false;
                rdbDesc.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            where = cboTipoComparador.SelectedItem.ToString() + " " + cboCampoComparacion.SelectedItem.ToString() + "=" +
            '"' + txtValorComparacion.Text + '"' + " ";
            MessageBox.Show(csimple + where);
            txtCadenaGenerada.Text = csimple + where;

        }

        private void cbovalidar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void actualizaconsultas()
        {
            DataTable dt = cn.llenartb2();
            dgvBUSCARyELIMINAR.DataSource = dt;
        }

        private void btnConsultaBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            actualizaconsultas();
        }

        public void actualizaconsultas2(string condicion)
        {
            DataTable dt = cn.llenartb3(condicion);
            dgvBUSCARyELIMINAR.DataSource = dt;
        }

        private void btnBuscarBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            actualizaconsultas2(txtNombreConsultaBUSCARyELIMINAR.Text);
        }

        private void btnActualizarBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            tabPage4.Hide();
            tabPage3.Show();
        }

        private void btnEliminarBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            cn.ejecutarconsulta(txtNombreConsultaBUSCARyELIMINAR.Text);
        }
    }
}
