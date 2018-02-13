using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var dictionaryDepartments = new Dictionary<string, List<string>>();
            var dictionaryDoctors = new Dictionary<string, List<string>>();
            while (input[0] != "Output")
            {
                var department = input[0];
                var doctor = string.Format(input[1] +" " + input[2]);
                var patient = input[3];

                if (!dictionaryDepartments.ContainsKey(department))
                {
                    dictionaryDepartments.Add(department, new List<string>());
                    dictionaryDepartments[department].Add(patient);
                }
                else
                {
                    dictionaryDepartments[department].Add(patient);
                }

                if (!dictionaryDoctors.ContainsKey(doctor))
                {
                    dictionaryDoctors.Add(doctor, new List<string>());
                    dictionaryDoctors[doctor].Add(patient);
                }
                else
                {
                    dictionaryDoctors[doctor].Add(patient);
                }
                
                

                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                if (commands.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", dictionaryDepartments[commands[0]]));
                }
                else if (commands.Length == 2)
                {
                    
                    int rooms = 0;
                    if (int.TryParse(commands[1], out rooms))
                    {
                        var department = commands[0];
                        Console.WriteLine(string.Join("\n", dictionaryDepartments[department].Skip((rooms-1)*3).Take(3).OrderBy(x => x)));
                    }
                    else
                    {
                        var doctor = string.Format(commands[0] + " " + commands[1]);
                        Console.WriteLine(string.Join("\n", dictionaryDoctors[doctor].OrderBy(x => x)));
                    }
                }
                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
