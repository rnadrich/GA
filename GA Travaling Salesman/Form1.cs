using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA_Travaling_Salesman
{
    public partial class Form1 : Form
    {
        GeneticAlgorithmn ga = new GeneticAlgorithmn();
        int numOfRunsCompleted = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButtonExecute_Click(object sender, EventArgs e)
        {
            buttonRun.Enabled = false;
            numOfRunsCompleted = 0;
            labelGeneration.Visible = true;
            labelRun.Visible = true;
            chart1.Visible = true;
            chart1.Series.Clear();
            chart1.Series.Add("Best Solution");
            chart1.Series["Best Solution"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            BackThreadEvolution.RunWorkerAsync();
            
        }

        private void backgroundWorkerEvolution_DoWork(object sender, DoWorkEventArgs e)
        {
            ga.pop.runGenerations(Convert.ToInt32(textBoxGenerations.Text),BackThreadEvolution,checkBoxLifeSpan.Checked);
        }

        private void backgroundWorkerEvolution_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarBackThreadEvolution.Value = 100;
            string filename = "";
            if (!checkBoxLifeSpan.Checked) filename = "Run " + numOfRunsCompleted + " Generation " + Population.generationsSoFar + " Death is Disabled Output.txt";
            else filename = "Run " + numOfRunsCompleted + " Generation " + Population.generationsSoFar + " Death is Enabled Output.txt";
            System.IO.File.WriteAllText(filename, "Generation" + Population.generationsSoFar + ")\n" + Population.bestSolution.displayString + Population.bestSolution.fitness);
            buttonRun.Enabled = true;
            numOfRunsCompleted++;
            if (numOfRunsCompleted < Convert.ToInt32(textBoxRuns.Text))
            {
                chart1.Series["Best Solution"].Points.Clear();
                ga.reset();
                BackThreadEvolution.RunWorkerAsync();
            }
        }

        private void backgroundWorkerEvolution_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarBackThreadEvolution.Value = e.ProgressPercentage;
            labelGeneration.Text = "Current Generation: " + Population.generationsSoFar;
            labelRun.Text = "Current Run: " + numOfRunsCompleted;
            if(Population.bestHasChanged == true && Population.bestSolution!=null)
            {
                chart1.Series["Best Solution"].Points.Clear();
                foreach (City c in Population.bestSolution.genome)
                {
                    int x=c.location.Item1,
                        y=c.location.Item2;
                    chart1.Series["Best Solution"].Points.AddXY(x, y);
                }
            }
        }

        private void buttonRESET_Click(object sender, EventArgs e)
        {
            ga.reset();
        }




    }
}
