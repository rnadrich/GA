using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*TODO:
 * Work on UI more
 * have it run and clear for 50 different populations
 * 
 * 
namespace GA_Travaling_Salesman
{
    public partial class Form1 : Form
    {
        GeneticAlgorithmn ga = new GeneticAlgorithmn();
        int count = 0;
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
            

            ga.pop.runGenerations(10,BackThreadEvolution);
        }

        private void backgroundWorkerEvolution_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (count < 10)
            {
                count++;
                toolStripButtonExecute.Enabled = true;
                progressBarBackThreadEvolution.Value = 100;
                System.IO.File.WriteAllText("Generation " + Population.generationsSoFar + " Output.txt", "Generation" + Population.generationsSoFar + ")\n" + Population.bestSolution.displayString + Population.bestSolution.fitness);
                toolStripButtonExecute.Enabled = false;
                BackThreadEvolution.RunWorkerAsync();
            }
            else
            {
                count = 0;
                toolStripButtonExecute.Enabled = true;
                progressBarBackThreadEvolution.Value = 100;
                System.IO.File.WriteAllText("Generation " + Population.generationsSoFar + " Output.txt", "Generation" + Population.generationsSoFar + ")\n" + Population.bestSolution.displayString + Population.bestSolution.fitness);
            }
            
        }

        private void backgroundWorkerEvolution_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarBackThreadEvolution.Value = e.ProgressPercentage;
        }




    }
}
