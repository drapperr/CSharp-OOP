namespace ViceCity.Core
{
    using System;

    using Contracts;
    using ViceCity.IO.Contracts;
    using IO;

    public class Engine : IEngine
    {
        private IController controller;
        private IReader reader;
        private IWriter writer;


        public Engine()
        {
            this.controller=new Controller();;
            this.reader = new Reader();
            this.writer = new Writer();

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

                    if (input[0] == "AddPlayer")
                    {
                        string username = input[1];

                        result = controller.AddPlayer(username);
                    }
                    else if (input[0] == "AddGun")
                    {
                        string type = input[1];
                        string name = input[2];

                        result = controller.AddGun(type,name);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        string username = input[1];

                        result = controller.AddGunToPlayer(username);
                    }
                    else if (input[0] == "Fight")
                    {
                        result = controller.Fight();
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
