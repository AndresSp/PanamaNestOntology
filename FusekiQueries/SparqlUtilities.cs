using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF.Query;

namespace FusekiConnection
{
    public class SparqlUtilities
    {
        #region Server Uri
        private Uri fileUploadPath = new Uri("http://localhost:3030/Main/upload");
        public Uri FileUploadPath { get => fileUploadPath; private set => fileUploadPath = value; }

        private Uri sparqlPath = new Uri("http://localhost:3030/Main/sparql");
        public Uri SparqlPath { get => sparqlPath; private set => sparqlPath = value; }

        private Uri graphPath = new Uri("http://localhost:3030/Main/data");
        public Uri GraphPath { get => graphPath; set => graphPath = value; }

        private Uri mainPath = new Uri("http://localhost:3030/Main/");
        public Uri MainPath { get => mainPath; set => mainPath = value; }
        #endregion

        public enum QStrings
        {
            Domains,
            Kingdoms,
            Phylums,
            Classes,
            Orders,
            Families,
            Genuses,
            Species,
            Birds,
            Bird_Domains,
            Bird_Kingdoms,
            Bird_Phylums,
            Bird_Classes,
            Bird_Orders,
            Bird_Families,
            Bird_Genuses,
            Bird_Species,
            Bird_Binomial_Nomenclature,
            Bird_Common_Name,
            Bird_Habitat,
            Bird_Region,
            Ontology_Classes,
        }

        public SparqlUtilities()
        {
        }

        public void AddNamespaces(SparqlParameterizedString sparqlprmtS)
        {
            sparqlprmtS.Namespaces.AddNamespace("dc", new Uri("http://purl.org/dc/elements/1.1/"));
            sparqlprmtS.Namespaces.AddNamespace("owl", new Uri("http://www.w3.org/2002/07/owl#"));
            sparqlprmtS.Namespaces.AddNamespace("pno", new Uri("http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#"));
            sparqlprmtS.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            sparqlprmtS.Namespaces.AddNamespace("xml", new Uri("http://www.w3.org/XML/1998/namespace"));
            sparqlprmtS.Namespaces.AddNamespace("xsd", new Uri("http://www.w3.org/2001/XMLSchema#"));
            sparqlprmtS.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            sparqlprmtS.Namespaces.AddNamespace("terms", new Uri("http://purl.org/dc/terms/"));
        }

        public void AddQueryCommand(SparqlParameterizedString sparqlprmtS, QStrings qStrings)
        {
            string query = "";
            switch(qStrings)
            {
                case QStrings.Domains: query = "SELECT DISTINCT ?domain WHERE { ?domain pno:hasKingdomChild? x. } "; break;
                case QStrings.Kingdoms: query = "SELECT DISTINCT ?kingdom WHERE {  ?kingdom pno:hasPhylumChild? x. } "; break;
                case QStrings.Phylums: query = "SELECT DISTINCT ?phylum WHERE { ?phylum pno:hasClassChild ?x. }"; break;
                case QStrings.Classes: query = "SELECT DISTINCT ?class WHERE { ?class pno:hasOrderChild ?x. }"; break;
                case QStrings.Orders: query = "SELECT DISTINCT ?order WHERE { ?order pno:hasFamilyChild ?x. }"; break;
                case QStrings.Families: query = "SELECT DISTINCT ?family WHERE { ?family pno:hasGenusChild ?x. }"; break;
                case QStrings.Genuses: query = "SELECT DISTINCT ?genus WHERE { ?genus pno:hasSpeciesChild ?x. }"; break;
                case QStrings.Species: query = "SELECT DISTINCT ?specie WHERE { ?specie pno:hasBirdChild ?x. }"; break;
                case QStrings.Birds: query = "SELECT DISTINCT ?bird WHERE { ?x pno:hasBirdChild ?bird. }"; break;
                case QStrings.Bird_Domains: query = "SELECT ?domain ?bird WHERE {  ?domain pno:hasKingdomChild ?kingdom.  ?kingdom pno:hasPhylumChild ?phylum.  ?phylum pno:hasClassChild ?class.  ?class pno:hasOrderChild ?order.  ?order pno:hasFamilyChild ?family.  ?family pno:hasGenusChild ?genus.  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Kingdoms: query = "SELECT ?kingdom ?bird WHERE {  ?kingdom pno:hasPhylumChild ?phylum.  ?phylum pno:hasClassChild ?class.  ?class pno:hasOrderChild ?order.  ?order pno:hasFamilyChild ?family.  ?family pno:hasGenusChild ?genus.  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Phylums: query = "SELECT ?phylum ?bird WHERE {  ?phylum pno:hasClassChild ?class.  ?class pno:hasOrderChild ?order.  ?order pno:hasFamilyChild ?family.  ?family pno:hasGenusChild ?genus.  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Classes: query = "SELECT ?class ?bird WHERE { ?class pno:hasOrderChild ?order. ?order pno:hasFamilyChild ?family. ?family pno:hasGenusChild ?genus. ?genus pno:hasSpeciesChild ?specie. ?specie pno:hasBirdChild ?bird. }"; break;
                case QStrings.Bird_Orders: query = "SELECT ?order ?bird WHERE {  ?order pno:hasFamilyChild ?family.  ?family pno:hasGenusChild ?genus.  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Families: query = "SELECT ?family ?bird WHERE {  ?family pno:hasGenusChild ?genus.  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Genuses: query = "SELECT ?genus ?bird WHERE {  ?genus pno:hasSpeciesChild ?specie.  ?specie pno:hasBirdChild ?bird.}"; break;
                case QStrings.Bird_Species: query = "SELECT ?specie ?bird WHERE { ?specie pno:hasBirdChild ?bird. }"; break;
                case QStrings.Bird_Binomial_Nomenclature: query = "SELECT ?genus ?specie ?bird WHERE { ?genus pno:hasSpeciesChild ?specie. ?specie pno:hasBirdChild ?bird. }"; break;
                case QStrings.Bird_Common_Name: query = ""; new Exception("query Undefined"); break;
                case QStrings.Bird_Habitat: query = ""; new Exception("query Undefined"); break;
                case QStrings.Bird_Region: query = ""; new Exception("query Undefined"); break;
                case QStrings.Ontology_Classes: query = "SELECT DISTINCT ?class WHERE {  ?class a owl:Class. }"; break;
            }

            sparqlprmtS.CommandText = query;
        }
    }
}
