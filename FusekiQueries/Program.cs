using System;
using Entities.Model;
using System.Collections.Generic;

namespace FusekiConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SelectQueries selectQueries = new SelectQueries();
            List<Entity> e = new List<Entity>();

            /* Examples */
            //e = selectQueries.SelectDomains();
            //e = selectQueries.SelectKingdoms();
            //e = selectQueries.SelectPhylums();
            //e = selectQueries.SelectClasses();
            //e = selectQueries.SelectOrders();
            //e = selectQueries.SelectFamilies();
            //e = selectQueries.SelectGenuses();
            //e = selectQueries.SelectSpecies();
            //e = selectQueries.SelectBirds();

            PrintEntities(e); //print
            Console.ReadLine();
        }

        public static void PrintEntities(List<Entity> list)
        {
            foreach (Entity entity in list)
            {
                Console.WriteLine("Name: " + entity.Name);
                Console.WriteLine("Uri: " + entity.Uri);
                Console.WriteLine("Parent: " + entity.ParentName);
                Console.WriteLine("Parent Uri: " + entity.ParentUri);
                foreach (var child in entity.Children)
                {
                    Console.WriteLine("Child Name: " + child.Name);
                    Console.WriteLine("Child Uri: " + child.Uri);
                }

            }
        }
    }
}
