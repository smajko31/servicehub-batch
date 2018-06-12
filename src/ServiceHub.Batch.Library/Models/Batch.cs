using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
    [DataContract]
    public class Batch
    {
        /// <value> Unique batch id </value>
        [DataMember]
        public Guid BatchId { get; set; }
        /// <value> Start date of training </value>
        [DataMember]
        public DateTime? StartDate { get; set; }
        /// <value> Expected training end date </value>
        [DataMember]
        public DateTime? EndDate { get; set; }
        /// <value> Specific name of batch </value>
        [DataMember]
        public string BatchName { get; set; }
        /// <value> Total number of people in batch </value>
        [DataMember]
        public int? BatchOccupancy { get; set; }
        /// <value> Batch technology stack </value>
        [DataMember]
        public string BatchSkill { get; set; }
        /// <value> Address where training takes place </value>
        [DataMember]
        public Address Address { get; set; }
        /// <value> List of associate ids in batch </value>
        [DataMember]
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
    }
}
