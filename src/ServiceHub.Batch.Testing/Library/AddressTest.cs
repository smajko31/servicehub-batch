using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace ServiceHub.Batch.Testing.Library
{
    public class AddressTest
    {
        /// <value> Address model to have all valid properties </value>
        readonly Batch.Library.Models.Address address;

        /// <summary>
        /// Create a valid Address model to create copies per unit test, and test
        /// for individual invalid properties.
        /// </summary>
        public AddressTest()
        {
            /// <value> Initialize and define valid Address model </value>
            address = new Batch.Library.Models.Address()
            {
                AddressId = Guid.NewGuid(),
                Address1 = "some_address1",
                Address2 = "some_address2",
                City = "some_city",
                State = "NY",
                PostalCode = "11228",
                Country = "US"
            };
        }

        /// <summary>
        /// Test Address model with default initialized values
        /// </summary>
        [Fact]
        public void TestDefaultBatch()
        {
            Assert.False(new Batch.Library.Models.Address().Validate());
        }

        /// <summary>
        /// Test valid Address model created by the constructor
        /// </summary>
        [Fact]
        public void TestUnitBatch()
        {
            Assert.True(address.Validate());
        }

        /// <summary>
        /// Replace Guid in valid Address model with empty Guid, then test validity of model 
        /// </summary>
        [Fact]
        public void TestInvalidId()
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.AddressId = Guid.Empty;
            Assert.False(address.Validate());
        }

        /// <summary>
        /// Create complex type for testing Address1 property
        /// Used for TestValidAddress(string address1, bool expected)
        /// and TestValidCity(string city, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> AddressTestCases = ImmutableList.Create
        (
            new object[] { "", false },
            new object[] { "testestest", true },
            new object[] { "helloW!@# worldlwR#R", true },
            new object[] { "       ", true },
            new object[] { 12345.ToString(), true },
            new object[] { string.Empty, false },
            new object[] { null, false }
        );

        /// <summary>
        /// Test for valid street addresses
        /// </summary>
        /// <param name="address1">street address</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(AddressTestCases))]
        public void TestValidAddress(string address1, bool expected)
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.Address1 = address1;
            Assert.Equal(addressTemp.Validate(), expected);
        }

        /// <summary>
        /// Test for valid city
        /// </summary>
        /// <param name="city">city name</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(AddressTestCases))]
        public void TestValidCity(string city, bool expected)
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.City = city;
            Assert.Equal(addressTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing state property
        /// Used for TestValidState(string state, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> StateTestCases = ImmutableList.Create
        (
            new object[]{ "", false },
            new object[]{ "testestest", false },
            new object[]{ "       ", false },
            new object[]{ 12345.ToString(), false },
            new object[]{ string.Empty, false },
            new object[]{ null, false },
            new object[]{ "FL", true },
            new object[]{ "NY", true },
            new object[]{ "IA", true },
            new object[]{ "fl", true },
            new object[]{ "ky", true },
            new object[]{ 12.ToString(), false },
            new object[]{ "AA", false },
            new object[]{ "A1", false },
            new object[]{ "99", false }
        );

        /// <summary>
        /// Test for valid state
        /// </summary>
        /// <param name="state">state code</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(StateTestCases))]
        public void TestValidState(string stateCode, bool expected)
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.State = stateCode;
            Assert.Equal(addressTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing postal code property
        /// Used for TestValidPostalCode(string postalCode, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> PostalCodeTestCases = ImmutableList.Create
        (
            new object[]{ "", false },
            new object[]{ "testestest", false },
            new object[]{ "       ", false },
            new object[]{ 12345.ToString(), true },
            new object[]{ string.Empty, false },
            new object[]{ null, false },
            new object[]{ "12345", true },
            new object[]{ "1234", false },
            new object[]{ "123456", false },
            new object[]{ "fffff", false },
            new object[]{ "1234a", false }
        );

        /// <summary>
        /// Test for valid postal code
        /// </summary>
        /// <param name="postalCode">postal/zip code</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(PostalCodeTestCases))]
        public void TestValidPostalCode(string postalCode, bool expected)
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.PostalCode = postalCode;
            Assert.Equal(addressTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing country property
        /// Used for TestValidCountry(string countryCode, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> CountryTestCases = ImmutableList.Create
        (
            new object[]{ "", false },
            new object[]{ "testestest", false },
            new object[]{ "       ", false },
            new object[]{ 12345.ToString(), false },
            new object[]{ string.Empty, false },
            new object[]{ null, false },
            new object[]{ "FL", false },
            new object[]{ "NY", false },
            new object[]{ "IA", false },
            new object[]{ "US", true },
            new object[]{ "us", true },
            new object[]{ 12.ToString(), false },
            new object[]{ "AA", false },
            new object[]{ "A1", false },
            new object[]{ "99", false }
        );

        /// <summary>
        /// Test for valid state
        /// </summary>
        /// <param name="country">country code</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(CountryTestCases))]
        public void TestValidCountry(string countryCode, bool expected)
        {
            Batch.Library.Models.Address addressTemp = address;
            addressTemp.Country = countryCode;
            Assert.Equal(addressTemp.Validate(), expected);
        }
    }
}
