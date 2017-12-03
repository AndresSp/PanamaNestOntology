using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace FusekiConnection
{
    public class Queries
    {
        //Uri endpointpath = new Uri("http://localhost:3030/Main/sparql");

        public void Select()
        {
            SparqlUtilities utilities = new SparqlUtilities();
            SparqlParameterizedString sparqlprmtS = new SparqlParameterizedString();

            utilities.AddNamespaces(sparqlprmtS);
            utilities.AddQueryCommand(sparqlprmtS, SparqlUtilities.QStrings.Birds);


            Console.WriteLine(sparqlprmtS.ToString());
            Console.ReadLine();

            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery query = parser.ParseFromString(sparqlprmtS);
            
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(utilities.SparqlPath);
            SparqlResultSet rset = endpoint.QueryWithResultSet(sparqlprmtS.ToSafeString());

            foreach (SparqlResult result in rset.Results)
            {
                Console.WriteLine(result[0].ToString());
                //Console.WriteLine(result[1].ToString());
                Console.WriteLine(" ");
            }
            Console.ReadLine();
        }

        public void SelectDomains()
        {
            SparqlUtilities utilities = new SparqlUtilities();
            SparqlParameterizedString sparqlprmtS = new SparqlParameterizedString();

            utilities.AddNamespaces(sparqlprmtS);
            utilities.AddQueryCommand(sparqlprmtS, SparqlUtilities.QStrings.Domains);

            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(utilities.SparqlPath);
            SparqlResultSet rset = endpoint.QueryWithResultSet(sparqlprmtS.ToSafeString());

            foreach (SparqlResult result in rset.Results)
            {
                Console.WriteLine(result[0].ToString());
            }
            Console.ReadLine();
        }

        public void Select(SparqlUtilities.QStrings query)
        {
            SparqlUtilities utilities = new SparqlUtilities();
            SparqlParameterizedString sparqlprmtS = new SparqlParameterizedString();

            utilities.AddNamespaces(sparqlprmtS);
            utilities.AddQueryCommand(sparqlprmtS, SparqlUtilities.QStrings.Domains);

            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(utilities.SparqlPath);
            SparqlResultSet rset = endpoint.QueryWithResultSet(sparqlprmtS.ToSafeString());

        }

        
    }
}
