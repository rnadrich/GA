using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Travaling_Salesman
{
    static class Problem
    {
      // static String target = "Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!Evolution can solve problems!";


        static public void Evaluate(Solution s)
        {
            double bonus = 1.0;
            double score = 0.0;
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == s.genome[i])
                {
                    score += bonus;
                    bonus += 0.0; //standard fitness function if inc is zero
                }
                else
                {
                    bonus = 1.0;
                }
            }
            s.fitness = score;
            if (s > Population.bestSolution)
            {
                Population.bestSolution = s;
                Population.bestHasChanged = true;
            }
        }

        static public bool isOptimal(Solution s)
        {
            return s.genome == target;
        }
    }
}
