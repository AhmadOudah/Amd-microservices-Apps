﻿using Catalog.Apis.Entities;
using Catalog.Apis.Shared;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Apis.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly DatabaseSettings _settings;
        public CatalogContext(IOptions<DatabaseSettings> settings)
        {
            _settings = settings.Value; 
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DataBaseName);
            Products = database.GetCollection<Product>(_settings.CollectionName);
            CatalogContextSeed.SeedData(Products);

        }
        public IMongoCollection<Product>  Products { get; } // => throw new NotImplementedException();
    }
}
