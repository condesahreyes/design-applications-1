namespace InterfazGrafica
{
    partial class Categoria
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
            this.catVolverMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.modificarCat = new System.Windows.Forms.Button();
            this.agregarCat = new System.Windows.Forms.Button();
            this.listaCategorias = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // catVolverMenu
            // 
            this.catVolverMenu.Location = new System.Drawing.Point(31, 406);
            this.catVolverMenu.Name = "catVolverMenu";
            this.catVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.catVolverMenu.TabIndex = 3;
            this.catVolverMenu.Text = "Volver";
            this.catVolverMenu.UseVisualStyleBackColor = true;
            this.catVolverMenu.Click += new System.EventHandler(this.catVolverMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.modificarCat);
            this.panel1.Controls.Add(this.agregarCat);
            this.panel1.Controls.Add(this.listaCategorias);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 382);
            this.panel1.TabIndex = 2;
            // 
            // modificarCat
            // 
            this.modificarCat.Location = new System.Drawing.Point(453, 340);
            this.modificarCat.Name = "modificarCat";
            this.modificarCat.Size = new System.Drawing.Size(75, 23);
            this.modificarCat.TabIndex = 3;
            this.modificarCat.Text = "Modificar";
            this.modificarCat.UseVisualStyleBackColor = true;
            this.modificarCat.Click += new System.EventHandler(this.modificarCat_Click);
            // 
            // agregarCat
            // 
            this.agregarCat.Location = new System.Drawing.Point(350, 340);
            this.agregarCat.Name = "agregarCat";
            this.agregarCat.Size = new System.Drawing.Size(75, 23);
            this.agregarCat.TabIndex = 2;
            this.agregarCat.Text = "Agregar";
            this.agregarCat.UseVisualStyleBackColor = true;
            this.agregarCat.Click += new System.EventHandler(this.agregarCat_Click);
            // 
            // listaCategorias
            // 
            this.listaCategorias.Location = new System.Drawing.Point(40, 72);
            this.listaCategorias.Name = "listaCategorias";
            this.listaCategorias.Size = new System.Drawing.Size(488, 244);
            this.listaCategorias.TabIndex = 1;
            this.listaCategorias.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Categorías";
            // 
            // Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 441);
            this.Controls.Add(this.catVolverMenu);
            this.Controls.Add(this.panel1);
            this.Name = "Categoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorías";
            this.Load += new System.EventHandler(this.Categoria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button catVolverMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button modificarCat;
        private System.Windows.Forms.Button agregarCat;
        private System.Windows.Forms.ListView listaCategorias;
        private System.Windows.Forms.Label label1;
    }
}

