using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHub.Batch.Library.Models
{
    /// <summary>
    /// Batch Model
    /// Contains all information describing any one batch.
    /// </summary>
    /// <remarks>
    /// A batch refers to a training period for Revature associates. Model includes following information:
    /// unique batch id, start/end date, technology stack, location, number of associates and list of associates.
    /// </remarks>
    public class Batch
    {
        /// <value> Unique batch id </value>
        public Guid BatchId { get; set; }
        /// <value> Start date of training </value>
        public DateTime? StartDate { get; set; }
        /// <value> Expected training end date </value>
        public DateTime? EndDate { get; set; }
        /// <value> Specific name of batch </value>
        public string BatchName { get; set; }
        /// <value> Total number of people in batch </value>
        public int? BatchOccupancy { get; set; }
        /// <value> Batch technology stack </value>
        public string BatchSkill { get; set; }
        /// <value> Address where training takes place </value>
        public Address Address { get; set; }
        /// <value> List of associate ids in batch </value>
        public List<Guid> UserIds { get; set; }

        /// <summary>
        /// Initialize object with non-valid properties
        /// </summary>
        /// <remarks>
        /// Allows checking for valid Json request. After deserialization, 
        /// check if any property has a default value using Validate()
        /// </remarks>
        public Batch()
        {
            BatchId = Guid.Empty;
            StartDate = null;
            EndDate = null;
            BatchName = null;
            BatchOccupancy = null;
            BatchSkill = null;
            Address = null;
            UserIds = null;
        }

        /// <summary>
        /// Check if object has any invalid (default) property values
        /// </summary>
        /// <returns>Returns false if any value is invalid, else true</returns>
        public bool Validate()
        {
            if (BatchId == Guid.Empty) { return false; }
            if (StartDate == null) { return false; }
            if (EndDate == null) { return false; }
            if (String.IsNullOrEmpty(BatchName)) { return false; }
            if (BatchOccupancy == null) { return false; }
            if (BatchOccupancy < 0 || BatchOccupancy > 100) { return false; }
            if (String.IsNullOrEmpty(BatchSkill)) { return false; }
            if (Address == null) { return false; }
            if (UserIds?.Any() != true) { return false; }

            return true;
        }

        /* TODO: Uncomment when Batch model exists in Context project
        /// <summary>
        /// Converts Context batch model into Library batch model
        /// </summary>
        /// <param name="batchContext">Batch context model</param>
        /// <returns>Batch library model</returns>
        public static Batch ToLibraryModel(Context.Models.Batch batchContext)
        {
            Batch batchLibrary = new Batch();
            batchLibrary.BatchId = batchContext.BatchId;
            batchLibrary.StartDate = batchContext.StartDate;
            batchLibrary.EndDate = batchContext.EndDate;
            batchLibrary.BatchName = batchContext.BatchName;
            batchLibrary.BatchOccupancy = batchContext.BatchOccupancy;
            batchLibrary.BatchSkill = batchContext.BatchSkill;
            batchLibrary.Address = Address.ToLibraryModel(batchContext.Address);
            batchLibrary.UserIds = batchContext.BatchUserIds;

            return batchLibrary;
        }

        /// <summary>
        /// Converts Library batch model into Context batch model
        /// </summary>
        /// <param name="batchLibrary">Batch library model</param>
        /// <returns>Batch context model</returns>
        public static Context.Models.Batch ToContextModel(Batch batchLibrary)
        {
            Context.Models.Batch batchContext = new Context.Models.Batch();
            batchContext.BatchId = batchLibrary.BatchId;
            batchContext.StartDate = batchLibrary.StartDate;
            batchContext.EndDate = batchLibrary.EndDate;
            batchContext.BatchName = batchLibrary.BatchName;
            batchContext.BatchOccupancy = batchLibrary.BatchOccupancy;
            batchContext.BatchSkill = batchLibrary.BatchSkill;
            batchContext.Address = Address.ToContextModel(batchLibrary.Address);
            batchContext.UserIds = batchLibrary.UserIds;

            return batchContext;
        }
        */
    }
}
