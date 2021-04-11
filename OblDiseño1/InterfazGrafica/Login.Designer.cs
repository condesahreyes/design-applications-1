namespace InterfazGrafica
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.ingresoSistema = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pssGestor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userGestor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ingresoSistema);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pssGestor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userGestor);
            this.panel1.Location = new System.Drawing.Point(48, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 236);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(62, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso al sistema";
            // 
            // ingresoSistema
            // 
            this.ingresoSistema.BackColor = System.Drawing.SystemColors.Menu;
            this.ingresoSistema.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ingresoSistema.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ingresoSistema.Location = new System.Drawing.Point(121, 193);
            this.ingresoSistema.Name = "ingresoSistema";
            this.ingresoSistema.Size = new System.Drawing.Size(75, 23);
            this.ingresoSistema.TabIndex = 5;
            this.ingresoSistema.Text = "Ingresar";
            this.ingresoSistema.UseVisualStyleBackColor = false;
            this.ingresoSistema.Click += new System.EventHandler(this.ingresoSistema_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // pssGestor
            // 
            this.pssGestor.Location = new System.Drawing.Point(167, 129);
            this.pssGestor.Name = "pssGestor";
            this.pssGestor.Size = new System.Drawing.Size(100, 20);
            this.pssGestor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // userGestor
            // 
            this.userGestor.Location = new System.Drawing.Point(167, 79);
            this.userGestor.Name = "userGestor";
            this.userGestor.Size = new System.Drawing.Size(100, 20);
            this.userGestor.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 291);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ingresoSistema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pssGestor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userGestor;
    }
}