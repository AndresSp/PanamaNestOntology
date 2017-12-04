using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF;
using VDS.RDF.Storage;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using Entities.Model;

namespace FusekiConnection
{
    public class InsertQueries
    {
        SparqlUtilities sparqlUtilities;
        FusekiConnector fuseki;
        PersistentTripleStore store;

        public InsertQueries()
        {
            sparqlUtilities = new SparqlUtilities();
            fuseki = new FusekiConnector(sparqlUtilities.GraphPath);
            store = new PersistentTripleStore(fuseki);

            
        }

        public bool CreateBird(Bird bird)
        {
            foreach(var triple in store.Triples)
            {
                //Console.WriteLine(store.);
            }
            /*
            Graph graph = new Graph();
            fuseki.LoadGraph(graph, );

            fuseki.SaveGraph(graph);*/
            return true;
        }
    }
}
