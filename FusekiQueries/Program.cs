using System;

namespace FusekiConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queries queries = new Queries();
            queries.Select();
            Console.ReadLine();
        }
    }
}
