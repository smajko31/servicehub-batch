using System;
using System.Collections.Generic;

namespace ServiceHub.Batch.Context.Models
{
    public class Batch
    {
        // Unique batch id
        public Guid BatchId { get; set; }
        // Start date of training
        public DateTime StartDate { get; set; }
        // Expected training end date
        public DateTime EndDate { get; set; }
        // Specific name of batch
        public string BatchName { get; set; }
        // Total number of people in batch
        public int BatchOccupancy { get; set; }
        // Batch technology stack 
        public string BatchSkill { get; set; }
        // Address where training takes place
        public Address Address { get; set; }
        // List of associate ids in batch
        public List<Guid> UserIds { get; set; }
    }
}
