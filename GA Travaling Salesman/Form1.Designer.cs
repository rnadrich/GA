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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BackThreadEvolution = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExecute = new System.Windows.Forms.ToolStripButton();
            this.progressBarBackThreadEvolution = new System.Windows.Forms.ProgressBar();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackThreadEvolution
            // 
            this.BackThreadEvolution.WorkerReportsProgress = true;
            this.BackThreadEvolution.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerEvolution_DoWork);
            this.BackThreadEvolution.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerEvolution_ProgressChanged);
            this.BackThreadEvolution.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerEvolution_RunWorkerCompleted);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExecute});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(523, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonExecute
            // 
            this.toolStripButtonExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExecute.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExecute.Image")));
            this.toolStripButtonExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExecute.Name = "toolStripButtonExecute";
            this.toolStripButtonExecute.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExecute.Text = "toolStripButtonExecute";
            this.toolStripButtonExecute.Click += new System.EventHandler(this.toolStripButtonExecute_Click);
            // 
            // progressBarBackThreadEvolution
            // 
            this.progressBarBackThreadEvolution.Location = new System.Drawing.Point(12, 308);
            this.progressBarBackThreadEvolution.Name = "progressBarBackThreadEvolution";
            this.progressBarBackThreadEvolution.Size = new System.Drawing.Size(499, 23);
            this.progressBarBackThreadEvolution.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarBackThreadEvolution.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 343);
            this.Controls.Add(this.progressBarBackThreadEvolution);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Traveling Salesman";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BackThreadEvolution;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExecute;
        private System.Windows.Forms.ProgressBar progressBarBackThreadEvolution;
    }
}

