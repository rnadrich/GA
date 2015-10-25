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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButtonExecute_Click(object sender, EventArgs e)
        {
            toolStripButtonExecute.Enabled = false;
            BackThreadEvolution.RunWorkerAsync();
           

        }

        private void backgroundWorkerEvolution_DoWork(object sender, DoWorkEventArgs e)
        {
            
            GeneticAlgorithmn ga = new GeneticAlgorithmn();
            ga.pop.runGenerations(100);
        }

        private void backgroundWorkerEvolution_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripButtonExecute.Enabled = true;
            progressBarBackThreadEvolution.Value = 100;
            System.IO.File.WriteAllText("Output.txt", "Generation"+Population.generationsSoFar+ ")" +Population.bestSolution.displayString + ":" + Population.bestSolution.fitness);
        }

        private void backgroundWorkerEvolution_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarBackThreadEvolution.Value = e.ProgressPercentage;
        }




    }
}
