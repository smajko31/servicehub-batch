using ServiceHub.Batch.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace ServiceHub.Batch.Testing.Context
{
    public class ModelMapperTest
    {
        /// <value> Library batch model to convert </value>
        readonly Batch.Library.Models.Batch libBatch;
        /// <value> List of context batch models to convert </value>
        readonly List<Batch.Context.Models.Batch> ctxList;

        /// <summary>
        /// Test conversion between context and library models
        /// </summary>
        public ModelMapperTest()
        {
            #region ModelMapperTest constructor setup
            /// <summary>
            /// Set up valid library Batch model to test conversion
            /// </summary>
            libBatch = new Batch.Library.Models.Batch
            {
                Address = new Batch.Library.Models.Address
                {
                    Address1 = "Test Address1",
                    Address2 = "Test Address2",
                    AddressId = Guid.NewGuid(),
                    City = "Tampa",
                    Country = "US",
                    PostalCode = "33617",
                    State = "FL"
                },
                BatchId = Guid.NewGuid(),
                BatchName = "1806-apr-net",
                BatchOccupancy = 40,
                BatchSkill = "C# .NET",
                EndDate = DateTime.Today,
                StartDate = DateTime.Today,
                UserIds = new List<Guid>
                {
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid()
                }
            };

            /// <summary>
            /// Set up valid list of context Batch models to test conversion
            /// </summary>
            ctxList = new List<Batch.Context.Models.Batch>
            {
                new Batch.Context.Models.Batch()
                {
                    Address = new Batch.Context.Models.Address
                    {
                        Address1 = "Bellarmine Newman Hall",
                        AddressId = Guid.NewGuid(),
                        City = "Tampa",
                        Country = "US",
                        PostalCode = "33617",
                        State = "FL"
                    },
                    BatchId = Guid.NewGuid(),
                    BatchName = "1806-apr-net",
                    BatchOccupancy = 40,
                    BatchSkill = "C# .NET",
                    EndDate = DateTime.Today,
                    StartDate = DateTime.Today,
                    UserIds = new List<Guid>
                    {
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        Guid.NewGuid()
                    }
                },

                new Batch.Context.Models.Batch()
                {
                    Address = new Batch.Context.Models.Address
                    {
                        Address1 = "Test Address1",
                        Address2 = "Test Address2",
                        AddressId = Guid.NewGuid(),
                        City = "Some City",
                        Country = "US",
                        PostalCode = "12345",
                        State = "WA"
                    },
                    BatchId = Guid.NewGuid(),
                    BatchName = "111-java-batch",
                    BatchOccupancy = 15,
                    BatchSkill = "Java",
                    EndDate = DateTime.Today,
                    StartDate = DateTime.Today,
                    UserIds = new List<Guid>
                    {
                        Guid.NewGuid(),
                        Guid.NewGuid(),
                        Guid.NewGuid()
                    }
                },
            };
            #endregion
        }

        /// <summary>
        /// Convert library batch model to context batch model, then test properties
        /// </summary>
        [Fact]
        public void LibToCtxConvertPropertiesTest()
        {
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);
            Assert.True(ctxBatchTemp.BatchId.Equals(libBatch.BatchId));
            Assert.Equal(ctxBatchTemp.BatchName, libBatch.BatchName);
            Assert.True(ctxBatchTemp.BatchOccupancy.Equals(libBatch.BatchOccupancy));
            Assert.True(ctxBatchTemp.StartDate.Equals(libBatch.StartDate));
            Assert.True(ctxBatchTemp.EndDate.Equals(libBatch.EndDate));
            Assert.Equal(ctxBatchTemp.BatchSkill, libBatch.BatchSkill);
            Assert.True(ctxBatchTemp.UserIds.Equals(libBatch.UserIds));
        }

        /// <summary>
        /// Convert invalid library batch model to context batch model, then test for null model
        /// </summary>
        [Fact]
        public void InvalidLibToCtxConvertPropertiesTest()
        {
            Batch.Library.Models.Batch libBatchTemp = new Batch.Library.Models.Batch();
            libBatchTemp = libBatch;
            libBatchTemp.BatchName = null;
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);

            Assert.True(ctxBatchTemp == null);
        }

        /// <summary>
        /// Convert context batch model to library batch model, then test properties
        /// </summary>
        [Fact]
        public void CtxToLibConvertPropertiesTest()
        {
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);
            Batch.Library.Models.Batch libBatchTemp = new Batch.Library.Models.Batch();
            libBatchTemp = ModelMapper.ToLibraryBatchModel(ctxBatchTemp);
            Assert.True(ctxBatchTemp.BatchId.Equals(libBatchTemp.BatchId));
            Assert.Equal(ctxBatchTemp.BatchName, libBatchTemp.BatchName);
            Assert.True(ctxBatchTemp.BatchOccupancy.Equals(libBatchTemp.BatchOccupancy));
            Assert.True(ctxBatchTemp.StartDate.Equals(libBatchTemp.StartDate));
            Assert.True(ctxBatchTemp.EndDate.Equals(libBatchTemp.EndDate));
            Assert.Equal(ctxBatchTemp.BatchSkill, libBatchTemp.BatchSkill);
            Assert.True(ctxBatchTemp.UserIds.Equals(libBatchTemp.UserIds));
        }

        /// <summary>
        /// Convert invalid context batch model to library batch model, then test for null model
        /// </summary>
        [Fact]
        public void InvalidCtxToLibConvertPropertiesTest()
        {
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);
            ctxBatchTemp.BatchOccupancy = null;
            Batch.Library.Models.Batch libBatchTemp = new Batch.Library.Models.Batch();
            libBatchTemp = ModelMapper.ToLibraryBatchModel(ctxBatchTemp);

            Assert.True(libBatchTemp == null);
        }

        /// <summary>
        /// Convert library batch address model to context batch address model, then test properties
        /// </summary>
        [Fact]
        public void LibToCtxConvertAddressTest()
        {
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);
            Batch.Context.Models.Address ctxBatchAddress = ModelMapper.ToContextAddressModel(libBatch.Address);
            Assert.True(ctxBatchAddress.AddressId.Equals(libBatch.Address.AddressId));
            Assert.Equal(ctxBatchAddress.Address1, libBatch.Address.Address1);
            Assert.Equal(ctxBatchAddress.Address2, libBatch.Address.Address2);
            Assert.Equal(ctxBatchAddress.City, libBatch.Address.City);
            Assert.Equal(ctxBatchAddress.Country, libBatch.Address.Country);
            Assert.Equal(ctxBatchAddress.PostalCode, libBatch.Address.PostalCode);
            Assert.Equal(ctxBatchAddress.State, libBatch.Address.State);
        }

        /// <summary>
        /// Convert invalid library batch address model to context batch address model, then test for null model
        /// </summary>
        [Fact]
        public void InvalidLibToCtxConvertAddressTest()
        {
            Batch.Library.Models.Address libBatchAddress = new Batch.Library.Models.Address();
            libBatchAddress = libBatch.Address;
            libBatchAddress.Country = "INVALID";
            Batch.Context.Models.Address ctxBatchAddress = ModelMapper.ToContextAddressModel(libBatchAddress);
            Assert.True(ctxBatchAddress == null);
        }

        /// <summary>
        /// Convert context batch address model to library batch address model, then test properties
        /// </summary>
        [Fact]
        public void CtxToLibConvertAddressTest()
        {
            Batch.Context.Models.Batch ctxBatchTemp = new Batch.Context.Models.Batch();
            ctxBatchTemp = ModelMapper.ToContextBatchModel(libBatch);
            Batch.Library.Models.Batch libBatchTemp = new Batch.Library.Models.Batch();
            libBatchTemp = ModelMapper.ToLibraryBatchModel(ctxBatchTemp);
            Batch.Library.Models.Address libBatchAddress = ModelMapper.ToLibraryAddressModel(ctxBatchTemp.Address);
            Assert.True(libBatchAddress.AddressId.Equals(libBatch.Address.AddressId));
            Assert.Equal(libBatchAddress.Address1, libBatch.Address.Address1);
            Assert.Equal(libBatchAddress.Address2, libBatch.Address.Address2);
            Assert.Equal(libBatchAddress.City, libBatch.Address.City);
            Assert.Equal(libBatchAddress.Country, libBatch.Address.Country);
            Assert.Equal(libBatchAddress.PostalCode, libBatch.Address.PostalCode);
            Assert.Equal(libBatchAddress.State, libBatch.Address.State);
        }

        /// <summary>
        /// Convert invalid context batch address model to library batch address model, then test for null model
        /// </summary>
        [Fact]
        public void InvalidCtxToLibConvertAddressTest()
        {
            Batch.Context.Models.Address ctxBatchAddress = new Batch.Context.Models.Address();
            ctxBatchAddress = ModelMapper.ToContextAddressModel(libBatch.Address);
            ctxBatchAddress.Country = "INVALID";
            Batch.Library.Models.Address libBatchAddress = ModelMapper.ToLibraryAddressModel(ctxBatchAddress);
            Assert.True(libBatchAddress == null);
        }

        /// <summary>
        /// Convert library batch model list to context batch model list, then test properties
        /// </summary>
        [Fact]
        public void LibToCtxConvertListTest()
        {
            List<Batch.Library.Models.Batch> libList = new List<Batch.Library.Models.Batch>();
            libList = ModelMapper.ToLibraryList(ctxList);
            Assert.Equal(libList.Count, ctxList.Count);
            foreach (var ctxBatch in ctxList)
            {
                Assert.Contains(libList, x => x.BatchId == ctxBatch.BatchId);
                Assert.Contains(libList, x => x.BatchName == ctxBatch.BatchName);
                Assert.Contains(libList, x => x.BatchSkill == ctxBatch.BatchSkill);
                Assert.Contains(libList, x => x.BatchOccupancy == ctxBatch.BatchOccupancy);
                Assert.Contains(libList, x => x.EndDate == ctxBatch.EndDate);
                Assert.Contains(libList, x => x.StartDate == ctxBatch.StartDate);
            }
        }

        /// <summary>
        /// Convert invalid library batch model list to context batch model list, then test that list is null
        /// </summary>
        [Fact]
        public void InvalidLibToCtxConvertListTest()
        {
            List<Batch.Context.Models.Batch> ctxListTemp = new List<Batch.Context.Models.Batch>();
            ctxListTemp = ctxList;
            foreach (var batchContext in ctxListTemp)
            {
                batchContext.BatchName = "";
            }
            List<Batch.Library.Models.Batch> libList = new List<Batch.Library.Models.Batch>();
            libList = ModelMapper.ToLibraryList(ctxListTemp);
            Assert.True(libList == null);
        }
    }
}