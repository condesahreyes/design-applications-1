
namespace InterfazGrafica.InterfacesDeContrasenias
{
    partial class Interfaz_MostrarContrasenia
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
            this.textBox_contrasenia = new System.Windows.Forms.TextBox();
            this.button_Volver = new System.Windows.Forms.Button();
            this.lblListadoContrasenias = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_contrasenia
            // 
            this.textBox_contrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_contrasenia.Location = new System.Drawing.Point(139, 53);
            this.textBox_contrasenia.Name = "textBox_contrasenia";
            this.textBox_contrasenia.Size = new System.Drawing.Size(377, 31);
            this.textBox_contrasenia.TabIndex = 0;
            // 
            // button_Volver
            // 
            this.button_Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Volver.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.button_Volver.Location = new System.Drawing.Point(12, 145);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(81, 27);
            this.button_Volver.TabIndex = 11;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = false;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // lblListadoContrasenias
            // 
            this.lblListadoContrasenias.AutoSize = true;
            this.lblListadoContrasenias.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoContrasenias.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoContrasenias.ForeColor = System.Drawing.Color.Black;
            this.lblListadoContrasenias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoContrasenias.Location = new System.Drawing.Point(12, 58);
            this.lblListadoContrasenias.Name = "lblListadoContrasenias";
            this.lblListadoContrasenias.Size = new System.Drawing.Size(121, 26);
            this.lblListadoContrasenias.TabIndex = 12;
            this.lblListadoContrasenias.Text = "Contraseña:";
            // 
            // Interfaz_MostrarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 184);
            this.Controls.Add(this.lblListadoContrasenias);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.textBox_contrasenia);
            this.Name = "Interfaz_MostrarContrasenia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_contrasenia;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Label lblListadoContrasenias;
    }
}