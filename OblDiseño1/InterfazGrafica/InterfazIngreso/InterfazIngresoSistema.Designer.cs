﻿namespace InterfazGrafica.InterfazIngreso
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
            this.button2 = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ingresoSistema);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pssGestor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userGestor);
            this.panel1.Location = new System.Drawing.Point(82, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 264);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Candara Light", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(68, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Nueva contraseña";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(140, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 33);
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
            this.ingresoSistema.Location = new System.Drawing.Point(227, 203);
            this.ingresoSistema.Name = "ingresoSistema";
            this.ingresoSistema.Size = new System.Drawing.Size(89, 23);
            this.ingresoSistema.TabIndex = 5;
            this.ingresoSistema.Text = "Ingresar";
            this.ingresoSistema.UseVisualStyleBackColor = false;
            this.ingresoSistema.Click += new System.EventHandler(this.ingresoSistema_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(128, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // pssGestor
            // 
            this.pssGestor.Location = new System.Drawing.Point(219, 141);
            this.pssGestor.Name = "pssGestor";
            this.pssGestor.Size = new System.Drawing.Size(132, 22);
            this.pssGestor.TabIndex = 4;
            this.pssGestor.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(92, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // userGestor
            // 
            this.userGestor.BackColor = System.Drawing.Color.LavenderBlush;
            this.userGestor.Location = new System.Drawing.Point(219, 88);
            this.userGestor.Name = "userGestor";
            this.userGestor.Size = new System.Drawing.Size(132, 22);
            this.userGestor.TabIndex = 3;
            // 
            // InterfazIngresoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(601, 354);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button button2;
    }
}