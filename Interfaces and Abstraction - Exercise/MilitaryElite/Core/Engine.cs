using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                string type = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                if (type == "Spy")
                {
                    int codeNumber = int.Parse(inputArgs[4]);

                    var spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }
                else
                {
                    decimal salary = decimal.Parse(inputArgs[4]);

                    if (type == "Private")
                    {
                        var privateSolider = new Private(id, firstName, lastName, salary);

                        soldiers.Add(id, privateSolider);
                    }
                    else if (type == "LieutenantGeneral")
                    {
                        int[] idInts = inputArgs.Skip(5)
                            .Select(int.Parse)
                            .ToArray();

                        IList<IPrivate> privates = new List<IPrivate>();
                        foreach (var idInt in idInts)
                        {
                            privates.Add((IPrivate)soldiers[idInt]);
                        }
                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                        soldiers.Add(id, lieutenantGeneral);
                    }
                    else
                    {
                        string crops = inputArgs[5];

                        if (crops== "Airforces"||crops== "Marines")
                        {
                            if (type == "Engineer")
                            {
                                ICollection<IRepair> repairs = new List<IRepair>();

                                for (int i = 6; i < inputArgs.Length; i += 2)
                                {
                                    string name = inputArgs[i];
                                    int hours = int.Parse(inputArgs[i + 1]);
                                    var repair = new Repair(name, hours);
                                    repairs.Add(repair);
                                }

                                var engineer = new Engineer(id, firstName, lastName, salary, crops, repairs);

                                soldiers.Add(id, engineer);
                            }
                            else if (type == "Commando")
                            {
                                ICollection<IMission> missions = new List<IMission>();

                                for (int i = 6; i < inputArgs.Length; i += 2)
                                {
                                    string name = inputArgs[i];
                                    string state = inputArgs[i + 1];
                                    if (state == "inProgress" || state == "Finished")
                                    {
                                        var mission = new Mission(name, state);
                                        missions.Add(mission);
                                    }
                                }

                                var commando = new Commando(id, firstName, lastName, salary, crops, missions);

                                soldiers.Add(id, commando);
                            }
                        }
                    }
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value);
            }
        }
    }
}
