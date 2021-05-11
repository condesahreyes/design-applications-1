
namespace InterfazGrafica.InterfazCompartirContraseñas
{
    partial class InterfazContraseñasCompartidas
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
            this.dataGridContraseñasCompartidas = new System.Windows.Forms.DataGridView();
            this.buttonCompartir = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.buttonVerUsuariosCompartidos = new System.Windows.Forms.Button();
            this.dataGridContraseñasCompartidasConmigo = new System.Windows.Forms.DataGridView();
            this.lblListadoContrasenias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidasConmigo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridContraseñasCompartidas
            // 
            this.dataGridContraseñasCompartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContraseñasCompartidas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridContraseñasCompartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContraseñasCompartidas.Location = new System.Drawing.Point(37, 37);
            this.dataGridContraseñasCompartidas.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridContraseñasCompartidas.Name = "dataGridContraseñasCompartidas";
            this.dataGridContraseñasCompartidas.ReadOnly = true;
            this.dataGridContraseñasCompartidas.RowHeadersVisible = false;
            this.dataGridContraseñasCompartidas.RowHeadersWidth = 51;
            this.dataGridContraseñasCompartidas.RowTemplate.Height = 24;
            this.dataGridContraseñasCompartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContraseñasCompartidas.Size = new System.Drawing.Size(492, 117);
            this.dataGridContraseñasCompartidas.TabIndex = 0;
            this.dataGridContraseñasCompartidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContraseñasCompartidas_CellContentClick);
            // 
            // buttonCompartir
            // 
            this.buttonCompartir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.buttonCompartir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCompartir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompartir.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonCompartir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.buttonCompartir.Location = new System.Drawing.Point(223, 331);
            this.buttonCompartir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCompartir.Name = "buttonCompartir";
            this.buttonCompartir.Size = new System.Drawing.Size(145, 27);
            this.buttonCompartir.TabIndex = 1;
            this.buttonCompartir.Text = "Compartir ";
            this.buttonCompartir.UseVisualStyleBackColor = false;
            this.buttonCompartir.Click += new System.EventHandler(this.buttonCompartir_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.buttonVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolver.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.buttonVolver.Location = new System.Drawing.Point(11, 348);
            this.buttonVolver.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(81, 27);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = false;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonVerUsuariosCompartidos
            // 
            this.buttonVerUsuariosCompartidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.buttonVerUsuariosCompartidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVerUsuariosCompartidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVerUsuariosCompartidos.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonVerUsuariosCompartidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.buttonVerUsuariosCompartidos.Location = new System.Drawing.Point(384, 331);
            this.buttonVerUsuariosCompartidos.Margin = new System.Windows.Forms.Padding(2);
            this.buttonVerUsuariosCompartidos.Name = "buttonVerUsuariosCompartidos";
            this.buttonVerUsuariosCompartidos.Size = new System.Drawing.Size(145, 27);
            this.buttonVerUsuariosCompartidos.TabIndex = 6;
            this.buttonVerUsuariosCompartidos.Text = "Ver Usuarios Compartidos";
            this.buttonVerUsuariosCompartidos.UseVisualStyleBackColor = false;
            this.buttonVerUsuariosCompartidos.Click += new System.EventHandler(this.buttonVerUsuariosCompartidos_Click);
            // 
            // dataGridContraseñasCompartidasConmigo
            // 
            this.dataGridContraseñasCompartidasConmigo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContraseñasCompartidasConmigo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridContraseñasCompartidasConmigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContraseñasCompartidasConmigo.Enabled = false;
            this.dataGridContraseñasCompartidasConmigo.Location = new System.Drawing.Point(37, 193);
            this.dataGridContraseñasCompartidasConmigo.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridContraseñasCompartidasConmigo.Name = "dataGridContraseñasCompartidasConmigo";
            this.dataGridContraseñasCompartidasConmigo.ReadOnly = true;
            this.dataGridContraseñasCompartidasConmigo.RowHeadersVisible = false;
            this.dataGridContraseñasCompartidasConmigo.RowHeadersWidth = 51;
            this.dataGridContraseñasCompartidasConmigo.RowTemplate.Height = 24;
            this.dataGridContraseñasCompartidasConmigo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContraseñasCompartidasConmigo.Size = new System.Drawing.Size(492, 117);
            this.dataGridContraseñasCompartidasConmigo.TabIndex = 7;
            this.dataGridContraseñasCompartidasConmigo.TabStop = false;
            this.dataGridContraseñasCompartidasConmigo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContraseñasCompartidasConmigo_CellContentClick);
            // 
            // lblListadoContrasenias
            // 
            this.lblListadoContrasenias.AutoSize = true;
            this.lblListadoContrasenias.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoContrasenias.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoContrasenias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoContrasenias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoContrasenias.Location = new System.Drawing.Point(284, 9);
            this.lblListadoContrasenias.Name = "lblListadoContrasenias";
            this.lblListadoContrasenias.Size = new System.Drawing.Size(245, 26);
            this.lblListadoContrasenias.TabIndex = 10;
            this.lblListadoContrasenias.Text = "Contraseñas Compartidas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(197, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Contraseñas Compartidas Conmigo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // InterfazContraseñasCompartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblListadoContrasenias);
            this.Controls.Add(this.dataGridContraseñasCompartidasConmigo);
            this.Controls.Add(this.buttonVerUsuariosCompartidos);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonCompartir);
            this.Controls.Add(this.dataGridContraseñasCompartidas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InterfazContraseñasCompartidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compartir Contraseñas";
            this.Load += new System.EventHandler(this.InterfazContraseñasCompartidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidasConmigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridContraseñasCompartidas;
        private System.Windows.Forms.Button buttonCompartir;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.Button buttonVerUsuariosCompartidos;
        private System.Windows.Forms.DataGridView dataGridContraseñasCompartidasConmigo;
        private System.Windows.Forms.Label lblListadoContrasenias;
        private System.Windows.Forms.Label label1;
    }
}