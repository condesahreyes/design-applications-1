namespace InterfazGrafica.InterfacesDeContrasenias
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
            this.btnEliminarContrasenia = new System.Windows.Forms.Button();
            this.lblListadoContrasenias = new System.Windows.Forms.Label();
            this.btnModificarContrasenia = new System.Windows.Forms.Button();
            this.btnAgregarContrasenia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_ListaDuplas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaDuplas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContraseniaVolverMenu
            // 
            this.btnContraseniaVolverMenu.Location = new System.Drawing.Point(12, 306);
            this.btnContraseniaVolverMenu.Name = "btnContraseniaVolverMenu";
            this.btnContraseniaVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.btnContraseniaVolverMenu.TabIndex = 9;
            this.btnContraseniaVolverMenu.Text = "Volver";
            this.btnContraseniaVolverMenu.UseVisualStyleBackColor = true;
            this.btnContraseniaVolverMenu.Click += new System.EventHandler(this.btnContraseniaVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dataGridView_ListaDuplas);
            this.panel1.Controls.Add(this.btnEliminarContrasenia);
            this.panel1.Controls.Add(this.lblListadoContrasenias);
            this.panel1.Controls.Add(this.btnModificarContrasenia);
            this.panel1.Controls.Add(this.btnAgregarContrasenia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 288);
            this.panel1.TabIndex = 8;
            // 
            // btnEliminarContrasenia
            // 
            this.btnEliminarContrasenia.Location = new System.Drawing.Point(388, 262);
            this.btnEliminarContrasenia.Name = "btnEliminarContrasenia";
            this.btnEliminarContrasenia.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarContrasenia.TabIndex = 5;
            this.btnEliminarContrasenia.Text = "Eliminar";
            this.btnEliminarContrasenia.UseVisualStyleBackColor = true;
            this.btnEliminarContrasenia.Click += new System.EventHandler(this.btnEliminarContrasenia_Click);
            // 
            // lblListadoContrasenias
            // 
            this.lblListadoContrasenias.AutoSize = true;
            this.lblListadoContrasenias.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoContrasenias.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoContrasenias.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoContrasenias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoContrasenias.Location = new System.Drawing.Point(15, 7);
            this.lblListadoContrasenias.Name = "lblListadoContrasenias";
            this.lblListadoContrasenias.Size = new System.Drawing.Size(224, 26);
            this.lblListadoContrasenias.TabIndex = 4;
            this.lblListadoContrasenias.Text = "Listado de Contraseñas";
            // 
            // btnModificarContrasenia
            // 
            this.btnModificarContrasenia.Location = new System.Drawing.Point(307, 262);
            this.btnModificarContrasenia.Name = "btnModificarContrasenia";
            this.btnModificarContrasenia.Size = new System.Drawing.Size(75, 23);
            this.btnModificarContrasenia.TabIndex = 3;
            this.btnModificarContrasenia.Text = "Modificar";
            this.btnModificarContrasenia.UseVisualStyleBackColor = true;
            this.btnModificarContrasenia.Click += new System.EventHandler(this.btnModificarContrasenia_Click);
            // 
            // btnAgregarContrasenia
            // 
            this.btnAgregarContrasenia.Location = new System.Drawing.Point(226, 262);
            this.btnAgregarContrasenia.Name = "btnAgregarContrasenia";
            this.btnAgregarContrasenia.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarContrasenia.TabIndex = 2;
            this.btnAgregarContrasenia.Text = "Agregar";
            this.btnAgregarContrasenia.UseVisualStyleBackColor = true;
            this.btnAgregarContrasenia.Click += new System.EventHandler(this.btnAgregarContrasenia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // dataGridView_ListaDuplas
            // 
            this.dataGridView_ListaDuplas.AllowUserToAddRows = false;
            this.dataGridView_ListaDuplas.AllowUserToDeleteRows = false;
            this.dataGridView_ListaDuplas.AllowUserToResizeColumns = false;
            this.dataGridView_ListaDuplas.AllowUserToResizeRows = false;
            this.dataGridView_ListaDuplas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListaDuplas.Location = new System.Drawing.Point(20, 49);
            this.dataGridView_ListaDuplas.MultiSelect = false;
            this.dataGridView_ListaDuplas.Name = "dataGridView_ListaDuplas";
            this.dataGridView_ListaDuplas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ListaDuplas.Size = new System.Drawing.Size(428, 207);
            this.dataGridView_ListaDuplas.TabIndex = 6;
            this.dataGridView_ListaDuplas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ListaDuplas_CellContentClick);
            // 
            // InterfazContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.btnContraseniaVolverMenu);
            this.Controls.Add(this.panel1);
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