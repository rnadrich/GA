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



        /*static public void Evaluate(Solution s)
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
        }*/

        static public void Evaluate(Solution s)
        {
            double score = 0.0;
            City start,end;
            List<City> visited=new List<City>();
            start=s.genome[0];
            visited.Add(start);
            for (int i = 1; i < s.genome.Count; i++)
            {
                end = s.genome[i];
                score+=calculateDistance(start, end);
                if (s.genome.Contains(end)) score += 200;
                else visited.Add(end);
                start = end;
            }
            s.fitness = score;
            if (s > Population.bestSolution)
            {
                Population.bestSolution = s;
                Population.bestHasChanged = true;
            }
        }

       static double calculateDistance(City begin, City end)
        {
            double dist = 0;
           int difX,difY;
           difX=begin.location.Item1-end.location.Item1;
           difY=begin.location.Item2-end.location.Item2;
           dist = Math.Sqrt(difX ^ 2 + difY ^ 2);
            return dist;
        }

    }
}
