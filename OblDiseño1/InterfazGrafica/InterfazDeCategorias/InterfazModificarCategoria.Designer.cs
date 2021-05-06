namespace InterfazGrafica.InterfazDeCategorias
{
    partial class InterfazModificarCategoria
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
            this.btnCancelarModCategoria = new System.Windows.Forms.Button();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.textBoxModificarCategoria = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelarModCategoria
            // 
            this.btnCancelarModCategoria.Location = new System.Drawing.Point(259, 242);
            this.btnCancelarModCategoria.Name = "btnCancelarModCategoria";
            this.btnCancelarModCategoria.Size = new System.Drawing.Size(91, 23);
            this.btnCancelarModCategoria.TabIndex = 18;
            this.btnCancelarModCategoria.Text = "Cancelar";
            this.btnCancelarModCategoria.UseVisualStyleBackColor = true;
            this.btnCancelarModCategoria.Click += new System.EventHandler(this.btnCancelarModCategoria_Click);
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Location = new System.Drawing.Point(144, 242);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(91, 23);
            this.btnModificarCategoria.TabIndex = 17;
            this.btnModificarCategoria.Text = "Modificar";
            this.btnModificarCategoria.UseVisualStyleBackColor = true;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(140, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre";
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(166, 76);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(191, 26);
            this.lblListadoTarjetas.TabIndex = 15;
            this.lblListadoTarjetas.Text = "Modificar Categoría";
            this.lblListadoTarjetas.Click += new System.EventHandler(this.lblListadoTarjetas_Click);
            // 
            // textBoxModificarCategoria
            // 
            this.textBoxModificarCategoria.Location = new System.Drawing.Point(240, 148);
            this.textBoxModificarCategoria.Name = "textBoxModificarCategoria";
            this.textBoxModificarCategoria.Size = new System.Drawing.Size(100, 20);
            this.textBoxModificarCategoria.TabIndex = 14;
            // 
            // InterfazModificarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.btnCancelarModCategoria);
            this.Controls.Add(this.btnModificarCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.textBoxModificarCategoria);
            this.Name = "InterfazModificarCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfazModificarCategoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarModCategoria;
        private System.Windows.Forms.Button btnModificarCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.TextBox textBoxModificarCategoria;
    }
}