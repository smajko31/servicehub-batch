using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ServiceHub.Batch.Library.Models
{
    /// <summary>
    /// Address helper model
    /// Used in Batch model to specify where training takes place
    /// </summary>
    [DataContract]
    public class Address
    {
        [IgnoreDataMember]
        private readonly string[] StateCodes = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };

        [IgnoreDataMember]
        private readonly string[] CountryCodes = { "US" };

        [DataMember]
        public Guid AddressId { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string Country { get; set; }
        /// <summary>
        /// Initialize object with non-valid properties
        /// </summary>
        /// <remarks>
        /// Allows checking for valid Json request. After deserialization, 
        /// check if any property has a default value using Validate()
        /// </remarks>
        public Address()
        {
            AddressId = Guid.Empty;
            Address1 = null;
            Address2 = null;
            City = null;
            State = null;
            PostalCode = null;
            Country = null;
        }

        /// <summary>
        /// Check if object has any invalid property values
        /// </summary>
        /// <returns>Returns false if any value is invalid, else true</returns>
        public bool Validate()
        {
            if (AddressId == Guid.Empty) { return false; }
            if (String.IsNullOrEmpty(Address1)) { return false; }
            if (String.IsNullOrEmpty(City)) { return false; }
            if (String.IsNullOrEmpty(State)) { return false; }
            if (String.IsNullOrEmpty(PostalCode)) { return false; }
            if (String.IsNullOrEmpty(Country)) { return false; }

            if (Address1.Length > 255) { return false; }
            if (City.Length > 255) { return false; }
            if (PostalCode.Length != 5) { return false; }
            if (!StateCodes.Contains(State.ToUpper())) { return false; }
            if (!CountryCodes.Contains(Country.ToUpper())) { return false; }

            if (!PostalCode.All(Char.IsDigit)) { return false; }

            return true;
        }
    }
}
