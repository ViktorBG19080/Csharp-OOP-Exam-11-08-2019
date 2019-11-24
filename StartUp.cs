using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;

namespace ViceCity
{
    public class StartUp
    {
        static IEngine engine;
        static void Main(string[] args)
        {
            engine = new Engine();
            engine.Run();
        }
    }
}
