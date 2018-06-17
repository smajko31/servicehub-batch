using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <value> Get all batches from injected IUtility class repo </value>
        public async Task<List<Library.Models.Batch>> GetAllBatches()
        {
            return await utility.GetAllBatches();
        }

        /// <value> Add batch to injected IUtility class repo </value>
        public async Task AddBatch(Library.Models.Batch batch)
        {
            await utility.AddBatch(batch);
        }

        /// <value> Update batch in injected IUtility class repo </value>
        public async Task UpdateBatch(Library.Models.Batch batch)
        {
            await utility.UpdateBatch(batch);
        }

        /// <value> Delete batch from injected IUtility class repo </value>
        public async Task DeleteBatch(Guid id)
        {
            await utility.DeleteBatch(id);
        }
        public async Task<List<Library.Models.Batch>> GetBatchesBySkill(string skill)
        {
            return await utility.GetBatchesBySkill(skill);
        }
        public async Task<List<Library.Models.Batch>> GetBatchesByLocation(string state)
        {
            return await utility.GetBatchesByLocation(state);
        }
    }
}