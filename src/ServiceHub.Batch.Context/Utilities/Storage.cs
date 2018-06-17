﻿using System;
using System.Collections.Generic;

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
        public List<Library.Models.Batch> GetAllBatches()
        {
            return utility.GetAllBatches();
        }

        /// <value> Add batch to injected IUtility class repo </value>
        public void AddBatch(Library.Models.Batch batch)
        {
            utility.AddBatch(batch);
        }

        /// <value> Update batch in injected IUtility class repo </value>
        public void UpdateBatch(Library.Models.Batch batch)
        {
            utility.UpdateBatch(batch);
        }

        /// <value> Delete batch from injected IUtility class repo </value>
        public void DeleteBatch(Guid id)
        {
            utility.DeleteBatch(id);
        }
        public List<Library.Models.Batch> GetBatchesBySkill(string skill)
        {
            return utility.GetBatchesBySkill(skill);
        }
        public List<Library.Models.Batch> GetBatchesByLocation(string state)
        {
            return utility.GetBatchesByLocation(state);
        }
    }
}