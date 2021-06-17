
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Modificar = new System.Windows.Forms.Button();
            this.dataGridView_Contrasenias = new System.Windows.Forms.DataGridView();
            this.Nombre_Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrasenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Volver = new System.Windows.Forms.Button();
            this.label_Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contrasenias)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Modificar
            // 
            this.button_Modificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Modificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Modificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Modificar.Font = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
            this.button_Modificar.Location = new System.Drawing.Point(341, 313);
            this.button_Modificar.Name = "button_Modificar";
            this.button_Modificar.Size = new System.Drawing.Size(175, 31);
            this.button_Modificar.TabIndex = 1;
            this.button_Modificar.Text = "Modificar Contraseña";
            this.button_Modificar.UseVisualStyleBackColor = false;
            this.button_Modificar.Click += new System.EventHandler(this.btnModificarContrasenia_Click);
            // 
            // dataGridView_Contrasenias
            // 
            this.dataGridView_Contrasenias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Contrasenias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.dataGridView_Contrasenias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Contrasenias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView_Contrasenias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Contrasenias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Contrasenias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Contrasenias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Usuario,
            this.Contrasenia,
            this.Sitio,
            this.Categoria});
            this.dataGridView_Contrasenias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView_Contrasenias.EnableHeadersVisualStyles = false;
            this.dataGridView_Contrasenias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.dataGridView_Contrasenias.Location = new System.Drawing.Point(46, 65);
            this.dataGridView_Contrasenias.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView_Contrasenias.Name = "dataGridView_Contrasenias";
            this.dataGridView_Contrasenias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Contrasenias.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Contrasenias.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.dataGridView_Contrasenias.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Contrasenias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Contrasenias.Size = new System.Drawing.Size(470, 235);
            this.dataGridView_Contrasenias.TabIndex = 0;
            // 
            // Nombre_Usuario
            // 
            this.Nombre_Usuario.HeaderText = "Usuario Nombre";
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
            this.Categoria.HeaderText = "Categoría";
            this.Categoria.Name = "Categoria";
            // 
            // button_Volver
            // 
            this.button_Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Volver.Font = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
            this.button_Volver.Location = new System.Drawing.Point(12, 343);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 31);
            this.button_Volver.TabIndex = 0;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = false;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // label_Titulo
            // 
            this.label_Titulo.AutoSize = true;
            this.label_Titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_Titulo.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.label_Titulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Titulo.Location = new System.Drawing.Point(212, 29);
            this.label_Titulo.Name = "label_Titulo";
            this.label_Titulo.Size = new System.Drawing.Size(194, 26);
            this.label_Titulo.TabIndex = 13;
            this.label_Titulo.Text = "Reporte Por Niveles";
            // 
            // InterfazReporteVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.label_Titulo);
            this.Controls.Add(this.dataGridView_Contrasenias);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Modificar);
            this.Name = "InterfazReporteVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Por Niveles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Contrasenias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_Contrasenias;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Modificar;
        private System.Windows.Forms.Label label_Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrasenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
    }
}