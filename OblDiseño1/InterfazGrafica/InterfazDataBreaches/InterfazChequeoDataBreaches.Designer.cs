namespace InterfazGrafica.InterfazDataBreaches
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
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextBoxDatosDataBreaches = new System.Windows.Forms.RichTextBox();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContraseniaVolverMenu = new System.Windows.Forms.Button();
            this.btnChequear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridContrasenias = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContrasenias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTarjetas
            // 
            this.dataGridTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarjetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoria,
            this.Sitio,
            this.Nombre});
            this.dataGridTarjetas.Location = new System.Drawing.Point(227, 83);
            this.dataGridTarjetas.Name = "dataGridTarjetas";
            this.dataGridTarjetas.RowHeadersWidth = 4;
            this.dataGridTarjetas.Size = new System.Drawing.Size(251, 100);
            this.dataGridTarjetas.TabIndex = 0;
            // 
            // categoria
            // 
            this.categoria.HeaderText = "Categoría";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // Sitio
            // 
            this.Sitio.HeaderText = "Sitio";
            this.Sitio.Name = "Sitio";
            this.Sitio.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre Usuario";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // TextBoxDatosDataBreaches
            // 
            this.TextBoxDatosDataBreaches.Location = new System.Drawing.Point(12, 83);
            this.TextBoxDatosDataBreaches.Name = "TextBoxDatosDataBreaches";
            this.TextBoxDatosDataBreaches.Size = new System.Drawing.Size(191, 206);
            this.TextBoxDatosDataBreaches.TabIndex = 1;
            this.TextBoxDatosDataBreaches.Text = "";
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(222, 9);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(256, 26);
            this.lblListadoTarjetas.TabIndex = 11;
            this.lblListadoTarjetas.Text = "Chequeo de Data Breaches";
            this.lblListadoTarjetas.Click += new System.EventHandler(this.lblListadoTarjetas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Ingrese aqui su texto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnContraseniaVolverMenu
            // 
            this.btnContraseniaVolverMenu.Location = new System.Drawing.Point(12, 306);
            this.btnContraseniaVolverMenu.Name = "btnContraseniaVolverMenu";
            this.btnContraseniaVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.btnContraseniaVolverMenu.TabIndex = 26;
            this.btnContraseniaVolverMenu.Text = "Volver";
            this.btnContraseniaVolverMenu.UseVisualStyleBackColor = true;
            // 
            // btnChequear
            // 
            this.btnChequear.Location = new System.Drawing.Point(128, 306);
            this.btnChequear.Name = "btnChequear";
            this.btnChequear.Size = new System.Drawing.Size(75, 23);
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
            this.label2.Location = new System.Drawing.Point(266, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tarjetas Vulneradas";
            // 
            // dataGridContrasenias
            // 
            this.dataGridContrasenias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContrasenias.Location = new System.Drawing.Point(227, 229);
            this.dataGridContrasenias.Name = "dataGridContrasenias";
            this.dataGridContrasenias.Size = new System.Drawing.Size(251, 100);
            this.dataGridContrasenias.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(238, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 22);
            this.label3.TabIndex = 31;
            this.label3.Text = "Contraseñas vulnderadas";
            // 
            // InterfazChequeoDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridContrasenias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChequear);
            this.Controls.Add(this.btnContraseniaVolverMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.TextBoxDatosDataBreaches);
            this.Controls.Add(this.dataGridTarjetas);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContraseniaVolverMenu;
        private System.Windows.Forms.Button btnChequear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridContrasenias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}