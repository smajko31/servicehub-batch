using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Batch.Testing.Service
{
    public class BatchControllerTest
    {
        /// <summary>
        /// Initialize dummy data Address and Batch models
        /// </summary>
        Batch.Library.Models.Batch testBatch1;
        Batch.Library.Models.Batch testBatch2;
        Batch.Library.Models.Batch testBatch3;

        static ILoggerFactory loggerFactory = new LoggerFactory();

        /// <summary>
        /// Instantiate dummy Address and Batch models
        /// </summary>
        public BatchControllerTest()
        {
            testBatch1 = new Batch.Library.Models.Batch()
            {

                BatchId = Guid.NewGuid(),
                BatchSkill = "C#",
                State = "MA"

            };
            testBatch2 = new Batch.Library.Models.Batch()
            {
                BatchId = Guid.NewGuid(),
                BatchSkill = "Java",
                State = "IL"

            };
            testBatch3 = new Batch.Library.Models.Batch()
            {
                BatchId = Guid.NewGuid(),
                BatchSkill = "C#",
                State = "MA"

            };
        }

        /// <summary>
        /// Test getting all batches from the database. Compare dummy data from MemoryUtility to BatchController.Get()
        /// </summary>
        [Fact]
        public void GetAllTest()
        {
            Batch.Service.Controllers.BatchController controller = new Batch.Service.Controllers.BatchController(loggerFactory);

            List<Batch.Library.Models.Batch> newBatch = new List<Batch.Library.Models.Batch>();
            controller.utility.AddBatch(testBatch1);
            controller.utility.AddBatch(testBatch2);
            controller.utility.AddBatch(testBatch3);
            newBatch = controller.utility.GetAllBatches();

            List<Batch.Library.Models.Batch> newBatch2 = new List<Batch.Library.Models.Batch>();
            var actionResultTask = controller.Get();
            actionResultTask.Wait();
            var res = actionResultTask.Result as OkObjectResult;
            var result = res.Value;

            newBatch2 = (List<Batch.Library.Models.Batch>)result;

            Assert.Equal(newBatch.Count, newBatch2.Count);
        }

        /// <summary>
        /// Compare expected return with actual return from GetBySkill(String skill)
        /// </summary>
        /// <param name="skill">Test "C#" input and "Java" input</param>
        [Theory]
        [InlineData("C#")]
        [InlineData("Java")]
        void GetBySkillTest(String skill)
        {
            Batch.Service.Controllers.BatchController controller = new Batch.Service.Controllers.BatchController(loggerFactory);

            List<Batch.Library.Models.Batch> newBatch = new List<Batch.Library.Models.Batch>();
            controller.utility.AddBatch(testBatch1);
            controller.utility.AddBatch(testBatch2);
            controller.utility.AddBatch(testBatch3);

            List<Batch.Library.Models.Batch> testC = new List<Batch.Library.Models.Batch>();
            var batchSkill = controller.GetBySkill(skill);
            batchSkill.Wait();
            var res = batchSkill.Result as OkObjectResult;
            var result = res.Value;
            testC = (List<Batch.Library.Models.Batch>)result;

            if (skill == "C#")
            {
                Assert.Equal(2, testC.Count);
            }
            if (skill == "Java")
            {
                Assert.Equal(1, testC.Count);
            }
        }

        /// <summary>
        /// Compare expected result with result from GetByLocation(Address)
        /// </summary>
        [Fact]
        void GetByLocationTest()
        {
            Batch.Service.Controllers.BatchController controller = new Batch.Service.Controllers.BatchController(loggerFactory);

            List<Batch.Library.Models.Batch> newBatch = new List<Batch.Library.Models.Batch>();
            controller.utility.AddBatch(testBatch1);
            controller.utility.AddBatch(testBatch2);
            controller.utility.AddBatch(testBatch3);

            List<Batch.Library.Models.Batch> testL = new List<Batch.Library.Models.Batch>();
            var batchLocation = controller.GetByLocation("MA");
            batchLocation.Wait();
            var res = batchLocation.Result as OkObjectResult;
            var result = res.Value;
            testL = (List<Batch.Library.Models.Batch>)result;

            Assert.Equal(2, testL.Count);
        }
    }
}