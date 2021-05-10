
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridContraseñasCompartidasConmigo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridContraseñasCompartidas
            // 
            this.dataGridContraseñasCompartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContraseñasCompartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContraseñasCompartidas.Location = new System.Drawing.Point(41, 46);
            this.dataGridContraseñasCompartidas.Name = "dataGridContraseñasCompartidas";
            this.dataGridContraseñasCompartidas.RowHeadersWidth = 51;
            this.dataGridContraseñasCompartidas.RowTemplate.Height = 24;
            this.dataGridContraseñasCompartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContraseñasCompartidas.Size = new System.Drawing.Size(868, 162);
            this.dataGridContraseñasCompartidas.TabIndex = 0;
            this.dataGridContraseñasCompartidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContraseñasCompartidas_CellContentClick);
            // 
            // buttonCompartir
            // 
            this.buttonCompartir.Location = new System.Drawing.Point(616, 446);
            this.buttonCompartir.Name = "buttonCompartir";
            this.buttonCompartir.Size = new System.Drawing.Size(121, 31);
            this.buttonCompartir.TabIndex = 1;
            this.buttonCompartir.Text = "Compartir ";
            this.buttonCompartir.UseVisualStyleBackColor = true;
            this.buttonCompartir.Click += new System.EventHandler(this.buttonCompartir_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Location = new System.Drawing.Point(759, 446);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(121, 31);
            this.buttonVolver.TabIndex = 2;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // buttonVerUsuariosCompartidos
            // 
            this.buttonVerUsuariosCompartidos.Location = new System.Drawing.Point(409, 446);
            this.buttonVerUsuariosCompartidos.Name = "buttonVerUsuariosCompartidos";
            this.buttonVerUsuariosCompartidos.Size = new System.Drawing.Size(181, 31);
            this.buttonVerUsuariosCompartidos.TabIndex = 6;
            this.buttonVerUsuariosCompartidos.Text = "Ver Usuarios Compartidos";
            this.buttonVerUsuariosCompartidos.UseVisualStyleBackColor = true;
            this.buttonVerUsuariosCompartidos.Click += new System.EventHandler(this.buttonVerUsuariosCompartidos_Click);
            // 
            // dataGridContraseñasCompartidasConmigo
            // 
            this.dataGridContraseñasCompartidasConmigo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridContraseñasCompartidasConmigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridContraseñasCompartidasConmigo.Enabled = false;
            this.dataGridContraseñasCompartidasConmigo.Location = new System.Drawing.Point(41, 259);
            this.dataGridContraseñasCompartidasConmigo.Name = "dataGridContraseñasCompartidasConmigo";
            this.dataGridContraseñasCompartidasConmigo.ReadOnly = true;
            this.dataGridContraseñasCompartidasConmigo.RowHeadersWidth = 51;
            this.dataGridContraseñasCompartidasConmigo.RowTemplate.Height = 24;
            this.dataGridContraseñasCompartidasConmigo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridContraseñasCompartidasConmigo.Size = new System.Drawing.Size(868, 162);
            this.dataGridContraseñasCompartidasConmigo.TabIndex = 7;
            this.dataGridContraseñasCompartidasConmigo.TabStop = false;
            this.dataGridContraseñasCompartidasConmigo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridContraseñasCompartidasConmigo_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Contraseñas Compartidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Contraseñas Compartidas Conmigo";
            // 
            // InterfazContraseñasCompartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridContraseñasCompartidasConmigo);
            this.Controls.Add(this.buttonVerUsuariosCompartidos);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonCompartir);
            this.Controls.Add(this.dataGridContraseñasCompartidas);
            this.Name = "InterfazContraseñasCompartidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InterfazContraseñasCompartidas";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}