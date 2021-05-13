
namespace InterfazGrafica.InterfacesDeTarjetas
{
    partial class InterfazModificarTarjeta
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
            this.Cancelar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Aceptar = new System.Windows.Forms.Button();
            this.textBoxCodigoSeguridad = new System.Windows.Forms.TextBox();
            this.textBoxNotaOpcional = new System.Windows.Forms.TextBox();
            this.textBoxNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.textBoxTipo = new System.Windows.Forms.TextBox();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Font = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
            this.Cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.Cancelar.Location = new System.Drawing.Point(322, 339);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(145, 27);
            this.Cancelar.TabIndex = 61;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd//mm//aaaa";
            this.dateTimePicker1.Location = new System.Drawing.Point(297, 201);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 60;
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.Aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aceptar.Font = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
            this.Aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.Aceptar.Location = new System.Drawing.Point(133, 339);
            this.Aceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(145, 27);
            this.Aceptar.TabIndex = 59;
            this.Aceptar.Text = "Confirmar";
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // textBoxCodigoSeguridad
            // 
            this.textBoxCodigoSeguridad.Location = new System.Drawing.Point(297, 167);
            this.textBoxCodigoSeguridad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCodigoSeguridad.Name = "textBoxCodigoSeguridad";
            this.textBoxCodigoSeguridad.Size = new System.Drawing.Size(160, 20);
            this.textBoxCodigoSeguridad.TabIndex = 58;
            // 
            // textBoxNotaOpcional
            // 
            this.textBoxNotaOpcional.Location = new System.Drawing.Point(297, 268);
            this.textBoxNotaOpcional.Multiline = true;
            this.textBoxNotaOpcional.Name = "textBoxNotaOpcional";
            this.textBoxNotaOpcional.Size = new System.Drawing.Size(160, 52);
            this.textBoxNotaOpcional.TabIndex = 57;
            // 
            // textBoxNumeroTarjeta
            // 
            this.textBoxNumeroTarjeta.Location = new System.Drawing.Point(297, 129);
            this.textBoxNumeroTarjeta.Name = "textBoxNumeroTarjeta";
            this.textBoxNumeroTarjeta.Size = new System.Drawing.Size(160, 20);
            this.textBoxNumeroTarjeta.TabIndex = 50;
            // 
            // textBoxTipo
            // 
            this.textBoxTipo.Location = new System.Drawing.Point(297, 92);
            this.textBoxTipo.Name = "textBoxTipo";
            this.textBoxTipo.Size = new System.Drawing.Size(160, 20);
            this.textBoxTipo.TabIndex = 48;
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(317, -35);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(135, 26);
            this.lblListadoTarjetas.TabIndex = 46;
            this.lblListadoTarjetas.Text = "Nueva Tarjeta";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(297, 56);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(160, 20);
            this.textBoxNombre.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.label8.Location = new System.Drawing.Point(292, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 26);
            this.label8.TabIndex = 62;
            this.label8.Text = "Tarjeta A Modificar";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(297, 233);
            this.comboBoxCategorias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(160, 21);
            this.comboBoxCategorias.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label13.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(229, 235);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 22);
            this.label13.TabIndex = 76;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label12.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(229, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 22);
            this.label12.TabIndex = 75;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label11.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(229, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 22);
            this.label11.TabIndex = 74;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label10.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(229, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 22);
            this.label10.TabIndex = 73;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label9.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(229, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 22);
            this.label9.TabIndex = 72;
            this.label9.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(229, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 22);
            this.label1.TabIndex = 71;
            this.label1.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label6.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(197, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 70;
            this.label6.Text = "Nota";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label7.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(139, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 22);
            this.label7.TabIndex = 69;
            this.label7.Text = "Categoría";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(46, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 22);
            this.label5.TabIndex = 68;
            this.label5.Text = "Código de Seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label4.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(36, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 22);
            this.label4.TabIndex = 67;
            this.label4.Text = "Fecha de Vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(152, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 22);
            this.label3.TabIndex = 66;
            this.label3.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(183, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 65;
            this.label2.Text = "Tipo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label14.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(192)))));
            this.label14.Location = new System.Drawing.Point(152, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 22);
            this.label14.TabIndex = 64;
            this.label14.Text = "Nombre";
            // 
            // InterfazModificarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.textBoxCodigoSeguridad);
            this.Controls.Add(this.textBoxNotaOpcional);
            this.Controls.Add(this.textBoxNumeroTarjeta);
            this.Controls.Add(this.textBoxTipo);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.textBoxNombre);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InterfazModificarTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfazModificarTarjeta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.TextBox textBoxCodigoSeguridad;
        private System.Windows.Forms.TextBox textBoxNotaOpcional;
        private System.Windows.Forms.TextBox textBoxNumeroTarjeta;
        private System.Windows.Forms.TextBox textBoxTipo;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
    }
}