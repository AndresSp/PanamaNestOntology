using System;
using Entities.Model;
using System.Collections.Generic;

namespace FusekiConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertQueries insertQueries = new InsertQueries();
            insertQueries.CreateBird(new Bird());
            
            SelectQueries selectQueries = new SelectQueries();
            List<Entity> e = new List<Entity>();
            List<Bird> b = new List<Bird>();

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
            //e = selectQueries.SelectHabitats();
            //e = selectQueries.SelectRegions();


            //Bird bird = new Bird();
            //Entity order = new Entity();
            //Entity genus = new Entity();
            //Entity family = new Entity();
            //order.Uri = "http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#Accipitriformes";
            //bird.Order = order;
            //genus.Uri = "http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#Coragyps";
            //bird.Genus = genus;
            //family.Uri = "http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#Cathartidae";
            //bird.Family = family;
            //b = selectQueries.FilterBirdTaxon(bird);


            Bird bird = new Bird();
            List<string> h = new List<string>();
            h.Add("Woodlands");
            List<string> r = new List<string>();
            r.Add("Central America");
            bird.Habitat = h;
            bird.Region = r;
            bird.Size = "50 cm";
            b = selectQueries.FilterBirdLoc(bird);


            //PrintEntities(e);
            PrintFilterBirds(b); //print
            Console.ReadLine();
        }

        public static void PrintEntities(List<Entity> list)
        {
            foreach (Entity e in list)
            {
                Console.WriteLine("Name: " + e.Name);
                Console.WriteLine("Uri: " + e.Uri);
                Console.WriteLine("ParentName: " + e.ParentName);
                Console.WriteLine("ParentUri: " + e.ParentUri);
                int i = 1;
                foreach(Entity child in e.Children)
                {
                    Console.WriteLine(string.Format("Child[{0}] Name: {1}",i,child.Name));
                    Console.WriteLine(string.Format("Child[{0}] Uri: {1}", i, child.Uri));
                    Console.WriteLine();
                    i++;
                }
            }
        }

        public static void PrintFilterBirds(List<Bird> list)
        {
            Console.WriteLine();
            foreach (Bird bird in list)
            {
                Console.WriteLine("Name: " + bird.Name);
                Console.WriteLine("Uri: " + bird.Uri);
                Console.WriteLine("Order: " + bird.Order.Name);
                Console.WriteLine("Family: " + bird.Family.Name);
                Console.WriteLine("Genus: " + bird.Genus.Name);
                Console.WriteLine("Specie: " + bird.Specie.Name);
                Console.WriteLine("CommonName: " + bird.CommonName);
                Console.WriteLine("BinomialName: " + bird.BinomialName);

                foreach(string habitat in bird.Habitat)
                {
                    Console.WriteLine("Habitat: " + habitat);
                }

                foreach (string region in bird.Region)
                {
                    Console.WriteLine("Region: " + region);
                }

                Console.WriteLine("Size: " + bird.Size);
                Console.WriteLine();
            }
        }
    }
}
