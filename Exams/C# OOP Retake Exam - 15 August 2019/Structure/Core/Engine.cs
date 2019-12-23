namespace SpaceStation.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using IO;
    using SpaceStation.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IController controller;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine()
        {
            this.controller = new Controller();
            ;
            this.writer = new Writer();
            this.reader = new Reader();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddAstronaut")
                    {
                        string type = input[1];
                        string name = input[2];

                        result = controller.AddAstronaut(type, name);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string name = input[1];
                        string[] items = input.Skip(2).ToArray();

                        result = controller.AddPlanet(name, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string name = input[1];

                        result = controller.RetireAstronaut(name);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string name = input[1];

                        result = controller.ExplorePlanet(name);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
