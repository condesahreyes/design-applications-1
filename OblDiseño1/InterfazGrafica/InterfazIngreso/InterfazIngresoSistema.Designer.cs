namespace InterfazGrafica.InterfazIngreso
{
    partial class InterfazIngresoSistema
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
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ingresoSistema);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pssGestor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userGestor);
            this.panel1.Location = new System.Drawing.Point(141, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 236);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(91, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingreso al sistema";
            // 
            // ingresoSistema
            // 
            this.ingresoSistema.BackColor = System.Drawing.Color.Transparent;
            this.ingresoSistema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ingresoSistema.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ingresoSistema.FlatAppearance.BorderSize = 0;
            this.ingresoSistema.Font = new System.Drawing.Font("Candara Light", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(76, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
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
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(40, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // userGestor
            // 
            this.userGestor.BackColor = System.Drawing.Color.LavenderBlush;
            this.userGestor.Location = new System.Drawing.Point(167, 76);
            this.userGestor.Name = "userGestor";
            this.userGestor.Size = new System.Drawing.Size(100, 20);
            this.userGestor.TabIndex = 3;
            // 
            // InterfazIngresoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(451, 288);
            this.Controls.Add(this.panel1);
            this.Name = "InterfazIngresoSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso al Sistema";
            this.Load += new System.EventHandler(this.InterfazIngresoSistema_Load);
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