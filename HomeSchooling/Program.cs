using System;
using System.Collections;

namespace HomeSchooling
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            var tasks = new ArrayList();
            Console.WriteLine("Please enter tasks in format example A,1;B,1;C,1");
            var input = Console.ReadLine();
            try {
                string[] tuples = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in tuples)
                {
                    string[] tuple = item.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    tasks.Add(Tuple.Create(tuple[0], Int32.Parse(tuple[1])));
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex}");
            }
            
            //call method
            var handler = new AssessTasks();
            var result = handler.AssessTasksHandler(tasks.ToArray(typeof(Tuple<string, int>)) as Tuple<string, int>[]);

            //print output
            for(var index = 0; index < result.Length; index++)
            {
                if(result[index] is null)
                {
                    Console.WriteLine($"No. Tasks cannot be divided.");
                    break;
                }

                Console.WriteLine($"Tasks for child {index}:");
                Array.ForEach(result[index], Console.WriteLine);
            }
        }
    }
}
