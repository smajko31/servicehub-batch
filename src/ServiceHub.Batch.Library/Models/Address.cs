using System;

namespace ServiceHub.Address.Library.Models
{
    /// <summary>
    /// Address helper model
    /// Used in Batch model to specify where training takes place
    /// </summary>
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
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
        /// Check if object has any invalid (default) property values
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

            return true;
        }

        /* TODO: Uncomment when Address model exists in Context project
        /// <summary>
        /// Converts Context address model into Library address model
        /// </summary>
        /// <param name="addressContext">Address model in Context project</param>
        /// <returns>Address model in Library project</returns>
        public static Address ToLibraryAddress(Context.Models.Address addressContext)
        {
            Address addressLibrary = new Address();
            addressLibrary.AddressId = addressContext.AddressId;
            addressLibrary.Address1 = addressContext.Address1;
            addressLibrary.Address2 = addressContext.Address2;
            addressLibrary.City = addressContext.City;
            addressLibrary.State = addressContext.State;
            addressLibrary.PostalCode = addressContext.PostalCode;
            addressLibrary.Country = addressContext.Country;

            return addressLibrary;
        }

        /// <summary>
        /// Converts Library address model into Context address model
        /// </summary>
        /// <param name="addressLibrary">Address model in Library project</param>
        /// <returns>Address model in Context project</returns>
        public static Context.Models.Address ToContextModel(Address addressLibrary)
        {
            Context.Models.Address addressContext = new Context.Models.Address();
            addressContext.AddressId = addressLibrary.AddressId;
            addressContext.Address1 = addressLibrary.Address1;
            addressContext.Address2 = addressLibrary.Address2;
            addressContext.City = addressLibrary.City;
            addressContext.State = addressLibrary.State;
            addressContext.PostalCode = addressLibrary.PostalCode;
            addressContext.Country = addressLibrary.Country;

            return addressContext;
        }
        */
    }
}
