﻿namespace InterfazGrafica.InterfazDataBreaches
{
    partial class InterfazChequeoDataBreaches
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
            this.dataGridTarjetas = new System.Windows.Forms.DataGridView();
            this.TextBoxDatosDataBreaches = new System.Windows.Forms.RichTextBox();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.btnContraseniaVolverMenu = new System.Windows.Forms.Button();
            this.btnChequear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridContrasenias = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificarDupla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContrasenias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTarjetas
            // 
            this.dataGridTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarjetas.Location = new System.Drawing.Point(381, 102);
            this.dataGridTarjetas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridTarjetas.MultiSelect = false;
            this.dataGridTarjetas.Name = "dataGridTarjetas";
            this.dataGridTarjetas.ReadOnly = true;
            this.dataGridTarjetas.RowHeadersVisible = false;
            this.dataGridTarjetas.RowHeadersWidth = 4;
            this.dataGridTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarjetas.Size = new System.Drawing.Size(452, 182);
            this.dataGridTarjetas.TabIndex = 0;
            // 
            // TextBoxDatosDataBreaches
            // 
            this.TextBoxDatosDataBreaches.Location = new System.Drawing.Point(37, 169);
            this.TextBoxDatosDataBreaches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxDatosDataBreaches.Name = "TextBoxDatosDataBreaches";
            this.TextBoxDatosDataBreaches.Size = new System.Drawing.Size(293, 301);
            this.TextBoxDatosDataBreaches.TabIndex = 1;
            this.TextBoxDatosDataBreaches.Text = "";
            this.TextBoxDatosDataBreaches.TextChanged += new System.EventHandler(this.TextBoxDatosDataBreaches_TextChanged);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(296, 11);
            this.lblListadoTarjetas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(323, 33);
            this.lblListadoTarjetas.TabIndex = 11;
            this.lblListadoTarjetas.Text = "Chequeo de Data Breaches";
            // 
            // btnContraseniaVolverMenu
            // 
            this.btnContraseniaVolverMenu.Location = new System.Drawing.Point(37, 513);
            this.btnContraseniaVolverMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContraseniaVolverMenu.Name = "btnContraseniaVolverMenu";
            this.btnContraseniaVolverMenu.Size = new System.Drawing.Size(100, 28);
            this.btnContraseniaVolverMenu.TabIndex = 26;
            this.btnContraseniaVolverMenu.Text = "Volver";
            this.btnContraseniaVolverMenu.UseVisualStyleBackColor = true;
            this.btnContraseniaVolverMenu.Click += new System.EventHandler(this.btnContraseniaVolverMenu_Click);
            // 
            // btnChequear
            // 
            this.btnChequear.Location = new System.Drawing.Point(232, 478);
            this.btnChequear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChequear.Name = "btnChequear";
            this.btnChequear.Size = new System.Drawing.Size(100, 28);
            this.btnChequear.TabIndex = 27;
            this.btnChequear.Text = "Chequear";
            this.btnChequear.UseVisualStyleBackColor = true;
            this.btnChequear.Click += new System.EventHandler(this.btnChequear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(452, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 28);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tarjetas Vulneradas";
            // 
            // dataGridContrasenias
            // 
            this.dataGridContrasenias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContrasenias.Location = new System.Drawing.Point(381, 324);
            this.dataGridContrasenias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridContrasenias.MultiSelect = false;
            this.dataGridContrasenias.Name = "dataGridContrasenias";
            this.dataGridContrasenias.ReadOnly = true;
            this.dataGridContrasenias.RowHeadersVisible = false;
            this.dataGridContrasenias.RowHeadersWidth = 51;
            this.dataGridContrasenias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContrasenias.Size = new System.Drawing.Size(452, 182);
            this.dataGridContrasenias.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(412, 293);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 28);
            this.label3.TabIndex = 31;
            this.label3.Text = "Contraseñas vulnderadas";
            // 
            // btnModificarDupla
            // 
            this.btnModificarDupla.Location = new System.Drawing.Point(649, 513);
            this.btnModificarDupla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarDupla.Name = "btnModificarDupla";
            this.btnModificarDupla.Size = new System.Drawing.Size(167, 28);
            this.btnModificarDupla.TabIndex = 32;
            this.btnModificarDupla.Text = "Modificar contraseña";
            this.btnModificarDupla.UseVisualStyleBackColor = true;
            this.btnModificarDupla.Click += new System.EventHandler(this.button1_Click);
            // 
            // InterfazChequeoDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(892, 565);
            this.Controls.Add(this.btnModificarDupla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridContrasenias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChequear);
            this.Controls.Add(this.btnContraseniaVolverMenu);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.TextBoxDatosDataBreaches);
            this.Controls.Add(this.dataGridTarjetas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InterfazChequeoDataBreaches";
            this.Text = "Data Breaches";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarjetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContrasenias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTarjetas;
        private System.Windows.Forms.RichTextBox TextBoxDatosDataBreaches;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.Button btnContraseniaVolverMenu;
        private System.Windows.Forms.Button btnChequear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridContrasenias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModificarDupla;
    }
}