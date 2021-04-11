namespace InterfazGrafica
{
    partial class UsuarioContrasenia
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
            this.duplasVolverMenu = new System.Windows.Forms.Button();
            this.panelDuplas = new System.Windows.Forms.Panel();
            this.Eliminar = new System.Windows.Forms.Button();
            this.modificarDupla = new System.Windows.Forms.Button();
            this.agregarDupla = new System.Windows.Forms.Button();
            this.listadoDuplas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDuplas.SuspendLayout();
            this.SuspendLayout();
            // 
            // duplasVolverMenu
            // 
            this.duplasVolverMenu.Location = new System.Drawing.Point(31, 406);
            this.duplasVolverMenu.Name = "duplasVolverMenu";
            this.duplasVolverMenu.Size = new System.Drawing.Size(75, 23);
            this.duplasVolverMenu.TabIndex = 5;
            this.duplasVolverMenu.Text = "Volver";
            this.duplasVolverMenu.UseVisualStyleBackColor = true;
            this.duplasVolverMenu.Click += new System.EventHandler(this.duplasVolverMenu_Click);
            // 
            // panelDuplas
            // 
            this.panelDuplas.Controls.Add(this.Eliminar);
            this.panelDuplas.Controls.Add(this.modificarDupla);
            this.panelDuplas.Controls.Add(this.agregarDupla);
            this.panelDuplas.Controls.Add(this.listadoDuplas);
            this.panelDuplas.Controls.Add(this.label1);
            this.panelDuplas.Location = new System.Drawing.Point(12, 12);
            this.panelDuplas.Name = "panelDuplas";
            this.panelDuplas.Size = new System.Drawing.Size(556, 382);
            this.panelDuplas.TabIndex = 4;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(361, 340);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(75, 23);
            this.Eliminar.TabIndex = 4;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // modificarDupla
            // 
            this.modificarDupla.Location = new System.Drawing.Point(453, 340);
            this.modificarDupla.Name = "modificarDupla";
            this.modificarDupla.Size = new System.Drawing.Size(75, 23);
            this.modificarDupla.TabIndex = 3;
            this.modificarDupla.Text = "Modificar";
            this.modificarDupla.UseVisualStyleBackColor = true;
            this.modificarDupla.Click += new System.EventHandler(this.modificarDupla_Click);
            // 
            // agregarDupla
            // 
            this.agregarDupla.Location = new System.Drawing.Point(270, 340);
            this.agregarDupla.Name = "agregarDupla";
            this.agregarDupla.Size = new System.Drawing.Size(75, 23);
            this.agregarDupla.TabIndex = 2;
            this.agregarDupla.Text = "Agregar";
            this.agregarDupla.UseVisualStyleBackColor = true;
            this.agregarDupla.Click += new System.EventHandler(this.agregarDupla_Click);
            // 
            // listadoDuplas
            // 
            this.listadoDuplas.Location = new System.Drawing.Point(40, 73);
            this.listadoDuplas.Name = "listadoDuplas";
            this.listadoDuplas.Size = new System.Drawing.Size(488, 244);
            this.listadoDuplas.TabIndex = 1;
            this.listadoDuplas.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Usuarios/Contraseñas";
            // 
            // UsuarioContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 441);
            this.Controls.Add(this.duplasVolverMenu);
            this.Controls.Add(this.panelDuplas);
            this.Name = "UsuarioContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario/Contraseña";
            this.Load += new System.EventHandler(this.UsuarioContrasenia_Load);
            this.panelDuplas.ResumeLayout(false);
            this.panelDuplas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button duplasVolverMenu;
        private System.Windows.Forms.Panel panelDuplas;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button modificarDupla;
        private System.Windows.Forms.Button agregarDupla;
        private System.Windows.Forms.ListView listadoDuplas;
        private System.Windows.Forms.Label label1;
    }
}