namespace InterfazGrafica.InterfazIngreso
{
    partial class InterfazCambioContrasenia
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNuevaContrasenia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContrasenia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.btnCancelarContrasenia = new System.Windows.Forms.Button();
            this.btnModificarContrasenia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(71, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nueva contraseña";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxNuevaContrasenia
            // 
            this.textBoxNuevaContrasenia.Location = new System.Drawing.Point(275, 209);
            this.textBoxNuevaContrasenia.Name = "textBoxNuevaContrasenia";
            this.textBoxNuevaContrasenia.Size = new System.Drawing.Size(160, 20);
            this.textBoxNuevaContrasenia.TabIndex = 23;
            this.textBoxNuevaContrasenia.TextChanged += new System.EventHandler(this.textBoxNombreSitioApp_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(127, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxContrasenia
            // 
            this.textBoxContrasenia.Location = new System.Drawing.Point(275, 167);
            this.textBoxContrasenia.Name = "textBoxContrasenia";
            this.textBoxContrasenia.Size = new System.Drawing.Size(160, 20);
            this.textBoxContrasenia.TabIndex = 21;
            this.textBoxContrasenia.TextChanged += new System.EventHandler(this.textBoxContrasenia_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(59, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nombre de usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(196, 73);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(214, 26);
            this.lblListadoTarjetas.TabIndex = 19;
            this.lblListadoTarjetas.Text = "Cambio de contraseña";
            this.lblListadoTarjetas.Click += new System.EventHandler(this.lblListadoTarjetas_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(275, 126);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(160, 20);
            this.textBoxNombre.TabIndex = 18;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // btnCancelarContrasenia
            // 
            this.btnCancelarContrasenia.Location = new System.Drawing.Point(319, 265);
            this.btnCancelarContrasenia.Name = "btnCancelarContrasenia";
            this.btnCancelarContrasenia.Size = new System.Drawing.Size(91, 23);
            this.btnCancelarContrasenia.TabIndex = 26;
            this.btnCancelarContrasenia.Text = "Cancelar";
            this.btnCancelarContrasenia.UseVisualStyleBackColor = true;
            this.btnCancelarContrasenia.Click += new System.EventHandler(this.btnCancelarContrasenia_Click);
            // 
            // btnModificarContrasenia
            // 
            this.btnModificarContrasenia.Location = new System.Drawing.Point(204, 265);
            this.btnModificarContrasenia.Name = "btnModificarContrasenia";
            this.btnModificarContrasenia.Size = new System.Drawing.Size(91, 23);
            this.btnModificarContrasenia.TabIndex = 25;
            this.btnModificarContrasenia.Text = "Modificar";
            this.btnModificarContrasenia.UseVisualStyleBackColor = true;
            this.btnModificarContrasenia.Click += new System.EventHandler(this.btnModificarContrasenia_Click);
            // 
            // InterfazCambioContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.btnCancelarContrasenia);
            this.Controls.Add(this.btnModificarContrasenia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNuevaContrasenia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContrasenia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "InterfazCambioContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNuevaContrasenia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContrasenia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button btnCancelarContrasenia;
        private System.Windows.Forms.Button btnModificarContrasenia;
    }
}