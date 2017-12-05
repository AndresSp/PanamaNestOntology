﻿using System;
using System.Collections.Generic;
using System.Text;
using VDS.RDF.Query;

namespace FusekiConnection
{
    public class SparqlUtilities
    {
        #region Server Uri
        public Uri FileUploadPath { get; private set; }
        public Uri SparqlPath { get; private set; }
        public Uri GraphPath { get; private set; }
        public Uri MainPath { get; private set; }
        public Uri UpdatePath { get; private set; }
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
            Habitats,
            Regions,
            Filter_Birds_Taxon,
            Filter_Birds_Loc,
            Ontology_Classes,
        }

        public SparqlUtilities()
        {
            FileUploadPath = new Uri("http://localhost:3030/Main/upload");
            SparqlPath = new Uri("http://localhost:3030/Main/sparql");
            GraphPath = new Uri("http://localhost:3030/Main/data");
            MainPath = new Uri("http://localhost:3030/Main/");
            UpdatePath = new Uri("http://localhost:3030/Main/update");
        }

        private void AddNamespaces(SparqlParameterizedString sparqlprmtS)
        {
            sparqlprmtS.Namespaces.AddNamespace("", new Uri("http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#"));
            sparqlprmtS.Namespaces.AddNamespace("dc", new Uri("http://purl.org/dc/elements/1.1/"));
            sparqlprmtS.Namespaces.AddNamespace("owl", new Uri("http://www.w3.org/2002/07/owl#"));
            sparqlprmtS.Namespaces.AddNamespace("pno", new Uri("http://www.semanticweb.org/team/ontologies/2017/10/PanamenianNestOntology#"));
            sparqlprmtS.Namespaces.AddNamespace("rdf", new Uri("http://www.w3.org/1999/02/22-rdf-syntax-ns#"));
            sparqlprmtS.Namespaces.AddNamespace("xml", new Uri("http://www.w3.org/XML/1998/namespace"));
            sparqlprmtS.Namespaces.AddNamespace("xsd", new Uri("http://www.w3.org/2001/XMLSchema#"));
            sparqlprmtS.Namespaces.AddNamespace("rdfs", new Uri("http://www.w3.org/2000/01/rdf-schema#"));
            sparqlprmtS.Namespaces.AddNamespace("terms", new Uri("http://purl.org/dc/terms/"));
            sparqlprmtS.Namespaces.AddNamespace("foaf", new Uri("http://xmlns.com/foaf/0.1/"));
        }

        public void AddQueryCommand(SparqlParameterizedString sparqlprmtS, QStrings qStrings)
        {
            AddNamespaces(sparqlprmtS);
            string query = "";
            switch(qStrings)
            {
                //Master Queries
                case QStrings.Domains: query = "SELECT DISTINCT ?uri ?name WHERE { ?uri pno:hasKingdomChild ?child. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Kingdoms: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasPhylumChild ?child. ?parent pno:hasKingdomChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Phylums: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasClassChild ?child. ?parent pno:hasPhylumChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Classes: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasOrderChild ?child. ?parent pno:hasClassChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Orders: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasFamilyChild ?child. ?parent pno:hasOrderChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Families: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasGenusChild ?child. ?parent pno:hasFamilyChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Genuses: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasSpeciesChild ?child. ?parent pno:hasGenusChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Species: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?uri pno:hasBirdChild ?child. ?parent pno:hasSpeciesChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} OPTIONAL {?child rdfs:label ?childname} }"; break;
                case QStrings.Birds: query = "SELECT DISTINCT ?uri ?name ?parent ?parentname WHERE { ?parent pno:hasBirdChild ?uri. OPTIONAL {?uri rdfs:label ?name} OPTIONAL {?parent rdfs:label ?parentname} }"; break;
                case QStrings.Habitats: query = "SELECT DISTINCT ?name WHERE { ?x pno:Habitat ?name. }"; break;
                case QStrings.Regions: query = "SELECT DISTINCT ?name WHERE { ?x pno:Region ?name. }"; break;
                //Filter Queries
                case QStrings.Filter_Birds_Taxon: query = "SELECT * WHERE { ?bird pno:CommonName ?commonname. ?bird pno:BinomialName ?binomialname. ?bird pno:Habitat ?habitat. ?bird pno:Region ?region. ?bird pno:Size ?size. OPTIONAL {?bird rdfs:comment ?comment} OPTIONAL {?bird foaf:depiction ?imgurl} ?domain pno:hasKingdomChild ?kingdom. ?kingdom pno:hasPhylumChild ?phylum. ?phylum pno:hasClassChild ?class. ?class pno:hasOrderChild ?order. ?order pno:hasFamilyChild ?family. ?family pno:hasGenusChild ?genus. ?genus pno:hasSpeciesChild ?specie. ?specie pno:hasBirdChild ?bird. OPTIONAL {?bird rdfs:label ?name} OPTIONAL {?order rdfs:label ?ordername} OPTIONAL {?family rdfs:label ?familyname} OPTIONAL {?genus rdfs:label ?genusname} OPTIONAL {?specie rdfs:label ?speciename} FILTER(?order = @o && ?genus = @g && ?family = @f) }"; break;
                case QStrings.Filter_Birds_Loc: query = "SELECT * WHERE { ?bird pno:CommonName ?commonname. ?bird pno:BinomialName ?binomialname. ?bird pno:Habitat ?habitat. ?bird pno:Region ?region. ?bird pno:Size ?size. OPTIONAL {?bird rdfs:comment ?comment} OPTIONAL {?bird foaf:depiction ?imgurl} ?domain pno:hasKingdomChild ?kingdom. ?kingdom pno:hasPhylumChild ?phylum. ?phylum pno:hasClassChild ?class. ?class pno:hasOrderChild ?order. ?order pno:hasFamilyChild ?family. ?family pno:hasGenusChild ?genus. ?genus pno:hasSpeciesChild ?specie. ?specie pno:hasBirdChild ?bird. OPTIONAL {?bird rdfs:label ?name} OPTIONAL {?order rdfs:label ?ordername} OPTIONAL {?family rdfs:label ?familyname} OPTIONAL {?genus rdfs:label ?genusname} OPTIONAL {?specie rdfs:label ?speciename} FILTER(?region = @r && ?habitat = @h && ?size = @s) }"; break;
            }

            sparqlprmtS.CommandText = query;
        }

    }
}
