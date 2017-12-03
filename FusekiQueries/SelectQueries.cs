﻿using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF;
using VDS.RDF.Storage;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using Entities.Model;

namespace FusekiConnection
{
    public class SelectQueries
    {
        SparqlUtilities sparqlUtilities;
        PersistentTripleStore store;

        public SelectQueries()
        {
            sparqlUtilities = new SparqlUtilities();
            FusekiConnector fuseki = new FusekiConnector(sparqlUtilities.GraphPath);
            store = new PersistentTripleStore(fuseki);
        }

        /// <summary>
        /// Dont have Parents :'( (Y/N)
        /// </summary>
        /// <returns></returns>
        private List<Entity> SelectMaster(SparqlUtilities.QStrings qString, bool haveParents = true, bool haveChilds = true)
        {
            List<Entity> list = new List<Entity>();
            SparqlParameterizedString sparqlprmtS = new SparqlParameterizedString();
            sparqlUtilities.AddQueryCommand(sparqlprmtS, qString);

            Object results = store.ExecuteQuery(sparqlprmtS.ToString());

            if (results is SparqlResultSet)
            {
                SparqlResultSet rset = (SparqlResultSet)results;

                foreach (SparqlResult result in rset.Results)
                {
                    Entity entity = new Entity();
                    entity.Uri = result.Value("uri").ToString();
                    if (result.HasBoundValue("name"))
                    {
                        entity.Name = result.Value("name").ToString();
                    }
                    
                    if (haveParents)
                    {
                        entity.ParentUri = result.Value("parent").ToString();
                        if (result.HasBoundValue("parentname"))
                        {
                            entity.ParentName = result.Value("parentname").ToString();
                        }
                    }

                    if (haveChilds)
                    {
                        entity.ChildsUri.Add(result.Value("child").ToString());
                        if (result.HasBoundValue("childname"))
                        {
                            entity.ChildsName.Add(result.Value("childname").ToString());
                        }
                    }

                    list.Add(entity);
                }
            }
            return list;
        }

        public List<Entity> SelectDomains()
        {
            return SelectMaster(SparqlUtilities.QStrings.Domains, false);
        }

        public List<Entity> SelectKingdoms()
        {
            return SelectMaster(SparqlUtilities.QStrings.Kingdoms);
        }

        public List<Entity> SelectPhylums()
        {
            return SelectMaster(SparqlUtilities.QStrings.Phylums);
        }

        public List<Entity> SelectClasses()
        {
            return SelectMaster(SparqlUtilities.QStrings.Classes);
        }

        public List<Entity> SelectOrders()
        {
            return SelectMaster(SparqlUtilities.QStrings.Orders);
        }

        public List<Entity> SelectFamilies()
        {
            return SelectMaster(SparqlUtilities.QStrings.Families);
        }

        public List<Entity> SelectGenuses()
        {
            return SelectMaster(SparqlUtilities.QStrings.Genuses);
        }

        public List<Entity> SelectSpecies()
        {
            return SelectMaster(SparqlUtilities.QStrings.Species);
        }

        private void Example()
        {
            SparqlUtilities sparqlUtilities = new SparqlUtilities();
            FusekiConnector fuseki = new FusekiConnector(sparqlUtilities.GraphPath);
            PersistentTripleStore store = new PersistentTripleStore(fuseki);

            if (store.HasGraph(sparqlUtilities.GraphPath))
            {
                //Get the graph out of the in-memory view (note that if it changes in the underlying store in the meantime you will not see those changes)
                Console.WriteLine("Hay un grafo");

                //Do something with the Graph...
            }
            
            Object results = store.ExecuteQuery("SELECT * WHERE {?s ?p ?o}");

            if (results is SparqlResultSet)
            {
                //Print out the Results
                SparqlResultSet rset = (SparqlResultSet)results;
                foreach (SparqlResult result in rset)
                {
                    Console.WriteLine(result.ToString());
                }
            }

            Console.ReadLine();

            results = store.ExecuteQuery("SELECT ?s WHERE {?s ?p ?o}");
            if (results is SparqlResultSet)
            {
                //Print out the Results
                SparqlResultSet rset = (SparqlResultSet)results;
                foreach (SparqlResult result in rset)
                {
                    Console.WriteLine(result.ToString());
                }
            }


        }
        
    }
}