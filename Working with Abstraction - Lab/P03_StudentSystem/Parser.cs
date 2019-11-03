using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class Parser
    {
        public void ParseCommand()
        {
            StudentSystem studentSystem = new StudentSystem();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];

                if (command == "Create")
                {
                    var name = inputArgs[1];
                    var age = int.Parse(inputArgs[2]);
                    var grade = double.Parse(inputArgs[3]);
                    if (!studentSystem.Repo.ContainsKey(name))
                    {
                        var student = new Student(name, age, grade);
                        studentSystem.Repo[name] = student;
                    }
                }
                else if (command == "Show")
                {
                    var name = inputArgs[1];
                    if (studentSystem.Repo.ContainsKey(name))
                    {
                        var student = studentSystem.Repo[name];

                        Console.WriteLine(student);
                    }

                }
            }
            return;
        }
    }
}
