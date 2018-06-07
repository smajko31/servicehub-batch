using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceHub.Batch.Library.Models
{
    /// <summary>
    /// Address Model
    /// Contains all information about location.
    /// </summary>
    /// <remarks>
    /// Used in Batch model to specify location of training.
    /// </remarks>
    public class Address
    {
        [Required]
        public Guid AddressId { get; set; }
        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Country { get; set; }
    }
}
