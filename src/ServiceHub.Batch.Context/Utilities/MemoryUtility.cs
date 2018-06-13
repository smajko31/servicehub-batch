using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Batch.Context.Utilities
{
    class MemoryUtility: IUtility
    {
        private List<Library.Models.Batch> memList = new List<Library.Models.Batch>();
        public Library.Models.Batch GetBatchById(Guid id)
        {
            return memList.Find(x => x.BatchId == id);
        }
        public List<Library.Models.Batch> GetAllBatches()
        {
            return memList;
        }
        public void AddBatch(Library.Models.Batch batch)
        {
            memList.Add(batch);
        }
        public void UpdateBatch(Library.Models.Batch batch)
        {
            int index = memList.IndexOf(batch);
            if (index >= 0)
                memList[index] = batch;
        }
        public void DeleteBatch(Guid id)
        {
            memList.Remove(memList.Find(x => x.BatchId == id));
        }
        public List<Library.Models.Batch> GetBatchesBySkill(string skill)
        {
            return memList.FindAll(x => x.BatchSkill == skill);
        }
        public List<Library.Models.Batch> GetBatchesByLocation(string city, string state)
        {
            return memList.FindAll(x => x.Address.City == city && x.Address.State == state);
        }
    }
}

