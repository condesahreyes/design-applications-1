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
            this.btnEliminarTarjeta = new System.Windows.Forms.Button();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.btnModificarTarjeta = new System.Windows.Forms.Button();
            this.btnAgregarTarjeta = new System.Windows.Forms.Button();
            this.listaTarjetas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTarjetasVolverMenu
            // 
            this.btnTarjetasVolverMenu.Location = new System.Drawing.Point(12, 306);
            this.btnTarjetasVolverMenu.Name = "btnTarjetasVolverMenu";
            this.btnTarjetasVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.btnTarjetasVolverMenu.TabIndex = 11;
            this.btnTarjetasVolverMenu.Text = "Volver";
            this.btnTarjetasVolverMenu.UseVisualStyleBackColor = true;
            this.btnTarjetasVolverMenu.Click += new System.EventHandler(this.btnTarjetasVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnEliminarTarjeta);
            this.panel1.Controls.Add(this.lblListadoTarjetas);
            this.panel1.Controls.Add(this.btnModificarTarjeta);
            this.panel1.Controls.Add(this.btnAgregarTarjeta);
            this.panel1.Controls.Add(this.listaTarjetas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 288);
            this.panel1.TabIndex = 10;
            // 
            // btnEliminarTarjeta
            // 
            this.btnEliminarTarjeta.Location = new System.Drawing.Point(388, 262);
            this.btnEliminarTarjeta.Name = "btnEliminarTarjeta";
            this.btnEliminarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarTarjeta.TabIndex = 5;
            this.btnEliminarTarjeta.Text = "Eliminar";
            this.btnEliminarTarjeta.UseVisualStyleBackColor = true;
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(15, 7);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(182, 26);
            this.lblListadoTarjetas.TabIndex = 4;
            this.lblListadoTarjetas.Text = "Listado de Tarjetas";
            // 
            // btnModificarTarjeta
            // 
            this.btnModificarTarjeta.Location = new System.Drawing.Point(307, 262);
            this.btnModificarTarjeta.Name = "btnModificarTarjeta";
            this.btnModificarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.btnModificarTarjeta.TabIndex = 3;
            this.btnModificarTarjeta.Text = "Modificar";
            this.btnModificarTarjeta.UseVisualStyleBackColor = true;
            // 
            // btnAgregarTarjeta
            // 
            this.btnAgregarTarjeta.Location = new System.Drawing.Point(226, 262);
            this.btnAgregarTarjeta.Name = "btnAgregarTarjeta";
            this.btnAgregarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTarjeta.TabIndex = 2;
            this.btnAgregarTarjeta.Text = "Agregar";
            this.btnAgregarTarjeta.UseVisualStyleBackColor = true;
            // 
            // listaTarjetas
            // 
            this.listaTarjetas.Location = new System.Drawing.Point(20, 51);
            this.listaTarjetas.Name = "listaTarjetas";
            this.listaTarjetas.Size = new System.Drawing.Size(427, 189);
            this.listaTarjetas.TabIndex = 1;
            this.listaTarjetas.UseCompatibleStateImageBehavior = false;
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
            this.ClientSize = new System.Drawing.Size(490, 341);
            this.Controls.Add(this.btnTarjetasVolverMenu);
            this.Controls.Add(this.panel1);
            this.Name = "InterfazTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas";
            this.Load += new System.EventHandler(this.InterfazTarjeta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTarjetasVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminarTarjeta;
        private System.Windows.Forms.Label lblListadoTarjetas;
        private System.Windows.Forms.Button btnModificarTarjeta;
        private System.Windows.Forms.Button btnAgregarTarjeta;
        private System.Windows.Forms.ListView listaTarjetas;
        private System.Windows.Forms.Label label1;
    }
}