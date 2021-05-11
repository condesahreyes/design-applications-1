
namespace InterfazGrafica.InterfacesReporte
{
    partial class InterfazReportePorCategoria
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_Volver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblListadoTarjetas = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Volver
            // 
            this.button_Volver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.button_Volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Volver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Volver.Font = new System.Drawing.Font("Candara", 11F, System.Drawing.FontStyle.Bold);
            this.button_Volver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(12)))), ((int)(((byte)(44)))));
            this.button_Volver.Location = new System.Drawing.Point(9, 346);
            this.button_Volver.Margin = new System.Windows.Forms.Padding(0);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 31);
            this.button_Volver.TabIndex = 1;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = false;
            this.button_Volver.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(70, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 257);
            this.panel1.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Firebrick;
            series1.Legend = "Legend1";
            series1.Name = "Rojo";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Naranja";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "Amarillo";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.GreenYellow;
            series4.Legend = "Legend1";
            series4.Name = "Verde Claro";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.SeaGreen;
            series5.Legend = "Legend1";
            series5.Name = "Verde Oscuro";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(431, 257);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // lblListadoTarjetas
            // 
            this.lblListadoTarjetas.AutoSize = true;
            this.lblListadoTarjetas.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoTarjetas.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblListadoTarjetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(216)))), ((int)(((byte)(243)))));
            this.lblListadoTarjetas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblListadoTarjetas.Location = new System.Drawing.Point(179, 23);
            this.lblListadoTarjetas.Name = "lblListadoTarjetas";
            this.lblListadoTarjetas.Size = new System.Drawing.Size(372, 26);
            this.lblListadoTarjetas.TabIndex = 12;
            this.lblListadoTarjetas.Text = "Reporte de Contraseñas Por Categorías";
            // 
            // InterfazReportePorCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InterfazGrafica.Properties.Resources.fondo3;
            this.ClientSize = new System.Drawing.Size(563, 386);
            this.Controls.Add(this.lblListadoTarjetas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Volver);
            this.Name = "InterfazReportePorCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Contraseñas Por Categorías";
            this.Load += new System.EventHandler(this.InterfazReportePorCategoria_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblListadoTarjetas;
    }
}