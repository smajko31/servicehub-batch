using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceHub.Batch.Context.Models
{
    /// <summary>
    /// Address model for repository
    /// Contains all information about location.
    /// </summary>
    /// <remarks>
    /// Used in Batch model to specify location of training.
    /// </remarks>
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
