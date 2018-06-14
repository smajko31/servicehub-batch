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
        List<Library.Models.Batch> GetBatchesBySkill(string skill);
        List<Library.Models.Batch> GetBatchesByLocation(string state);
        List<Library.Models.Batch> GetAllBatches();
        void AddBatch(Library.Models.Batch batch);
        void UpdateBatch(Library.Models.Batch batch);
        void DeleteBatch(Guid id);
    }
}