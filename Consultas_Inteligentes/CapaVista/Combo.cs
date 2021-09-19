using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;
namespace CapaVista
{
    public partial class Combo : UserControl
    {
        public Combo()
        {
            InitializeComponent();
        }
        clsControlador cn = new clsControlador();
        private void cboAuto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void llenarse(string tabla, string campo1, string campo2)
        {
            cboAuto.ValueMember = "numero";
            cboAuto.DisplayMember = "nombre";
            string[] items = cn.items(tabla, campo1, campo2);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cboAuto.Items.Add(items[i]);
                    }
                }
            }
            var dt2 = cn.enviar(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {
                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));
            }
            cboAuto.AutoCompleteCustomSource = coleccion;
            cboAuto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAuto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
