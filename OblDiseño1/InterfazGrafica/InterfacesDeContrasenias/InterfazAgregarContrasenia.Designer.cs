namespace InterfazGrafica.InterfacesDeContrasenias
{
    partial class InterfazAgregarContrasenia
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
            this.btnCancelarCategoria = new System.Windows.Forms.Button();
            this.btn_AgregarContrasenia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContrasenia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombreSitioApp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.butto_GenerarContrasenia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelarCategoria
            // 
            this.btnCancelarCategoria.Location = new System.Drawing.Point(319, 289);
            this.btnCancelarCategoria.Name = "btnCancelarCategoria";
            this.btnCancelarCategoria.Size = new System.Drawing.Size(91, 23);
            this.btnCancelarCategoria.TabIndex = 13;
            this.btnCancelarCategoria.Text = "Cancelar";
            this.btnCancelarCategoria.UseVisualStyleBackColor = true;
            this.btnCancelarCategoria.Click += new System.EventHandler(this.btnCancelarCategoria_Click);
            // 
            // btn_AgregarContrasenia
            // 
            this.btn_AgregarContrasenia.Location = new System.Drawing.Point(192, 289);
            this.btn_AgregarContrasenia.Name = "btn_AgregarContrasenia";
            this.btn_AgregarContrasenia.Size = new System.Drawing.Size(91, 23);
            this.btn_AgregarContrasenia.TabIndex = 12;
            this.btn_AgregarContrasenia.Text = "Agregar";
            this.btn_AgregarContrasenia.UseVisualStyleBackColor = true;
            this.btn_AgregarContrasenia.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(87, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(187, 18);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(177, 26);
            this.lblListadoTarjetas.TabIndex = 10;
            this.lblListadoTarjetas.Text = "Nueva Contraseña";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(204, 64);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(178, 20);
            this.textBoxNombre.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(59, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Contraseña";
            // 
            // textBoxContrasenia
            // 
            this.textBoxContrasenia.Location = new System.Drawing.Point(204, 100);
            this.textBoxContrasenia.Name = "textBoxContrasenia";
            this.textBoxContrasenia.Size = new System.Drawing.Size(178, 20);
            this.textBoxContrasenia.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(16, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nombre De Sitio";
            // 
            // textBoxNombreSitioApp
            // 
            this.textBoxNombreSitioApp.Location = new System.Drawing.Point(204, 137);
            this.textBoxNombreSitioApp.Name = "textBoxNombreSitioApp";
            this.textBoxNombreSitioApp.Size = new System.Drawing.Size(178, 20);
            this.textBoxNombreSitioApp.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(117, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nota";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxNota
            // 
            this.textBoxNota.Location = new System.Drawing.Point(204, 209);
            this.textBoxNota.Multiline = true;
            this.textBoxNota.Name = "textBoxNota";
            this.textBoxNota.Size = new System.Drawing.Size(178, 59);
            this.textBoxNota.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(74, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Categoría";
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(204, 173);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(178, 21);
            this.comboBoxCategoria.TabIndex = 21;
            this.comboBoxCategoria.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoria_SelectedIndexChanged);
            // 
            // butto_GenerarContrasenia
            // 
            this.butto_GenerarContrasenia.Location = new System.Drawing.Point(412, 100);
            this.butto_GenerarContrasenia.Name = "butto_GenerarContrasenia";
            this.butto_GenerarContrasenia.Size = new System.Drawing.Size(66, 20);
            this.butto_GenerarContrasenia.TabIndex = 22;
            this.butto_GenerarContrasenia.Text = "Generar";
            this.butto_GenerarContrasenia.UseVisualStyleBackColor = true;
            this.butto_GenerarContrasenia.Click += new System.EventHandler(this.butto_GenerarContrasenia_Click);
            // 
            // InterfazAgregarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.butto_GenerarContrasenia);
            this.Controls.Add(this.comboBoxCategoria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNota);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxNombreSitioApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContrasenia);
            this.Controls.Add(this.btnCancelarCategoria);
            this.Controls.Add(this.btn_AgregarContrasenia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.textBoxNombre);
            this.Name = "InterfazAgregarContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Contraseña";
            this.Load += new System.EventHandler(this.InterfazAgregarContrasenia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarCategoria;
        private System.Windows.Forms.Button btn_AgregarContrasenia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContrasenia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombreSitioApp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Button butto_GenerarContrasenia;
    }
}