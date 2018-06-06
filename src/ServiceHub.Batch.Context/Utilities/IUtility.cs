using System;
using System.Collections.Generic;

namespace ServiceHub.Batch.Context.Utilities
{
    /// <summary>
    /// Basic CRUD interface for Batch models
    /// All storage implementations must inherit IUtility
    /// </summary>
    public interface IUtility
    {
        Models.Batch GetBatchById(Guid id);
        List<Models.Batch> GetAllBatches();
        void AddBatch(Models.Batch batch);
        void UpdateBatch(Models.Batch batch);
        void DeleteBatch(Guid id);
    }
}
