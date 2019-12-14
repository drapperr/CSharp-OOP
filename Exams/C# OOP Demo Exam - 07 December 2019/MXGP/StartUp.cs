using System;
using MXGP.Core.Contracts;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine=new Engine();
            engine.Run();
        }
    }
}
