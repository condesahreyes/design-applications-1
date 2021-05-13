
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
            this.lblListadoContrasenias = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosCompartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridUsuariosCompartidos
            // 
            this.dataGridUsuariosCompartidos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridUsuariosCompartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuariosCompartidos.Location = new System.Drawing.Point(143, 72);
            this.dataGridUsuariosCompartidos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridUsuariosCompartidos.Name = "dataGridUsuariosCompartidos";
            this.dataGridUsuariosCompartidos.ReadOnly = true;
            this.dataGridUsuariosCompartidos.RowHeadersVisible = false;
            this.dataGridUsuariosCompartidos.RowHeadersWidth = 51;
            this.dataGridUsuariosCompartidos.RowTemplate.Height = 24;
            this.dataGridUsuariosCompartidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsuariosCompartidos.Size = new System.Drawing.Size(301, 218);
            this.dataGridUsuariosCompartidos.TabIndex = 0;
            // 
            // buttonDejarDeCompartir
            // 
            this.buttonDejarDeCompartir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.buttonDejarDeCompartir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDejarDeCompartir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDejarDeCompartir.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonDejarDeCompartir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.buttonDejarDeCompartir.Location = new System.Drawing.Point(299, 303);
            this.buttonDejarDeCompartir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDejarDeCompartir.Name = "buttonDejarDeCompartir";
            this.buttonDejarDeCompartir.Size = new System.Drawing.Size(145, 27);
            this.buttonDejarDeCompartir.TabIndex = 1;
            this.buttonDejarDeCompartir.Text = "Dejar de Compartir";
            this.buttonDejarDeCompartir.UseVisualStyleBackColor = false;
            this.buttonDejarDeCompartir.Click += new System.EventHandler(this.buttonDejarDeCompartir_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.buttonVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolver.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.buttonVolver.Location = new System.Drawing.Point(28, 337);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(81, 27);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = false;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // lblListadoContrasenias
            // 
            this.lblListadoContrasenias.AutoSize = true;
            this.lblListadoContrasenias.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoContrasenias.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoContrasenias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoContrasenias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoContrasenias.Location = new System.Drawing.Point(227, 26);
            this.lblListadoContrasenias.Name = "lblListadoContrasenias";
            this.lblListadoContrasenias.Size = new System.Drawing.Size(297, 26);
            this.lblListadoContrasenias.TabIndex = 11;
            this.lblListadoContrasenias.Text = "Dejar de compartir contraseñas";
            // 
            // InterfazDejarDeCompartirContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.lblListadoContrasenias);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonDejarDeCompartir);
            this.Controls.Add(this.dataGridUsuariosCompartidos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InterfazDejarDeCompartirContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dejar De Compartir Contraseñas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosCompartidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUsuariosCompartidos;
        private System.Windows.Forms.Button buttonDejarDeCompartir;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Label lblListadoContrasenias;
    }
}