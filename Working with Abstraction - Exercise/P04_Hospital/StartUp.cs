using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            AddPatinets(doctors, departments);
            PrintTargetResult(doctors, departments);
        }

        private static void PrintTargetResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        departments[args[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        departments[args[0]][staq - 1]
                        .OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }

        private static string AddPatinets(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] args = command.Split();
                var departament = args[0];
                var firstName = args[1];
                var lastName = args[2];
                var patient = args[3];
                var fullName = firstName + lastName;

                if (!doctors.ContainsKey(firstName + lastName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool haveABed = departments[departament].SelectMany(x => x).Count() < 60;

                if (haveABed)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);

                    for (int i = 0; i < departments[departament].Count; i++)
                    {
                        if (departments[departament][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            return command;
        }
    }
}
