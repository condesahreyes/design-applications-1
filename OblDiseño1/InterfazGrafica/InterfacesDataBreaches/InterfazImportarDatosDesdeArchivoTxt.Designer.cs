
namespace InterfazGrafica.InterfacesDataBreaches
{
    partial class InterfazImportarDatosDesdeArchivoTxt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Importar = new System.Windows.Forms.Button();
            this.richTextBox_rutaDelArchivoSeleccionado = new System.Windows.Forms.RichTextBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_Volver
            // 
            this.button_Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Volver.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.button_Volver.Location = new System.Drawing.Point(11, 348);
            this.button_Volver.Margin = new System.Windows.Forms.Padding(2);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(113, 27);
            this.button_Volver.TabIndex = 2;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = false;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Importar
            // 
            this.button_Importar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Importar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Importar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Importar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Importar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.button_Importar.Location = new System.Drawing.Point(407, 348);
            this.button_Importar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Importar.Name = "button_Importar";
            this.button_Importar.Size = new System.Drawing.Size(145, 27);
            this.button_Importar.TabIndex = 3;
            this.button_Importar.Text = "Importar";
            this.button_Importar.UseVisualStyleBackColor = false;
            this.button_Importar.Click += new System.EventHandler(this.button_Importar_Click);
            // 
            // richTextBox_rutaDelArchivoSeleccionado
            // 
            this.richTextBox_rutaDelArchivoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_rutaDelArchivoSeleccionado.Location = new System.Drawing.Point(12, 108);
            this.richTextBox_rutaDelArchivoSeleccionado.Name = "richTextBox_rutaDelArchivoSeleccionado";
            this.richTextBox_rutaDelArchivoSeleccionado.ReadOnly = true;
            this.richTextBox_rutaDelArchivoSeleccionado.Size = new System.Drawing.Size(539, 119);
            this.richTextBox_rutaDelArchivoSeleccionado.TabIndex = 4;
            this.richTextBox_rutaDelArchivoSeleccionado.Text = "";
            // 
            // button_Buscar
            // 
            this.button_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Buscar.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.button_Buscar.Location = new System.Drawing.Point(406, 232);
            this.button_Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(145, 27);
            this.button_Buscar.TabIndex = 6;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = false;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(269, 79);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(282, 26);
            this.lblListadoTarjetas.TabIndex = 13;
            this.lblListadoTarjetas.Text = "Ruta del archivo Seleccionado";
            // 
            // InterfazImportarDatosDesdeArchivoTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.richTextBox_rutaDelArchivoSeleccionado);
            this.Controls.Add(this.button_Importar);
            this.Controls.Add(this.button_Volver);
            this.Name = "InterfazImportarDatosDesdeArchivoTxt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Archivo Data Breach";
            this.Load += new System.EventHandler(this.InterfazImportarDatosDesdeArchivoTxt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Importar;
        private System.Windows.Forms.RichTextBox richTextBox_rutaDelArchivoSeleccionado;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Label lblListadoTarjetas;
    }
}