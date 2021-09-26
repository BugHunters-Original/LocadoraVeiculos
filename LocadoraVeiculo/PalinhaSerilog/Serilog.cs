using System;
using Serilog;

namespace PalinhaSerilog
{
    public class Serilog
    {
        static void Main(string[] args)
        {
            var a = new LoggerConfiguration().WriteTo.Seq("http://20.195.202.178:5341/").CreateLogger();
            a.Information("aiushdaisdhiasd");
        }

    }
}
