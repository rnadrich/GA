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
       static bool experment = false;
        List<Solution> solutionList = new List<Solution>();
        static public Solution bestSolution;
        static public bool bestHasChanged = false;
        public static int generationsSoFar = 0;

        public Population()
        {
            initializePopulation();
            bestSolution = solutionList[0];
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
            if (experment == false) Mate(start);
            else ExpermentalMate(start);
        }

        //Calculates the distance between current city and the possible next cities in each parent Genome
        //Take the shortest route between each parent
        private void ExpermentalMate(int start)
        {
            double dist1To1, dist1To2, dist2To1, dist2To2; 
            Solution parent1 = solutionList[start + 2];
            Solution parent2 = solutionList[start + 3];

            List<City> child1string = new List<City>();
            List<City> child2string = new List<City>();

            child1string.Add(parent1.genome[0]);
            child2string.Add(parent2.genome[0]);
            for(int i=1;i<G.target_size;i++)
            {
                dist1To1 = child1string[i - 1].distanceTo(parent1.genome[i]);
                dist1To2 = child1string[i - 1].distanceTo(parent2.genome[i]);
                dist2To1 = child2string[i - 1].distanceTo(parent1.genome[i]);
                dist2To2 = child2string[i - 1].distanceTo(parent2.genome[i]);
                if (dist1To1<dist1To2) child1string.Add(parent1.genome[i]);
                else child1string.Add(parent2.genome[i]);
                if (dist2To1 < dist2To2) child2string.Add(parent1.genome[i]);
                else child2string.Add(parent2.genome[i]);
            }

            solutionList[start].genome = child1string;
            solutionList[start + 1].genome = child2string;

            Problem.Evaluate(solutionList[start]);
            Problem.Evaluate(solutionList[start + 1]);
        }
        private void Mate(int start)
        {
            int cross1 = G.rand(G.target_size);
            int cross2 = cross1;
            while(cross1==cross2) cross2 = G.rand(G.target_size);
            if (cross1 > cross2) SwapInt(ref cross1,ref cross2);

            Solution parent1 = solutionList[start+2];
            Solution parent2 = solutionList[start+3];

            List<City> child1string = new List<City>();
            List<City> child2string = new List<City>();

            for(int i=0;i<G.target_size;i++)
            {
                if((i<cross1)||(i>cross2))
                {
                    child1string.Add( parent1.genome[i]);
                    child2string.Add( parent2.genome[i]);
                }
                else
                {
                    child1string.Add(parent2.genome[i]);
                    child2string.Add(parent1.genome[i]);
                }
            }
            solutionList[start].genome = child1string;
            solutionList[start + 1].genome = child2string;

            Problem.Evaluate(solutionList[start]);
            Problem.Evaluate(solutionList[start + 1]);
        }



        private void Evaluate()
        {
            foreach(Solution s in solutionList)
            {
                Problem.Evaluate(s);
            }
        }

        public void runGenerations(int howMany, BackgroundWorker bWorker, bool expermentFlag)
        {
            experment = expermentFlag;
            for (int i = 0; i < howMany; i++)
            {
                runGeneration();
                /* if (Problem.isOptimal(bestSolution))
                 {
                     soundPlayer.Play();
                     break;
                 }*/
                int percentage = (int)(100.0 * (((double)i) / ((double)howMany)));
                bWorker.ReportProgress(percentage);
                // bestHasChanged = false;
            }
        }

        public void runGenerations(int howMany, BackgroundWorker bWorker)
        {
            experment = false;
            for (int i = 0; i < howMany; i++)
            {
                runGeneration();
               /* if (Problem.isOptimal(bestSolution))
                {
                    soundPlayer.Play();
                    break;
                }*/
                int percentage = (int)(100.0 * (((double)i) / ((double)howMany)));
                bWorker.ReportProgress(percentage);
               // bestHasChanged = false;
            }
        }
        public void runGenerations(int howMany)
        {
            experment = false;
            for (int i = 0; i < howMany; i++)
            {
                runGeneration();
                /*if (Problem.isOptimal(bestSolution))
                {
                    soundPlayer.Play();
                    break;
                }*/
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
            Evaluate();
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
