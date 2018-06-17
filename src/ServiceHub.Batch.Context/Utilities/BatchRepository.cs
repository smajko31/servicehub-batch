using System;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceHub.Batch.Library;
using ServiceHub.Batch.Context;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    public class BatchRepository : IUtility
    {
        private readonly IMongoCollection<Context.Models.Batch> _batches;
        const string connectionString = @"mongodb://db";

        public BatchRepository()
        {
            _batches = new MongoClient(connectionString)
                .GetDatabase("batchdb")
                .GetCollection<Context.Models.Batch>("batches");
        }

        /// <summary>
        /// Adds a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task AddBatch(Library.Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            await _batches.InsertOneAsync(ModelMapper.ToContextBatchModel(batch));
        }

        /// <summary>
        /// Deletes a batch from the data source, if they exist.
        /// </summary>
        /// <param name="id">Unique Batch identifier</param>
        /// <returns></returns>
        public async Task DeleteBatch(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var filter = Builders<Models.Batch>.Filter.Eq(x => x.BatchId, id);
            await _batches.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Gets all the batches
        /// </summary>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetAllBatches()
        {
            if (_batches == null)
            {
                throw new ArgumentNullException(nameof(_batches));
            }

            return await Task.Run(() => ModelMapper.ToLibraryList(_batches.AsQueryable().ToList()));
        }

        /// <summary>
        /// Updates a batch
        /// </summary>
        /// <param name="batch">Batch Model</param>
        /// <returns></returns>
        public async Task UpdateBatch(Library.Models.Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }
            var filter = Builders<Models.Batch>.Filter.Eq(x => x.BatchId, batch.BatchId);
            var update = Builders<Models.Batch>.Update.Set(x => x.State, batch.State);
            await _batches.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// Gets all Batches with the same skill
        /// </summary>
        /// <param name ="skill">Batch Skill</param>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetBatchesBySkill(string skill)
        {
            return await Task.Run(() => ModelMapper.ToLibraryList(_batches.Find(x => x.BatchSkill == skill).ToList()));
        }

        /// <summary>
        /// Gets all Batches in the same location
        /// </summary> 
        /// <param name="city">Batch City Name</param>
        /// <param name="state">Batch State Name</param>
        /// <returns></returns>
        public async Task<List<Library.Models.Batch>> GetBatchesByLocation(string state)
        {
            return await Task.Run(() => ModelMapper.ToLibraryList(_batches.Find(x => x.State == state).ToList()));
        }
    }
}
