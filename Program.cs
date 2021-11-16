using System;
using Monolog.Classes;

namespace Monolog
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Parser p = new Parser(args[0]);
            var a = p.Parse();
            Generator g = new Generator();
            Console.WriteLine("HTML: " + g.GenerateHTML(a[0], a[1]));
            Console.WriteLine("MD: " + g.GenerateMarkdown(a[0], a[1]));
        }
    }
}
