using Catalog.Apis.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.Apis.Shared
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct) {
                 productCollection.InsertManyAsync(GetPreconfigureProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfigureProducts()
        {
            return new List<Product>
          {
            new Product()
            {
            Id="12303265403542ljisnhtcol",
            Name="Amd oouud",
            Category= "Home kitthen",
            Summary ="this isi df sfaluwe sdfihh",
            Description="desction 21212 dfsdfsd",
            ImageFile="prod1.png",
            Price=240.32M,

            },

            new Product()
            {
            Id="12303j65403542ljisnhtcol",
            Name="dsd sdAmd oouud",
            Category= "2Home kitthen",
            Summary ="12this isi df sfaluwe sdfihh",
            Description="desction 21212 dfsdfsd",
            ImageFile="prod1.png",
            Price=240.32M,

            },
            new Product()
            {
            Id="18303265403542ljisnhtcol",
            Name="dsqwqw wqw",
            Category= "w3Home kitthen",
            Summary ="eeethis isi df sfaluwe sdfihh",
            Description="wedesction 21212 dfsdfsd",
            ImageFile="prod1.png",
            Price=240.32M,

            }
           };
        }
    }
}
