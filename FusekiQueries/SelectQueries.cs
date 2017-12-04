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

        #region Master Queries
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
                    Entity child = new Entity();

                    if (result.HasBoundValue("uri"))
                    {
                        entity.Uri = result.Value("uri").ToString();
                    }
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
                        child.Uri = result.Value("child").ToString();
                        if (result.HasBoundValue("childname"))
                        {
                            child.Name = result.Value("childname").ToString();
                        }
                        
                        entity.Children.Add(child);
                    }

                    list.Add(entity);
                }
            }
            return list;
        }

        /// <summary>
        /// *Domain Master*
        /// Select all Domains
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectDomains()
        {
            return SelectMaster(SparqlUtilities.QStrings.Domains, haveParents:false);
        }

        /// <summary>
        /// *Kingdom Master*
        /// Select all Kingdoms
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectKingdoms()
        {
            return SelectMaster(SparqlUtilities.QStrings.Kingdoms);
        }

        /// <summary>
        /// *Phylum Master*
        /// Select all Phylums
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectPhylums()
        {
            return SelectMaster(SparqlUtilities.QStrings.Phylums);
        }

        /// <summary>
        /// *Class Master*
        /// Select all Classes
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectClasses()
        {
            return SelectMaster(SparqlUtilities.QStrings.Classes);
        }

        /// <summary>
        /// *Order Master*
        /// Select all Orders
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectOrders()
        {
            return SelectMaster(SparqlUtilities.QStrings.Orders);
        }

        /// <summary>
        /// *Family Master*
        /// Select all Families
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectFamilies()
        {
            return SelectMaster(SparqlUtilities.QStrings.Families);
        }

        /// <summary>
        /// *Genus Master*
        /// Select all Genuses
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectGenuses()
        {
            return SelectMaster(SparqlUtilities.QStrings.Genuses);
        }

        /// <summary>
        /// *Specie Master*
        /// Select Species
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectSpecies()
        {
            return SelectMaster(SparqlUtilities.QStrings.Species);
        }

        /// <summary>
        /// *Bird Master*
        /// Select all Birds
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectBirds()
        {
            return SelectMaster(SparqlUtilities.QStrings.Birds, haveChilds:false);
        }

        /// <summary>
        /// *Habitat Master*
        /// Select all Habitats
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectHabitats()
        {
            return SelectMaster(SparqlUtilities.QStrings.Habitats, haveParents: false, haveChilds: false);
        }

        /// <summary>
        /// *Region Master*
        /// Select all Regions
        /// </summary>
        /// <returns></returns>
        public List<Entity> SelectRegions()
        {
            return SelectMaster(SparqlUtilities.QStrings.Regions, haveParents: false, haveChilds: false);
        }

        #endregion

        #region Specific Queries

        public List<Bird> FilterBird(Bird birdPrmts)
        {
            List<Bird> list = new List<Bird>();
            SparqlParameterizedString sparqlprmtS = new SparqlParameterizedString();
            sparqlUtilities.AddQueryCommand(sparqlprmtS, SparqlUtilities.QStrings.Filter_Birds);

            string orderPrmt = birdPrmts.Order.Uri;
            string genusPrmt = birdPrmts.Genus.Uri;
            string familyPrmt = birdPrmts.Family.Uri;

            sparqlprmtS.SetUri("o", new Uri(orderPrmt));
            sparqlprmtS.SetUri("g", new Uri(genusPrmt));
            sparqlprmtS.SetUri("f", new Uri(familyPrmt));

            Object results = store.ExecuteQuery(sparqlprmtS.ToString());
            Console.WriteLine(sparqlprmtS);
            if (results is SparqlResultSet)
            {
                SparqlResultSet rset = (SparqlResultSet)results;

                Console.WriteLine("Count: " + rset.Count.ToString());

                foreach (SparqlResult result in rset.Results)
                {
                    Bird bird = new Bird();
                    Entity order = new Entity();
                    Entity genus = new Entity();
                    Entity family = new Entity();
                    Entity specie = new Entity();

                    bird.Uri = result.Value("bird").ToString();
                    if (result.HasBoundValue("name"))
                    {
                        bird.Name = result.Value("name").ToString();
                    }

                    order.Uri = result.Value("order").ToString();

                    if (result.HasBoundValue("ordername"))
                    {
                        order.Name = result.Value("ordername").ToString();
                    }
                    bird.Order = order;

                    genus.Uri = result.Value("genus").ToString();

                    if (result.HasBoundValue("genusname"))
                    {
                        genus.Name = result.Value("genusname").ToString();
                    }
                    bird.Genus = genus;

                    family.Uri = result.Value("family").ToString();

                    if (result.HasBoundValue("familyname"))
                    {
                        family.Name = result.Value("familyname").ToString();
                    }
                    bird.Family = family;

                    specie.Uri = result.Value("specie").ToString();

                    if (result.HasBoundValue("speciename"))
                    {
                        specie.Name = result.Value("speciename").ToString();
                    }
                    bird.Specie = specie;

                    bird.CommonName = result.Value("commonname").ToString();
                    bird.BinomialName = result.Value("binomialname").ToString();
                    bird.Habitat.Add(result.Value("habitat").ToString());
                    bird.Region.Add(result.Value("region").ToString());

                    list.Add(bird);
                }
            }
            return list;
        }

        #endregion

    }
}
