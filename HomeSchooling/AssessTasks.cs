using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeSchooling
{
    public class AssessTasks
    {
        public Tuple<string, int>[][] AssessTasksHandler(Tuple<string, int>[] tasks)
        {
            Tuple<string, int>[][] result = new Tuple<string, int>[3][];

            if(tasks.Length < 3)
            {
                return result;
            }

            if(tasks.Length == 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (tasks[i].Item2 != tasks[i+1].Item2)
                    {
                        return result;
                    }
                }
                result[0] = new Tuple<string, int>[]{tasks[0]};
                result[1] = new Tuple<string, int>[]{tasks[1]};
                result[2] = new Tuple<string, int>[]{tasks[2]};
                return result;
            }

            var totalPoints = tasks.Sum(t => t.Item2);
            if(totalPoints % 3 != 0)
            {
                return result;
            }

            var subsetTotal = totalPoints/3;

            var sortedTasks = tasks.OrderByDescending(t => t.Item2).ToList();

            for(int n = 0; n < 2; n++)
            {
                var subsetSum = 0;
                var subset = new ArrayList();
                var index = 0;
                while((subsetSum < subsetTotal) && (index < sortedTasks.Count))
                {
                    subsetSum += sortedTasks[index].Item2;
                    if(subsetSum > subsetTotal)
                    {
                        subsetSum -= sortedTasks[index].Item2;
                        index++;
                        continue;
                    }
                    subset.Add(sortedTasks[index]);
                    index++;
                }

                if(index >= sortedTasks.Count)
                {
                    return new Tuple<string, int>[3][];
                }
                
                if(subsetSum == subsetTotal)
                {
                    result[n] = subset.ToArray(typeof(Tuple<string, int>)) as Tuple<string, int>[];
                    foreach (var item in subset)
                    {
                        sortedTasks.Remove((Tuple<string, int>) item);
                    };
                }
                
            }

            result[2] = sortedTasks.ToArray();

            return result;
        }
    }
}