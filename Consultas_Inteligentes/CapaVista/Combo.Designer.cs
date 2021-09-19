namespace CapaVista
{
    partial class Combo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboAuto = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboAuto
            // 
            this.cboAuto.FormattingEnabled = true;
            this.cboAuto.Location = new System.Drawing.Point(3, 3);
            this.cboAuto.Name = "cboAuto";
            this.cboAuto.Size = new System.Drawing.Size(144, 21);
            this.cboAuto.TabIndex = 0;
            this.cboAuto.SelectedIndexChanged += new System.EventHandler(this.cboAuto_SelectedIndexChanged);
            // 
            // Combo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboAuto);
            this.Name = "Combo";
            this.Size = new System.Drawing.Size(151, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAuto;
    }
}
