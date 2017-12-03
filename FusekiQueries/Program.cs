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

            /* Examples
            e = selectQueries.SelectDomains();
            e = selectQueries.SelectKingdoms();
            e = selectQueries.SelectPhylums();
            e = selectQueries.SelectClasses();
            e = selectQueries.SelectOrders();
            e = selectQueries.SelectFamilies();
            e = selectQueries.SelectGenuses();
            e = selectQueries.SelectSpecies();*/
            e = selectQueries.SelectBirds();
            e = selectQueries.Se

            PrintEntities(e); //print
            Console.ReadLine();
        }

        public static void PrintEntities(List<Entity> list)
        {
            foreach (Entity entity in list)
            {
                Console.WriteLine(entity.Name);
                Console.WriteLine(entity.Uri);
                Console.WriteLine(entity.ParentName);
                Console.WriteLine(entity.ParentUri);
                foreach (var ename in entity.ChildsName)
                {
                    Console.WriteLine(ename);
                }

                foreach (var euri in entity.ChildsUri)
                {
                    Console.WriteLine(euri);
                }
            }
        }
    }
}
