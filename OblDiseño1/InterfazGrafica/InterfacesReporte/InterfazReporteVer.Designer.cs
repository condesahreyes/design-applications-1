
namespace InterfazGrafica.InterfacesReporte
{
    partial class InterfazReporteVer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Titulo = new System.Windows.Forms.Panel();
            this.label_Titulo = new System.Windows.Forms.Label();
            this.panel_ListaDeContrasenias = new System.Windows.Forms.Panel();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.dataGridView_Contrasenias = new System.Windows.Forms.DataGridView();
            this.Nombre_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrasenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Volver = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Titulo.SuspendLayout();
            this.panel_ListaDeContrasenias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contrasenias)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel_Titulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_ListaDeContrasenias, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1875F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.8125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel_Titulo
            // 
            this.panel_Titulo.Controls.Add(this.label_Titulo);
            this.panel_Titulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Titulo.Location = new System.Drawing.Point(0, 0);
            this.panel_Titulo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Titulo.Name = "panel_Titulo";
            this.panel_Titulo.Size = new System.Drawing.Size(490, 38);
            this.panel_Titulo.TabIndex = 0;
            this.panel_Titulo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Titulo_Paint);
            // 
            // label_Titulo
            // 
            this.label_Titulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Titulo.Location = new System.Drawing.Point(0, 0);
            this.label_Titulo.Name = "label_Titulo";
            this.label_Titulo.Size = new System.Drawing.Size(490, 38);
            this.label_Titulo.TabIndex = 0;
            this.label_Titulo.Text = "Contraseñas nivel ";
            this.label_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_Titulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel_ListaDeContrasenias
            // 
            this.panel_ListaDeContrasenias.Controls.Add(this.button_Modificar);
            this.panel_ListaDeContrasenias.Controls.Add(this.dataGridView_Contrasenias);
            this.panel_ListaDeContrasenias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ListaDeContrasenias.Location = new System.Drawing.Point(0, 38);
            this.panel_ListaDeContrasenias.Margin = new System.Windows.Forms.Padding(0);
            this.panel_ListaDeContrasenias.Name = "panel_ListaDeContrasenias";
            this.panel_ListaDeContrasenias.Size = new System.Drawing.Size(490, 273);
            this.panel_ListaDeContrasenias.TabIndex = 1;
            this.panel_ListaDeContrasenias.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ListaDeContrasenias_Paint);
            // 
            // button_Modificar
            // 
            this.button_Modificar.Location = new System.Drawing.Point(10, 247);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(75, 23);
            this.button_Modificar.TabIndex = 1;
            this.button_Modificar.Text = "Modificar";
            this.button_Modificar.UseVisualStyleBackColor = true;
            this.button_Modificar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_Contrasenias
            // 
            this.dataGridView_Contrasenias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Contrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Contrasenias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Usuario,
            this.Contrasenia,
            this.Sitio,
            this.Categoria});
            this.dataGridView_Contrasenias.Location = new System.Drawing.Point(10, 10);
            this.dataGridView_Contrasenias.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView_Contrasenias.Name = "dataGridView_Contrasenias";
            this.dataGridView_Contrasenias.RowHeadersVisible = false;
            this.dataGridView_Contrasenias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Contrasenias.Size = new System.Drawing.Size(470, 235);
            this.dataGridView_Contrasenias.TabIndex = 0;
            this.dataGridView_Contrasenias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Contrasenias_CellContentClick);
            // 
            // Nombre_Usuario
            // 
            this.Nombre_Usuario.HeaderText = "Nombre Usuario";
            this.Nombre_Usuario.Name = "Nombre_Usuario";
            // 
            // Contrasenia
            // 
            this.Contrasenia.HeaderText = "Contraseña";
            this.Contrasenia.Name = "Contrasenia";
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.Name = "Sitio";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Volver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 311);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 30);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(412, 4);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 23);
            this.button_Volver.TabIndex = 0;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // InterfazReporteVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InterfazReporteVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfazReporteVer";
            this.Load += new System.EventHandler(this.InterfazReporteVer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_Titulo.ResumeLayout(false);
            this.panel_ListaDeContrasenias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contrasenias)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_Titulo;
        private System.Windows.Forms.Label label_Titulo;
        private System.Windows.Forms.Panel panel_ListaDeContrasenias;
        private System.Windows.Forms.DataGridView dataGridView_Contrasenias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrasenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.Button button_Modificar;
    }
}