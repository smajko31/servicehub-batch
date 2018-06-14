using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.Batch.Context.Utilities
{
    class MemoryUtility : IUtility
    {
        /// <value>Create the memList List for use with CRUD functions</value>
        private List<Library.Models.Batch> memList = new List<Library.Models.Batch>();
        
        /// <summary>
        /// Gets all the batches from the list
        /// </summary>
        /// <returns>A list of all of the batches</returns>
        public List<Library.Models.Batch> GetAllBatches()
        {
            return memList;
        }
        /// <summary>
        /// Adds a batch to the batch list
        /// </summary>
        /// <param name="batch">Batch object</param>
        public void AddBatch(Library.Models.Batch batch)
        {
            memList.Add(batch);
        }
        /// <summary>
        /// Modifies the specified batch in the list with new information
        /// </summary>
        /// <param name="batch">Batch object</param>
        public void UpdateBatch(Library.Models.Batch batch)
        {
            int index = memList.IndexOf(batch);
            if (index >= 0)
                memList[index] = batch;
        }
        /// <summary>
        /// Deletes a batch from the list
        /// </summary>
        /// <param name="id">Batch ID</param>
        public void DeleteBatch(Guid id)
        {
            memList.Remove(memList.Find(x => x.BatchId == id));
        }
        /// <summary>
        /// Returns a list of all the batches that match the specified skill
        /// </summary>
        /// <param name="skill">Batch skill</param>
        /// <returns>List of batches with the same skill</returns>
        public List<Library.Models.Batch> GetBatchesBySkill(string skill)
        {
            return memList.FindAll(x => x.BatchSkill == skill);
        }
        /// <summary>
        /// Gets a list of all of the batches that match the specified city and state
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <returns></returns>
        public List<Library.Models.Batch> GetBatchesByLocation(string state)
        {
            return memList.FindAll(x => x.Address.State == state);
        }
    }
}