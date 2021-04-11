namespace InterfazGrafica
{
    partial class Tarjeta
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
            this.tarjetaVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modificarTarjeta = new System.Windows.Forms.Button();
            this.agregarTarjeta = new System.Windows.Forms.Button();
            this.listaTarjetas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Borrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tarjetaVolverMenu
            // 
            this.tarjetaVolverMenu.Location = new System.Drawing.Point(31, 406);
            this.tarjetaVolverMenu.Name = "tarjetaVolverMenu";
            this.tarjetaVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.tarjetaVolverMenu.TabIndex = 5;
            this.tarjetaVolverMenu.Text = "Volver";
            this.tarjetaVolverMenu.UseVisualStyleBackColor = true;
            this.tarjetaVolverMenu.Click += new System.EventHandler(this.tarjetaVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Borrar);
            this.panel1.Controls.Add(this.modificarTarjeta);
            this.panel1.Controls.Add(this.agregarTarjeta);
            this.panel1.Controls.Add(this.listaTarjetas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 382);
            this.panel1.TabIndex = 4;
            // 
            // modificarTarjeta
            // 
            this.modificarTarjeta.Location = new System.Drawing.Point(453, 340);
            this.modificarTarjeta.Name = "modificarTarjeta";
            this.modificarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.modificarTarjeta.TabIndex = 3;
            this.modificarTarjeta.Text = "Modificar";
            this.modificarTarjeta.UseVisualStyleBackColor = true;
            // 
            // agregarTarjeta
            // 
            this.agregarTarjeta.Location = new System.Drawing.Point(259, 340);
            this.agregarTarjeta.Name = "agregarTarjeta";
            this.agregarTarjeta.Size = new System.Drawing.Size(75, 23);
            this.agregarTarjeta.TabIndex = 2;
            this.agregarTarjeta.Text = "Agregar";
            this.agregarTarjeta.UseVisualStyleBackColor = true;
            // 
            // listaTarjetas
            // 
            this.listaTarjetas.Location = new System.Drawing.Point(40, 72);
            this.listaTarjetas.Name = "listaTarjetas";
            this.listaTarjetas.Size = new System.Drawing.Size(488, 244);
            this.listaTarjetas.TabIndex = 1;
            this.listaTarjetas.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Tarjetas";
            // 
            // Borrar
            // 
            this.Borrar.Location = new System.Drawing.Point(356, 340);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(75, 23);
            this.Borrar.TabIndex = 4;
            this.Borrar.Text = "Borrar";
            this.Borrar.UseVisualStyleBackColor = true;
            // 
            // Tarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 441);
            this.Controls.Add(this.tarjetaVolverMenu);
            this.Controls.Add(this.panel1);
            this.Name = "Tarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjeta";
            this.Load += new System.EventHandler(this.Tarjeta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tarjetaVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Borrar;
        private System.Windows.Forms.Button modificarTarjeta;
        private System.Windows.Forms.Button agregarTarjeta;
        private System.Windows.Forms.ListView listaTarjetas;
        private System.Windows.Forms.Label label1;
    }
}