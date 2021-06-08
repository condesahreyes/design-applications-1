namespace InterfazGrafica.InterfacesDeTarjetas
{
    partial class InterfazTarjeta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTarjetasVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridTarjetas = new System.Windows.Forms.DataGridView();
            this.btnEliminarTarjeta = new System.Windows.Forms.Button();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.btnModificarTarjeta = new System.Windows.Forms.Button();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTarjetasVolverMenu
            // 
            this.btnTarjetasVolverMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnTarjetasVolverMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarjetasVolverMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarjetasVolverMenu.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTarjetasVolverMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnTarjetasVolverMenu.Location = new System.Drawing.Point(-1, 333);
            this.btnTarjetasVolverMenu.Name = "btnTarjetasVolverMenu";
            this.btnTarjetasVolverMenu.Size = new System.Drawing.Size(81, 27);
            this.btnTarjetasVolverMenu.TabIndex = 11;
            this.btnTarjetasVolverMenu.Text = "Volver";
            this.btnTarjetasVolverMenu.UseVisualStyleBackColor = false;
            this.btnTarjetasVolverMenu.Click += new System.EventHandler(this.btnTarjetasVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnTarjetasVolverMenu);
            this.panel1.Controls.Add(this.dataGridTarjetas);
            this.panel1.Controls.Add(this.btnEliminarTarjeta);
            this.panel1.Controls.Add(this.lblListadoTarjetas);
            this.panel1.Controls.Add(this.btnModificarTarjeta);
            this.panel1.Controls.Add(this.btnAgregarTarjeta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 362);
            this.panel1.TabIndex = 10;
            // 
            // dataGridTarjetas
            // 
            this.dataGridTarjetas.AllowUserToOrderColumns = true;
            this.dataGridTarjetas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTarjetas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTarjetas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.dataGridTarjetas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridTarjetas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridTarjetas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(124)))), ((int)(((byte)(156)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTarjetas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTarjetas.ColumnHeadersHeight = 40;
            this.dataGridTarjetas.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTarjetas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTarjetas.EnableHeadersVisualStyles = false;
            this.dataGridTarjetas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.dataGridTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridTarjetas.Location = new System.Drawing.Point(40, 47);
            this.dataGridTarjetas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridTarjetas.Name = "dataGridTarjetas";
            this.dataGridTarjetas.ReadOnly = true;
            this.dataGridTarjetas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTarjetas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridTarjetas.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.dataGridTarjetas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTarjetas.RowTemplate.Height = 24;
            this.dataGridTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarjetas.Size = new System.Drawing.Size(461, 232);
            this.dataGridTarjetas.TabIndex = 7;
            // 
            // btnEliminarTarjeta
            // 
            this.btnEliminarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnEliminarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTarjeta.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnEliminarTarjeta.Location = new System.Drawing.Point(419, 301);
            this.btnEliminarTarjeta.Name = "btnEliminarTarjeta";
            this.btnEliminarTarjeta.Size = new System.Drawing.Size(81, 27);
            this.btnEliminarTarjeta.TabIndex = 5;
            this.btnEliminarTarjeta.Text = "Eliminar";
            this.btnEliminarTarjeta.UseVisualStyleBackColor = false;
            this.btnEliminarTarjeta.Click += new System.EventHandler(this.btnEliminarTarjeta_Click);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(319, 7);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(182, 26);
            this.lblListadoTarjetas.TabIndex = 4;
            this.lblListadoTarjetas.Text = "Listado de Tarjetas";
            // 
            // btnModificarTarjeta
            // 
            this.btnModificarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnModificarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarTarjeta.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnModificarTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnModificarTarjeta.Location = new System.Drawing.Point(323, 301);
            this.btnModificarTarjeta.Name = "btnModificarTarjeta";
            this.btnModificarTarjeta.Size = new System.Drawing.Size(81, 27);
            this.btnModificarTarjeta.TabIndex = 3;
            this.btnModificarTarjeta.Text = "Modificar";
            this.btnModificarTarjeta.UseVisualStyleBackColor = false;
            this.btnModificarTarjeta.Click += new System.EventHandler(this.btnModificarTarjeta_Click);
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.btnAgregarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTarjeta.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAgregarTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(225, 301);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(81, 27);
            this.btnAgregarTarjeta.TabIndex = 2;
            this.btnAgregarTarjeta.Text = "Agregar";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = false;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // InterfazTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.panel1);
            this.Name = "InterfazTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarjetas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTarjetasVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminarTarjeta;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.Button btnModificarTarjeta;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridTarjetas;
    }
}