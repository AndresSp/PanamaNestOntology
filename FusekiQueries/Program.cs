﻿using System;
using Entities.Model;
using System.Collections.Generic;

namespace FusekiConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SelectQueries selectQueries = new SelectQueries();
            List<Bird> e = new List<Bird>();

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
            e = selectQueries.FilterBird("Accipitriformes", "Coragyps", "Cathartidae");

            PrintEntities(e); //print
            Console.ReadLine();
        }

        public static void PrintEntities(List<Bird> list)
        {
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
                Console.WriteLine();
            }
        }
    }
}
