﻿namespace InterfazGrafica.InterfacesDeContrasenias
{
    partial class InterfazContrasenia
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
            this.btnContraseniaVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_ListaDuplas = new System.Windows.Forms.DataGridView();
            this.btnEliminarContrasenia = new System.Windows.Forms.Button();
            this.lblListadoContrasenias = new System.Windows.Forms.Label();
            this.btnModificarContrasenia = new System.Windows.Forms.Button();
            this.btnAgregarContrasenia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaDuplas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContraseniaVolverMenu
            // 
            this.btnContraseniaVolverMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnContraseniaVolverMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContraseniaVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContraseniaVolverMenu.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnContraseniaVolverMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnContraseniaVolverMenu.Location = new System.Drawing.Point(4, 398);
            this.btnContraseniaVolverMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContraseniaVolverMenu.Name = "btnContraseniaVolverMenu";
            this.btnContraseniaVolverMenu.Size = new System.Drawing.Size(108, 33);
            this.btnContraseniaVolverMenu.TabIndex = 9;
            this.btnContraseniaVolverMenu.Text = "Volver";
            this.btnContraseniaVolverMenu.UseVisualStyleBackColor = false;
            this.btnContraseniaVolverMenu.Click += new System.EventHandler(this.btnContraseniaVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnContraseniaVolverMenu);
            this.panel1.Controls.Add(this.dataGridView_ListaDuplas);
            this.panel1.Controls.Add(this.btnEliminarContrasenia);
            this.panel1.Controls.Add(this.lblListadoContrasenias);
            this.panel1.Controls.Add(this.btnModificarContrasenia);
            this.panel1.Controls.Add(this.btnAgregarContrasenia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 446);
            this.panel1.TabIndex = 8;
            // 
            // dataGridView_ListaDuplas
            // 
            this.dataGridView_ListaDuplas.AllowUserToAddRows = false;
            this.dataGridView_ListaDuplas.AllowUserToDeleteRows = false;
            this.dataGridView_ListaDuplas.AllowUserToResizeColumns = false;
            this.dataGridView_ListaDuplas.AllowUserToResizeRows = false;
            this.dataGridView_ListaDuplas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_ListaDuplas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListaDuplas.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_ListaDuplas.Location = new System.Drawing.Point(52, 60);
            this.dataGridView_ListaDuplas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_ListaDuplas.MultiSelect = false;
            this.dataGridView_ListaDuplas.Name = "dataGridView_ListaDuplas";
            this.dataGridView_ListaDuplas.RowHeadersWidth = 51;
            this.dataGridView_ListaDuplas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ListaDuplas.Size = new System.Drawing.Size(619, 286);
            this.dataGridView_ListaDuplas.TabIndex = 6;
            // 
            // btnEliminarContrasenia
            // 
            this.btnEliminarContrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnEliminarContrasenia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarContrasenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarContrasenia.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEliminarContrasenia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnEliminarContrasenia.Location = new System.Drawing.Point(561, 369);
            this.btnEliminarContrasenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarContrasenia.Name = "btnEliminarContrasenia";
            this.btnEliminarContrasenia.Size = new System.Drawing.Size(108, 33);
            this.btnEliminarContrasenia.TabIndex = 5;
            this.btnEliminarContrasenia.Text = "Eliminar";
            this.btnEliminarContrasenia.UseVisualStyleBackColor = false;
            this.btnEliminarContrasenia.Click += new System.EventHandler(this.btnEliminarContrasenia_Click);
            // 
            // lblListadoContrasenias
            // 
            this.lblListadoContrasenias.AutoSize = true;
            this.lblListadoContrasenias.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoContrasenias.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoContrasenias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoContrasenias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoContrasenias.Location = new System.Drawing.Point(372, 9);
            this.lblListadoContrasenias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoContrasenias.Name = "lblListadoContrasenias";
            this.lblListadoContrasenias.Size = new System.Drawing.Size(282, 33);
            this.lblListadoContrasenias.TabIndex = 4;
            this.lblListadoContrasenias.Text = "Listado de Contraseñas";
            // 
            // btnModificarContrasenia
            // 
            this.btnModificarContrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnModificarContrasenia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarContrasenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarContrasenia.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnModificarContrasenia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnModificarContrasenia.Location = new System.Drawing.Point(433, 369);
            this.btnModificarContrasenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarContrasenia.Name = "btnModificarContrasenia";
            this.btnModificarContrasenia.Size = new System.Drawing.Size(108, 33);
            this.btnModificarContrasenia.TabIndex = 3;
            this.btnModificarContrasenia.Text = "Modificar";
            this.btnModificarContrasenia.UseVisualStyleBackColor = false;
            this.btnModificarContrasenia.Click += new System.EventHandler(this.btnModificarContrasenia_Click);
            // 
            // btnAgregarContrasenia
            // 
            this.btnAgregarContrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnAgregarContrasenia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarContrasenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarContrasenia.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarContrasenia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnAgregarContrasenia.Location = new System.Drawing.Point(305, 369);
            this.btnAgregarContrasenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarContrasenia.Name = "btnAgregarContrasenia";
            this.btnAgregarContrasenia.Size = new System.Drawing.Size(108, 33);
            this.btnAgregarContrasenia.TabIndex = 2;
            this.btnAgregarContrasenia.Text = "Agregar";
            this.btnAgregarContrasenia.UseVisualStyleBackColor = false;
            this.btnAgregarContrasenia.Click += new System.EventHandler(this.btnAgregarContrasenia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 0;
            // 
            // InterfazContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(751, 475);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InterfazContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contraseñas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaDuplas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContraseniaVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminarContrasenia;
        private System.Windows.Forms.Label lblListadoContrasenias;
        private System.Windows.Forms.Button btnModificarContrasenia;
        private System.Windows.Forms.Button btnAgregarContrasenia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_ListaDuplas;
    }
}