using ServiceHub.Batch.Context.Utilities;
using System;
using System.Collections.Generic;

namespace ServiceHub.Batch.Context
{
    public class Storage
    {
        /// <summary>
        /// Depndency Injection for classes implementing IUtility
        /// 
        /// Example usage: 
        ///     Storage storage = new Storage(new TestUtility);
        ///     List<Models.Batch> batchList = storage.GetAllBatches();
        ///     
        /// </summary>
        private IUtility utility;

        // Inject IUtility class
        public Storage(IUtility utility)
        {
            this.utility = utility;
        }

        // Get batch by id from injected IUtility class repo
        Models.Batch GetBatchById(Guid id)
        {
            return utility.GetBatchById(id);
        }

        // Get all batches from injected IUtility class repo
        List<Models.Batch> GetAllBatches()
        {
            return utility.GetAllBatches();
        }

        // Add batch to injected IUtility class repo
        void AddBatch(Models.Batch batch)
        {
            utility.AddBatch(batch);
        }

        // Update batch in injected IUtility class repo
        void UpdateBatch(Models.Batch batch)
        {
            utility.UpdateBatch(batch);
        }

        // Delete batch from injected IUtility class repo
        void DeleteBatch(Guid id)
        {
            utility.DeleteBatch(id);
        }
    }
}
