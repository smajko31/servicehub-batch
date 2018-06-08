using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ServiceHub.Batch.Context.Utilities
{
    public class MemoryUtility : IUtility
    {
        private List<Models.Batch> memList = new List<Models.Batch>();
        
        public Models.Batch GetBatchById(Guid id)
        {
            Models.Batch thisBatch = memList.Find(x => x.BatchId == id);
            return thisBatch;
        }
        public async Task<IEnumerable<Models.Batch>> GetAllBatches()
        {
            return memList;
        }
        public async void AddBatch(Models.Batch batch)
        {
            memList.Add(batch);
        }
        public async void UpdateBatch(Models.Batch batch)
        {
            int index = memList.IndexOf(batch);
            if(index >= 0)
            memList[index] = batch;

        }
        public async void DeleteBatch(Guid id)
        {
            memList.Remove(memList.Find(x=>x.BatchId==id));
        }
    }
}
