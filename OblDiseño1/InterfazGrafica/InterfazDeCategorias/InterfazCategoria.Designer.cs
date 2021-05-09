namespace InterfazGrafica.InterfazCategoria
{
    partial class InterfazCategorias
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
            this.btnCategoriaVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridCategorias = new System.Windows.Forms.DataGridView();
            this.lblListadoCategoria = new System.Windows.Forms.Label();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCategoriaVolverMenu
            // 
            this.btnCategoriaVolverMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnCategoriaVolverMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCategoriaVolverMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoriaVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriaVolverMenu.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCategoriaVolverMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnCategoriaVolverMenu.Location = new System.Drawing.Point(3, 311);
            this.btnCategoriaVolverMenu.Name = "btnCategoriaVolverMenu";
            this.btnCategoriaVolverMenu.Size = new System.Drawing.Size(81, 27);
            this.btnCategoriaVolverMenu.TabIndex = 5;
            this.btnCategoriaVolverMenu.Text = "Volver";
            this.btnCategoriaVolverMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoriaVolverMenu.UseVisualStyleBackColor = false;
            this.btnCategoriaVolverMenu.Click += new System.EventHandler(this.btnCategoriaVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCategoriaVolverMenu);
            this.panel1.Controls.Add(this.dataGridCategorias);
            this.panel1.Controls.Add(this.lblListadoCategoria);
            this.panel1.Controls.Add(this.btnModificarCategoria);
            this.panel1.Controls.Add(this.btnAgregarCategoria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 345);
            this.panel1.TabIndex = 4;
            // 
            // dataGridCategorias
            // 
            this.dataGridCategorias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dataGridCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridCategorias.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridCategorias.Location = new System.Drawing.Point(37, 45);
            this.dataGridCategorias.MultiSelect = false;
            this.dataGridCategorias.Name = "dataGridCategorias";
            this.dataGridCategorias.ReadOnly = true;
            this.dataGridCategorias.RowHeadersVisible = false;
            this.dataGridCategorias.RowHeadersWidth = 20;
            this.dataGridCategorias.RowTemplate.ReadOnly = true;
            this.dataGridCategorias.Size = new System.Drawing.Size(464, 225);
            this.dataGridCategorias.TabIndex = 5;
            // 
            // lblListadoCategoria
            // 
            this.lblListadoCategoria.AutoSize = true;
            this.lblListadoCategoria.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoCategoria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoCategoria.Location = new System.Drawing.Point(293, 7);
            this.lblListadoCategoria.Name = "lblListadoCategoria";
            this.lblListadoCategoria.Size = new System.Drawing.Size(208, 26);
            this.lblListadoCategoria.TabIndex = 4;
            this.lblListadoCategoria.Text = "Listado de Categorías";
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnModificarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnModificarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCategoria.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnModificarCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnModificarCategoria.Location = new System.Drawing.Point(420, 285);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(81, 27);
            this.btnModificarCategoria.TabIndex = 3;
            this.btnModificarCategoria.Text = "Modificar";
            this.btnModificarCategoria.UseVisualStyleBackColor = false;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnAgregarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCategoria.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnAgregarCategoria.Location = new System.Drawing.Point(324, 285);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(81, 27);
            this.btnAgregarCategoria.TabIndex = 2;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = false;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // InterfazCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 362);
            this.Controls.Add(this.panel1);
            this.Name = "InterfazCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorías";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategoriaVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblListadoCategoria;
        private System.Windows.Forms.Button btnModificarCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCategorias;
    }
}