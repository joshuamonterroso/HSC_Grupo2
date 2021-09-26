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
            llenarcomboeditar();
            tablaseditar();
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
            if (cboTabla.Text == "")
            {
                chkSelectTodos.Enabled = false;
            } else
            {
                chkSelectTodos.Enabled = true;
            }
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
                chkcondiciones.Checked = false;
            }
        }

        private void btnAgregarCamposSeleccionados_Click(object sender, EventArgs e)
        {
            if (campo == "")
            {
                MessageBox.Show("Debe seleccionar al menos un campo");
            } else
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
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Boton de crear
            final = csimple + " " + where + " " + and + " " + group + ";";
            if (csimple =="")
            {
                MessageBox.Show("Consulta incorrecta");
                limpiar();
                habilitaciones();
                txtNombreConsulta.Focus();
            }
            else
            {
            MessageBox.Show("Consulta Almacenada");
            cn.ingresarconsulta(txtNombreConsulta.Text, final);
            llenarcboquery();
            limpiar();
            habilitaciones();
            txtNombreConsulta.Focus();            
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
            if ((cboOperadorLogico.Text == "") || (cboCampoLogica.Text == "") || (txtValor.Text == ""))
            {
                MessageBox.Show("Utilice todos los campos logicos");
            }
            else
            {

            if (where != "")
            {

            
                and = and + cboOperadorLogico.SelectedItem.ToString() + " "
                + cboCampoLogica.SelectedItem.ToString() + "=" +
                '"' + txtValor.Text + '"' + " ";
                MessageBox.Show(csimple + where + and);
                txtCadenaGenerada.Text = csimple + where + and;
            } else
            {
                and = "";
                MessageBox.Show("Para agregar un comparador debe seleccionar un where");


            }
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

            if ((cboAgruparOrdenar.Text == "") || (cboCampoAgruparOrdenar.Text==""))
            {
                MessageBox.Show("Debe utilizar todos los campos de agrupacion");
            } else
            {
            if (cboAgruparOrdenar.SelectedIndex == 0)
            {
                group = "group by " + cboCampoAgruparOrdenar.SelectedItem.ToString();
            } else if (cboAgruparOrdenar.SelectedIndex == 1)
            {
                group = "order by " + cboCampoAgruparOrdenar.SelectedItem.ToString() + " " + orden;

            }
            MessageBox.Show(csimple + where + and + group);
            txtCadenaGenerada.Text = csimple + where + and + group;
        }
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
            if ((cboTipoComparador.Text == "")|| (cboCampoComparacion.Text == "")|| (txtValorComparacion.Text == ""))
            {
                MessageBox.Show("Clausula where estructurada erroneamente");
            } else
            {

            where = cboTipoComparador.SelectedItem.ToString() + " " + cboCampoComparacion.SelectedItem.ToString() + "=" +
            '"' + txtValorComparacion.Text + '"' + " ";
            MessageBox.Show(csimple + where);
            txtCadenaGenerada.Text = csimple + where;
            }

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


        private void btnEliminarBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            cn.ejecutarconsulta(txtNombreConsultaBUSCARyELIMINAR.Text);
            MessageBox.Show("Las consultas con nombre " + txtNombreConsultaBUSCARyELIMINAR.Text + " Han sido eliminadas");
            actualizaconsultas();
            txtNombreConsultaBUSCARyELIMINAR.Text = "";
        }

        //Pestaña TAB3 EDITAR a partir de aca
        string transfiere = "";
        string campoeditar = "";
        string csimpleeditar = "";
        private void btnActualizarBUSCARyELIMINAR_Click(object sender, EventArgs e)
        {
            transfiere = txtNombreConsultaBUSCARyELIMINAR.Text;
            cbonombreconsulta.Text = transfiere;
            txtTablaConsultaSimple.Text = transfiere;
            groupBox8.Enabled = true;
            tabPage4.Hide();
            tabPage3.Show();        
        }

        public void llenarcomboeditar()
        {
            cbonombreconsulta.Items.Clear();
            OdbcDataReader datareader = cn.llenarcbonombreconsulta();
            while (datareader.Read())
            {
                cbonombreconsulta.Items.Add(datareader[0].ToString());
            }
        }

        private void cbonombreconsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTablaConsultaSimple.Text = cbonombreconsulta.SelectedItem.ToString();
            groupBox8.Enabled = true;

        }

        private void cboTablaConsultaSimple_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttablaeditar.Text = cboTablaConsultaSimple.SelectedItem.ToString();
            llenarcombosactualizar();
            chkSelectTodosConsultaSimple.Enabled = true;
        }

        public void tablaseditar()
        {
            cboTabla.Items.Clear();
            OdbcDataReader datareader = cn.llenarcbo();
            while (datareader.Read())
            {
                cboTablaConsultaSimple.Items.Add(datareader[0].ToString());
            }
        }
        public void llenarcombosactualizar()
        {
            cboCamposEDITAR.Items.Clear();
            cboCampoConsultaComplejaEDITAR.Items.Clear();
            cboCampoEDITAR.Items.Clear();
            cboCampoAgruparEDITAR.Items.Clear();
            OdbcDataReader datareader = cn.llenarcbo2(txttablaeditar.Text);
            while (datareader.Read())
            {
                cboCamposEDITAR.Items.Add(datareader[0].ToString());
                cboCampoConsultaComplejaEDITAR.Items.Add(datareader[0].ToString());
                cboCampoEDITAR.Items.Add(datareader[0].ToString());
                cboCampoAgruparEDITAR.Items.Add(datareader[0].ToString());
            }
        }

        private void chkSelectTodosConsultaSimple_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSelectTodosConsultaSimple.Checked == true)
            {
                txtNombreRepresentativoEDITAR.Text = "";
                txtNombreRepresentativoEDITAR.Enabled = false;
                cboCamposEDITAR.Text = "";
                cboCamposEDITAR.Enabled = false;
                txtcamposelectoseditar.Text = "";
            }
            else
            {
                txtNombreRepresentativoEDITAR.Text = "";
                txtNombreRepresentativoEDITAR.Enabled = true;
                cboCamposEDITAR.Text = "";
                cboCamposEDITAR.Enabled = true;              
            }
        }

        private void btnAgregarCONSULTASIMPLE_Click(object sender, EventArgs e)
        {
            if (chkSelectTodosConsultaSimple.Checked == false)
            {
                if (txtcamposelectoseditar.Text.Equals(""))
                {
                    if (txtNombreRepresentativoEDITAR.Text.Equals(""))
                    {
                        txtcamposelectoseditar.Text = "";
                        campoeditar = campoeditar + cboCamposEDITAR.SelectedItem.ToString() + " ";
                        txtcamposelectoseditar.Text = campoeditar;
                    }
                    else
                    {
                        txtcamposelectoseditar.Text = "";
                        campoeditar = campoeditar + cboCamposEDITAR.SelectedItem.ToString() + " as " + txtNombreRepresentativoEDITAR.Text + " ";
                        txtcamposelectoseditar.Text = campoeditar;
                    }
                }
                else
                {
                    if (txtNombreRepresentativoEDITAR.Text.Equals(""))
                    {
                        txtcamposelectoseditar.Text = "";
                        campoeditar = campoeditar + ", " + cboCamposEDITAR.SelectedItem.ToString() + " ";
                        txtcamposelectoseditar.Text = campoeditar;
                    }
                    else
                    {
                        txtcamposelectoseditar.Text = "";
                        campoeditar = campoeditar + ", " + cboCamposEDITAR.SelectedItem.ToString() + " as " + txtNombreRepresentativoEDITAR.Text + " ";
                        txtcamposelectoseditar.Text = campoeditar;
                    }
                }
            }
            else
            {
                txtcamposelectoseditar.Text = "";
                campoeditar = "";
                campoeditar = " * ";
                txtcamposelectoseditar.Text = "Todos los campos seleccionados";
                Console.WriteLine(campoeditar);
            }
        }

        private void btnagregarcamposeditar_Click(object sender, EventArgs e)
        {
            if (campoeditar == "")
            {
                MessageBox.Show("Debe seleccionar al menos un campo");
            }
            else
            {
                csimpleeditar = "SELECT " + campoeditar + "FROM " + txttablaeditar.Text + " ";
                MessageBox.Show("La cadena generada es: " + csimpleeditar);
                Console.WriteLine(csimpleeditar);
                txtCadenaGeneradaEDITAR.Text = csimpleeditar;
                campoeditar = "";
                txtNombreRepresentativoEDITAR.Text = "";
                cboCamposEDITAR.Text = "";
                txtcamposelectoseditar.Text = "";
                cboTablaConsultaSimple.Text = "";
                chkSelectTodosConsultaSimple.Checked = false;
            }
        }

        private void chkcondicioneseditar_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkcondicioneseditar.Checked == true) && (csimpleeditar != ""))
            {
                groupBox9.Enabled = true;
                groupBox12.Enabled = true;
            }
            else
            {
                groupBox9.Enabled = false;
                groupBox12.Enabled = false;
                chkcondicioneseditar.Checked = false;
            }
        }
    }
}
