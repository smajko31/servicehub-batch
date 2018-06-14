using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace ServiceHub.Batch.Testing.Library
{
    public class BatchTest
    {
        /// <value> Batch model to have all valid properties </value>
        readonly Batch.Library.Models.Batch batch;

        /// <summary>
        /// Create a valid Batch model to create copies per unit test, and test
        /// for individual invalid properties.
        /// </summary>
        public BatchTest()
        {
            /// <value> Initialize and define valid Batch model </value>
            batch = new Batch.Library.Models.Batch()
            {
                BatchId = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                BatchName = "TestBatch",
                BatchOccupancy = 30,
                BatchSkill = ".NET",
                State = "Fl",
                UserIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() }
            };
        }

        /// <summary>
        /// Test Batch model with default initialized values
        /// </summary>
        [Fact]
        public void TestDefaultBatch()
        {
            Assert.False(new Batch.Library.Models.Batch().Validate());
        }

        /// <summary>
        /// Test valid Batch model created by the constructor
        /// </summary>
        [Fact]
        public void TestUnitBatch()
        {
            Assert.True(batch.Validate());
        }

        /// <summary>
        /// Replace Guid in valid Batch model with empty Guid, then test validity of model 
        /// </summary>
        [Fact]
        public void TestInvalidId()
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.BatchId = Guid.Empty;
            Assert.False(batch.Validate());
        }

        /// <summary>
        /// Create complex type for testing DateTime property
        /// Used for TestValidStartDate(DateTime? date, bool expected)
        /// and TestValidEndDate(DateTime? date, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> DateTestCases = ImmutableList.Create
        (
            new object[]{ DateTime.Now, true },
            new object[]{ DateTime.UtcNow, true },
            new object[]{ DateTime.Today, true },
            new object[]{ null, false }
        );

        /// <summary>
        /// Test for valid start dates
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(DateTestCases))]
        public void TestValidStartDate(DateTime? date, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.StartDate = date;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Test for valid end dates
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(DateTestCases))]
        public void TestValidEndDate(DateTime? date, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.EndDate = date;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing BatchName property
        /// Used for TestValidBatchName(string batchName, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> BatchNameTestCases = ImmutableList.Create
        (
            new object[]{ "", false },
            new object[]{ "1804-apr-net", true },
            new object[]{ "some-java-batch", true },
            new object[]{ "       ", true },
            new object[]{ 12345.ToString(), true },
            new object[]{ string.Empty, false },
            new object[]{ null, false }
        );

        /// <summary>
        /// Test for valid batch names
        /// </summary>
        /// <param name="batchName">batch name string</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(BatchNameTestCases))]
        public void TestValidBatchName(string batchName, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.BatchName = batchName;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing BatchOccupancy property
        /// Used for TestValidBatchOccupancy(int? batchOccupancy, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> BatchOccupancyTestCases = ImmutableList.Create
        (
            new object[]{ -100, false },
            new object[]{ 0, true },
            new object[]{ 50, true },
            new object[]{ 2000, true },
            new object[]{ null, false }
        );

        /// <summary>
        /// Test for valid batch occupancy number
        /// </summary>
        /// <param name="batchOccupancy">nullable batch occupancy integer</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(BatchOccupancyTestCases))]
        public void TestValidBatchOccupancy(int? batchOccupancy, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.BatchOccupancy = batchOccupancy;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing BatchSkill property
        /// Used for TestValidBatchSkill(string batchSkill, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> BatchSkillTestCases = ImmutableList.Create
        (
            new object[]{ "", false },
            new object[]{ "Java", true },
            new object[]{ "C# .NET", true },
            new object[]{ "       ", true },
            new object[]{ 12345.ToString(), true },
            new object[]{ string.Empty, false },
            new object[]{ null, false }
        );

        /// <summary>
        /// Test for valid batch skill strings
        /// </summary>
        /// <param name="batchSkill">batch skill string</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(BatchSkillTestCases))]
        public void TestValidBatchSkill(string batchSkill, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.BatchSkill = batchSkill;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing state property
        /// Used for TestValidState(string state, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> StateTestCases = ImmutableList.Create
        (
            new object[] { "", false },
            new object[] { "testestest", false },
            new object[] { "       ", false },
            new object[] { 12345.ToString(), false },
            new object[] { string.Empty, false },
            new object[] { null, false },
            new object[] { "FL", true },
            new object[] { "NY", true },
            new object[] { "IA", true },
            new object[] { "fl", true },
            new object[] { "ky", true },
            new object[] { 12.ToString(), false },
            new object[] { "AA", false },
            new object[] { "A1", false },
            new object[] { "99", false }
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
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.State = stateCode;
            Assert.Equal(batchTemp.Validate(), expected);
        }

        /// <summary>
        /// Create complex type for testing UserIds property
        /// Used for TestUserIds(List<Guid> userIds, bool expected)
        /// </summary>
        public static readonly ImmutableList<object[]> UserIdsTestCases = ImmutableList.Create
        (
            new object[]{ null, false },
            new object[]{ new List<Guid>(), false },
            new object[]{ new List<Guid> { Guid.NewGuid() }, true },
            new object[]{ new List<Guid> { Guid.NewGuid(), Guid.NewGuid() }, true }
        );

        /// <summary>
        /// Test for valid userIds list
        /// </summary>
        /// <param name="userIds">list of user ids in batch</param>
        /// <param name="expected">expected bool value</param>
        [Theory]
        [MemberData(nameof(UserIdsTestCases))]
        public void TestUserIds(List<Guid> userIds, bool expected)
        {
            Batch.Library.Models.Batch batchTemp = batch;
            batchTemp.UserIds = userIds;
            Assert.Equal(batchTemp.Validate(), expected);
        }
    }
}
