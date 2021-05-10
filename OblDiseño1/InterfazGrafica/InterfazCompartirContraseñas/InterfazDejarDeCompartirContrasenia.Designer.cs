
namespace InterfazGrafica.InterfazCompartirContraseñas
{
    partial class InterfazDejarDeCompartirContrasenia
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
            this.dataGridUsuariosCompartidos = new System.Windows.Forms.DataGridView();
            this.buttonDejarDeCompartir = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosCompartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsuariosCompartidos
            // 
            this.dataGridUsuariosCompartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuariosCompartidos.Location = new System.Drawing.Point(43, 39);
            this.dataGridUsuariosCompartidos.Name = "dataGridUsuariosCompartidos";
            this.dataGridUsuariosCompartidos.RowHeadersWidth = 51;
            this.dataGridUsuariosCompartidos.RowTemplate.Height = 24;
            this.dataGridUsuariosCompartidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsuariosCompartidos.Size = new System.Drawing.Size(255, 260);
            this.dataGridUsuariosCompartidos.TabIndex = 0;
            this.dataGridUsuariosCompartidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUsuariosCompartidos_CellContentClick);
            // 
            // buttonDejarDeCompartir
            // 
            this.buttonDejarDeCompartir.Location = new System.Drawing.Point(24, 326);
            this.buttonDejarDeCompartir.Name = "buttonDejarDeCompartir";
            this.buttonDejarDeCompartir.Size = new System.Drawing.Size(151, 34);
            this.buttonDejarDeCompartir.TabIndex = 1;
            this.buttonDejarDeCompartir.Text = "Dejar de Compartir";
            this.buttonDejarDeCompartir.UseVisualStyleBackColor = true;
            this.buttonDejarDeCompartir.Click += new System.EventHandler(this.buttonDejarDeCompartir_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(221, 326);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(115, 35);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // InterfazDejarDeCompartirContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 373);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonDejarDeCompartir);
            this.Controls.Add(this.dataGridUsuariosCompartidos);
            this.Name = "InterfazDejarDeCompartirContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfazDejarDeCompartirContrasenia";
            this.Load += new System.EventHandler(this.InterfazDejarDeCompartirContrasenia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosCompartidos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsuariosCompartidos;
        private System.Windows.Forms.Button buttonDejarDeCompartir;
        private System.Windows.Forms.Button buttonVolver;
    }
}