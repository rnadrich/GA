using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GA_Travaling_Salesman
{
    class Population
    {
        static public List<City> CitiesToVisit = new List<City>();
        List<Solution> solutionList = new List<Solution>();
        static public Solution bestSolution= new Solution();
        static public bool bestHasChanged = false;
        static SoundPlayer soundPlayer = new SoundPlayer("GameOver.wav");
        public static int generationsSoFar = 0;

        public Population()
        {
            initializePopulation();
            bestSolution = new Solution();
            bestHasChanged = false;
            generationsSoFar = 0;
        }


        void runGeneration()
        {
            Tournaments();
            Mutate();
            generationsSoFar++;
        }

        private void Mutate()
        {
            foreach (Solution s in solutionList)
            {
                if(G.chance(G.probabilityOfSolutionMutation))
                {
                    s.Mutate();
                }
            }
        }
        private void Tournaments()
        {
            Shuffle();
            for (int i = 0; i < solutionList.Count()-4; i += 4)
            {
                RunOneTournament(i);
            }
        }

        private void RunOneTournament(int start)
        {
            solutionList.Sort(start, 4, null);
            Mate(start);
        }

        private void Mate(int start)
        {
            int cross1 = G.rand(G.target_size);
            int cross2 = cross1;
            while(cross1==cross2) cross2 = G.rand(G.target_size);
            if (cross1 > cross2) SwapInt(ref cross1,ref cross2);

            Solution parent1 = solutionList[start];
            Solution parent2 = solutionList[start+1];

            string child1string="";
            string child2string="";

            for(int i=0;i<G.target_size;i++)
            {
                if((i<cross1)||(i>cross2))
                {
                    child1string += parent1.genome[i];
                    child2string += parent2.genome[i];
                }
                else
                {
                    child1string += parent2.genome[i];
                    child2string += parent1.genome[i];
                }
            }
            solutionList[start + 2].genome = child1string;
            solutionList[start + 3].genome = child2string;

            Problem.Evaluate(solutionList[start + 2]);
            Problem.Evaluate(solutionList[start + 3]);
        }



        private void Evaluate()
        {
            foreach(Solution s in solutionList)
            {
                Problem.Evaluate(s);
            }
        }

        bool runningInBackground = true;

        public void runGenerations(int howMany, BackgroundWorker bWorker)
        {
            runningInBackground = true;
            for (int i = 0; i < howMany; i++)
            {
                runGeneration();
                if (Problem.isOptimal(bestSolution))
                {
                    soundPlayer.Play();
                    break;
                }
                int percentage = (int)(100.0 * (((double)i) / ((double)howMany)));
                bWorker.ReportProgress(percentage);
            }
        }
        public void runGenerations(int howMany)
        {
            runningInBackground = false;
            for (int i = 0; i < howMany; i++)
            {
                runGeneration();
                if (Problem.isOptimal(bestSolution))
                {
                    soundPlayer.Play();
                    break;
                }
                int percentage = (int)(100.0 * (((double)i) / ((double)howMany)));
            }
        }
        void initializePopulation()
        {
            generateCitiesToVisit();
            for(int i=0;i<G.population_size;i++)
            {
                Solution sol = new Solution();
                solutionList.Add(sol);
            }
           // Evaluate();
        }


        void Shuffle()
        {
            int n = solutionList.Count();
            while (n > 1)
            {
                n--;
                int k = G.rand(n + 1);
                Solution value = solutionList[k];
                solutionList[k] = solutionList[n];
                solutionList[n] = value;
            }
        }

        static void SwapInt(ref int lhs, ref int  rhs)
        {
            int temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

       void generateCitiesToVisit()
        {
            for (int i = 0; i < G.target_size; i++)
            {
                City temp = new City(G.rand(1000), G.rand(1000));
                CitiesToVisit.Add(temp);
            }
        }

     }
}
