namespace InterfazGrafica
{
    partial class Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.compartirPss = new System.Windows.Forms.Button();
            this.reporte = new System.Windows.Forms.Button();
            this.dataBreaches = new System.Windows.Forms.Button();
            this.tarjetas = new System.Windows.Forms.Button();
            this.duplasPss = new System.Windows.Forms.Button();
            this.categoria = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.compartirPss);
            this.panel1.Controls.Add(this.reporte);
            this.panel1.Controls.Add(this.dataBreaches);
            this.panel1.Controls.Add(this.tarjetas);
            this.panel1.Controls.Add(this.duplasPss);
            this.panel1.Controls.Add(this.categoria);
            this.panel1.Location = new System.Drawing.Point(81, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 375);
            this.panel1.TabIndex = 1;
            // 
            // compartirPss
            // 
            this.compartirPss.Location = new System.Drawing.Point(142, 323);
            this.compartirPss.Name = "compartirPss";
            this.compartirPss.Size = new System.Drawing.Size(126, 38);
            this.compartirPss.TabIndex = 5;
            this.compartirPss.Text = "Compartir contraseña";
            this.compartirPss.UseVisualStyleBackColor = true;
            // 
            // reporte
            // 
            this.reporte.Location = new System.Drawing.Point(142, 265);
            this.reporte.Name = "reporte";
            this.reporte.Size = new System.Drawing.Size(126, 38);
            this.reporte.TabIndex = 4;
            this.reporte.Text = "Reporte";
            this.reporte.UseVisualStyleBackColor = true;
            // 
            // dataBreaches
            // 
            this.dataBreaches.Location = new System.Drawing.Point(142, 205);
            this.dataBreaches.Name = "dataBreaches";
            this.dataBreaches.Size = new System.Drawing.Size(126, 38);
            this.dataBreaches.TabIndex = 3;
            this.dataBreaches.Text = "Data Breaches";
            this.dataBreaches.UseVisualStyleBackColor = true;
            // 
            // tarjetas
            // 
            this.tarjetas.Location = new System.Drawing.Point(142, 138);
            this.tarjetas.Name = "tarjetas";
            this.tarjetas.Size = new System.Drawing.Size(126, 38);
            this.tarjetas.TabIndex = 2;
            this.tarjetas.Text = "Tarjetas de Credito";
            this.tarjetas.UseVisualStyleBackColor = true;
            // 
            // duplasPss
            // 
            this.duplasPss.Location = new System.Drawing.Point(142, 70);
            this.duplasPss.Name = "duplasPss";
            this.duplasPss.Size = new System.Drawing.Size(126, 38);
            this.duplasPss.TabIndex = 1;
            this.duplasPss.Text = "Contraseñas";
            this.duplasPss.UseVisualStyleBackColor = true;
            this.duplasPss.Click += new System.EventHandler(this.duplasPss_Click);
            // 
            // categoria
            // 
            this.categoria.Location = new System.Drawing.Point(142, 3);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(126, 38);
            this.categoria.TabIndex = 0;
            this.categoria.Text = "Categoría";
            this.categoria.UseVisualStyleBackColor = true;
            this.categoria.Click += new System.EventHandler(this.categoria_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 441);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button compartirPss;
        private System.Windows.Forms.Button reporte;
        private System.Windows.Forms.Button dataBreaches;
        private System.Windows.Forms.Button tarjetas;
        private System.Windows.Forms.Button duplasPss;
        private System.Windows.Forms.Button categoria;
    }
}