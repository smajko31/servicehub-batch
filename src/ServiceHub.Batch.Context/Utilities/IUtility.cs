using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    /// <summary>
    /// Basic CRUD interface for Batch models
    /// All storage implementations must inherit IUtility
    /// </summary>
    public interface IUtility
    {
        Task <Models.Batch> GetBatchById(Guid id);
        Task <IEnumerable<Models.Batch>> GetAllBatches();
        Task AddBatch(Models.Batch batch);
        Task UpdateBatch(Models.Batch batch);
        Task DeleteBatch(Guid id);
    }
}
