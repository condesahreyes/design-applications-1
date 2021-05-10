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
            this.btnTarjetasVolverMenu.Location = new System.Drawing.Point(16, 377);
            this.btnTarjetasVolverMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarjetasVolverMenu.Name = "btnTarjetasVolverMenu";
            this.btnTarjetasVolverMenu.Size = new System.Drawing.Size(100, 28);
            this.btnTarjetasVolverMenu.TabIndex = 11;
            this.btnTarjetasVolverMenu.Text = "Volver";
            this.btnTarjetasVolverMenu.UseVisualStyleBackColor = true;
            this.btnTarjetasVolverMenu.Click += new System.EventHandler(this.btnTarjetasVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dataGridTarjetas);
            this.panel1.Controls.Add(this.btnEliminarTarjeta);
            this.panel1.Controls.Add(this.lblListadoTarjetas);
            this.panel1.Controls.Add(this.btnModificarTarjeta);
            this.panel1.Controls.Add(this.btnAgregarTarjeta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 354);
            this.panel1.TabIndex = 10;
            // 
            // dataGridTarjetas
            // 
            this.dataGridTarjetas.AllowUserToOrderColumns = true;
            this.dataGridTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridTarjetas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTarjetas.Location = new System.Drawing.Point(13, 58);
            this.dataGridTarjetas.Name = "dataGridTarjetas";
            this.dataGridTarjetas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridTarjetas.RowTemplate.Height = 24;
            this.dataGridTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarjetas.Size = new System.Drawing.Size(615, 245);
            this.dataGridTarjetas.TabIndex = 7;
            this.dataGridTarjetas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTarjetas_CellContentClick);
            // 
            // btnEliminarTarjeta
            // 
            this.btnEliminarTarjeta.Location = new System.Drawing.Point(517, 322);
            this.btnEliminarTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarTarjeta.Name = "btnEliminarTarjeta";
            this.btnEliminarTarjeta.Size = new System.Drawing.Size(100, 28);
            this.btnEliminarTarjeta.TabIndex = 5;
            this.btnEliminarTarjeta.Text = "Eliminar";
            this.btnEliminarTarjeta.UseVisualStyleBackColor = true;
            this.btnEliminarTarjeta.Click += new System.EventHandler(this.btnEliminarTarjeta_Click);
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(20, 9);
            this.lblListadoTarjetas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(231, 33);
            this.lblListadoTarjetas.TabIndex = 4;
            this.lblListadoTarjetas.Text = "Listado de Tarjetas";
            // 
            // btnModificarTarjeta
            // 
            this.btnModificarTarjeta.Location = new System.Drawing.Point(409, 322);
            this.btnModificarTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarTarjeta.Name = "btnModificarTarjeta";
            this.btnModificarTarjeta.Size = new System.Drawing.Size(100, 28);
            this.btnModificarTarjeta.TabIndex = 3;
            this.btnModificarTarjeta.Text = "Modificar";
            this.btnModificarTarjeta.UseVisualStyleBackColor = true;
            this.btnModificarTarjeta.Click += new System.EventHandler(this.btnModificarTarjeta_Click);
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(301, 322);
            this.btnAgregarTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(100, 28);
            this.btnAgregarTarjeta.TabIndex = 2;
            this.btnAgregarTarjeta.Text = "Agregar";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            this.btnAgregarTarjeta.Click += new System.EventHandler(this.btnAgregarTarjeta_Click);
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
            // InterfazTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(783, 420);
            this.Controls.Add(this.btnTarjetasVolverMenu);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InterfazTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas";
            this.Load += new System.EventHandler(this.InterfazTarjeta_Load);
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