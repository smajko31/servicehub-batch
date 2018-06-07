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
        // Unique batch id
        [Required]
        public Guid BatchId { get; set; }
        // Start date of training
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        // Expected training end date
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        // Specific name of batch
        [StringLength(50)]
        public string BatchName { get; set; }
        // Total number of people in batch
        [Range(0, 100)]
        public int BatchOccupancy { get; set; }
        // Batch technology stack 
        [StringLength(50)]
        public string BatchSkill { get; set; }
        // Address where training takes place
        public Address Address { get; set; }
        // List of associate ids in batch
        public List<Guid> UserIds { get; set; }
    }
}
