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
            this.btnCategoriaVolverMenu.Location = new System.Drawing.Point(16, 377);
            this.btnCategoriaVolverMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCategoriaVolverMenu.Name = "btnCategoriaVolverMenu";
            this.btnCategoriaVolverMenu.Size = new System.Drawing.Size(100, 28);
            this.btnCategoriaVolverMenu.TabIndex = 5;
            this.btnCategoriaVolverMenu.Text = "Volver";
            this.btnCategoriaVolverMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoriaVolverMenu.UseVisualStyleBackColor = true;
            this.btnCategoriaVolverMenu.Click += new System.EventHandler(this.btnCategoriaVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dataGridCategorias);
            this.panel1.Controls.Add(this.lblListadoCategoria);
            this.panel1.Controls.Add(this.btnModificarCategoria);
            this.panel1.Controls.Add(this.btnAgregarCategoria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 354);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridCategorias
            // 
            this.dataGridCategorias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCategorias.ColumnHeadersHeight = 29;
            this.dataGridCategorias.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridCategorias.Location = new System.Drawing.Point(27, 63);
            this.dataGridCategorias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridCategorias.MultiSelect = false;
            this.dataGridCategorias.Name = "dataGridCategorias";
            this.dataGridCategorias.ReadOnly = true;
            this.dataGridCategorias.RowHeadersWidth = 20;
            this.dataGridCategorias.Size = new System.Drawing.Size(569, 233);
            this.dataGridCategorias.TabIndex = 5;
            this.dataGridCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblListadoCategoria
            // 
            this.lblListadoCategoria.AutoSize = true;
            this.lblListadoCategoria.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoCategoria.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoCategoria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoCategoria.Location = new System.Drawing.Point(20, 9);
            this.lblListadoCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoCategoria.Name = "lblListadoCategoria";
            this.lblListadoCategoria.Size = new System.Drawing.Size(263, 33);
            this.lblListadoCategoria.TabIndex = 4;
            this.lblListadoCategoria.Text = "Listado de Categorías";
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Location = new System.Drawing.Point(496, 322);
            this.btnModificarCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(100, 28);
            this.btnModificarCategoria.TabIndex = 3;
            this.btnModificarCategoria.Text = "Modificar";
            this.btnModificarCategoria.UseVisualStyleBackColor = true;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(384, 322);
            this.btnAgregarCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(100, 28);
            this.btnAgregarCategoria.TabIndex = 2;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
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
            // InterfazCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(653, 420);
            this.Controls.Add(this.btnCategoriaVolverMenu);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InterfazCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorías";
            this.Load += new System.EventHandler(this.InterfazCategorias_Load);
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