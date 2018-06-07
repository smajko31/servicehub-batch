using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public Guid BatchId { get; set; }
        /// <value> Start date of training </value>
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        /// <value> Expected training end date </value>
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        /// <value> Specific name of batch </value>
        [StringLength(50)]
        public string BatchName { get; set; }
        /// <value> Total number of people in batch </value>
        [Range(0, 100)]
        public int BatchOccupancy { get; set; }
        /// <value> Batch technology stack </value>
        [StringLength(50)]
        public string BatchSkill { get; set; }
        /// <value> Address where training takes place </value>
        public Address Address { get; set; }
        /// <value> List of associate ids in batch </value>
        public List<Guid> UserIds { get; set; }
    }
}
