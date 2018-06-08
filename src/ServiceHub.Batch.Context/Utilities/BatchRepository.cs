using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Authentication;
using ServiceHub.Batch.Context.Models;

namespace ServiceHub.Batch.Context.Utilities
{
    public class BatchRepository : IUtility
    {
        public const string MongoDbIdName = "_id";
        protected readonly IMongoClient _client;
        protected readonly IMongoDatabase _db;
        private readonly IMongoCollection<Models.Batch> _collection;
        private readonly HttpClient _salesforceapi;
        private readonly string _baseUrl;
        private readonly MetaData _metadata;
        private readonly string _MetaDataCollection;
        private readonly string _metadataId;
        private long _CurrentCount;

        public BatchRepository(Settings settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.ConnectionString));
            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(mongoSettings);
            _salesforceapi = new HttpClient();
            _baseUrl = settings.BaseURL;
            _MetaDataCollection = settings.MetaDataCollectionName;
            _metadataId = settings.MetaDataId;
            _db = _client.GetDatabase(settings.Database);
            _collection = _db.GetCollection<Models.Batch>(settings.CollectionName);
        }

        /// <summary>
        /// Adds a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task AddBatch(Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            await _collection.InsertOneAsync(batch);
        }

        /// <summary>
        /// Deletes a batch
        /// </summary>
        /// <param name="id">Unique Batch identifier</param>
        /// <returns></returns>
        public async Task DeleteBatch(Guid id)
        {
            await _collection.DeleteOneAsync(b => b.BatchId == id);
        }

        /// <summary>
        /// Gets all the batches
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Batch>> GetAllBatches()
        {
            var stuff = await _collection.Find(new BsonDocument()).ToListAsync();
            return stuff;
        }

        /// <summary>
        /// Gets a batch by id
        /// </summary>
        /// <param name="id">Unique Batch identifier</param>
        /// <returns></returns>
        public async Task<Models.Batch> GetBatchById(Guid id)
        {
            Models.Batch result = await _collection.Find(b => b.BatchId == id).FirstAsync();
            return result;
        }

        /// <summary>
        /// Updates a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task UpdateBatch(Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            var replaceOneResult = await _collection.ReplaceOneAsync(
                dbatch => dbatch.BatchId == batch.BatchId, batch);
        }
    }
}
