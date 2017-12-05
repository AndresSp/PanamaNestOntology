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
            Graph graph = new Graph();

            //if(fuseki.UpdateSupported)
            //{
            //INode s = graph.CreateBlankNode();
            //INode p = graph.CreateUriNode(new Uri(RdfSpecsHelper.RdfType));
            //INode o = graph.CreateUriNode(new Uri("http://example.org/Example"));
            //    Triple t = new Triple(s, p, o, sparqlUtilities.GraphPath);
            //    //fuseki.Update(sparqlUtilities.UpdatePath.ToString(), null, new Triple[] { t });
            //}

            //fuseki.LoadGraph(graph, sparqlUtilities.GraphPath);

            graph.LoadFromUri(sparqlUtilities.GraphPath, new RdfXmlParser());

            
            graph.NamespaceMap.AddNamespace("dc", new Uri("http://purl.org/dc/elements/1.1/"));
            graph.NamespaceMap.AddNamespace("owl", new Uri("http://www.w3.org/2002/07/owl#"));
            graph.NamespaceMap.AddNamespace("pno", new Uri("http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#"));
            graph.NamespaceMap.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            graph.NamespaceMap.AddNamespace("xml", new Uri("http://www.w3.org/XML/1998/namespace"));
            graph.NamespaceMap.AddNamespace("xsd", new Uri("http://www.w3.org/2001/XMLSchema#"));
            graph.NamespaceMap.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            graph.NamespaceMap.AddNamespace("terms", new Uri("http://purl.org/dc/terms/"));

            INode s = graph.CreateUriNode("pno:birttest");
            INode p = graph.CreateUriNode("rdfs:label");
            INode o = graph.CreateLiteralNode("Bird Test");

            graph.Assert(s, p, o);
            fuseki.SaveGraph(graph);

            Console.WriteLine("ya");
            return true;
        }
    }
}
