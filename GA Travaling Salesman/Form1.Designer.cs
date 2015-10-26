namespace GA_Travaling_Salesman
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 10D);
            this.BackThreadEvolution = new System.ComponentModel.BackgroundWorker();
            this.progressBarBackThreadEvolution = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGenerations = new System.Windows.Forms.TextBox();
            this.textBoxRuns = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackThreadEvolution
            // 
            this.BackThreadEvolution.WorkerReportsProgress = true;
            this.BackThreadEvolution.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEvolution_DoWork);
            this.BackThreadEvolution.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerEvolution_ProgressChanged);
            this.BackThreadEvolution.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEvolution_RunWorkerCompleted);
            // 
            // progressBarBackThreadEvolution
            // 
            this.progressBarBackThreadEvolution.Location = new System.Drawing.Point(12, 102);
            this.progressBarBackThreadEvolution.Name = "progressBarBackThreadEvolution";
            this.progressBarBackThreadEvolution.Size = new System.Drawing.Size(560, 23);
            this.progressBarBackThreadEvolution.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarBackThreadEvolution.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Generations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Runs";
            // 
            // textBoxGenerations
            // 
            this.textBoxGenerations.Location = new System.Drawing.Point(136, 21);
            this.textBoxGenerations.Name = "textBoxGenerations";
            this.textBoxGenerations.Size = new System.Drawing.Size(100, 20);
            this.textBoxGenerations.TabIndex = 4;
            this.textBoxGenerations.Text = "1000";
            // 
            // textBoxRuns
            // 
            this.textBoxRuns.Location = new System.Drawing.Point(136, 47);
            this.textBoxRuns.Name = "textBoxRuns";
            this.textBoxRuns.Size = new System.Drawing.Size(100, 20);
            this.textBoxRuns.TabIndex = 5;
            this.textBoxRuns.Text = "50";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(123, 73);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(113, 23);
            this.buttonRun.TabIndex = 6;
            this.buttonRun.Text = "Run Simulation";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.toolStripButtonExecute_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(16, 131);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Best Solution";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(547, 569);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 712);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxRuns);
            this.Controls.Add(this.textBoxGenerations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarBackThreadEvolution);
            this.Name = "Form1";
            this.Text = "Traveling Salesman";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BackThreadEvolution;
        private System.Windows.Forms.ProgressBar progressBarBackThreadEvolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGenerations;
        private System.Windows.Forms.TextBox textBoxRuns;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

