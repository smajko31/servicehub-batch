using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Batch.Context.Utilities
{
    public class Storage
    {
        /// <summary>
        /// Depndency Injection for classes implementing IUtility
        /// </summary>
        /// <remarks>
        /// Example usage: 
        ///     Storage storage = new Storage(new TestUtility);
        ///     List<Models.Batch> batchList = storage.GetAllBatches();
        /// </remarks>
        /// 
        private IUtility utility;

        /// <value> Inject IUtility class </value>
        public Storage(IUtility utility)
        {
            this.utility = utility;
        }

        /// <value> Get batch by id from injected IUtility class repo </value>
        Models.Batch GetBatchById(Guid id)
        {
            return utility.GetBatchById(id);
        }

        /// <value> Get all batches from injected IUtility class repo </value>
        IEnumerable<Models.Batch> GetAllBatches()
        {
            return utility.GetAllBatches();
        }

        /// <value> Add batch to injected IUtility class repo </value>
        void AddBatch(Models.Batch batch)
        {
            utility.AddBatch(batch);
        }

        /// <value> Update batch in injected IUtility class repo </value>
        void UpdateBatch(Models.Batch batch)
        {
            utility.UpdateBatch(batch);
        }

        /// <value> Delete batch from injected IUtility class repo </value>
        void DeleteBatch(Guid id)
        {
            utility.DeleteBatch(id);
        }
    }
}
