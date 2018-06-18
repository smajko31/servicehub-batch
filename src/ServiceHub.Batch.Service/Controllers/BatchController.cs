using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ServiceHub.Batch.Context.Utilities;

namespace ServiceHub.Batch.Service.Controllers
{
    public class BatchController : BaseController
    {
        public Storage storage;
        private new readonly ILogger logger;

        /// <summary>
        /// Overload constructor to dependency inject repository class
        /// </summary>
        /// <param name="loggerFactory"></param>
        public BatchController(IUtility util, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            storage = new Storage(util);
            logger = loggerFactory.CreateLogger("requests");
        }

        /// <summary>
        /// Get all batches from database
        /// </summary>
        /// <returns>A List of all the batch models from the database</returns>
        [HttpGet]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var myTask = Task.Run(() => storage.GetAllBatchesAsync());
                List<Library.Models.Batch> result = await myTask;
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Return all batches based on skill
        /// </summary>
        /// <param name="skill">Batch skill ex. Java</param>
        /// <returns>List of Batches</returns>
        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches/skill")]
        public async Task<IActionResult> GetBySkill([FromBody] string skill)
        {
            try
            {
                var myTask = Task.Run(() => storage.GetBatchesBySkillAsync(skill));
                List<Library.Models.Batch> result = await myTask;
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Takes an address model and extracts the city and state. Returns batches based on city and state.
        /// </summary>
        /// <param name="myAddress">Address model with filled City and State</param>
        /// <returns>List of Batches</returns>
        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches/location")]
        public async Task<IActionResult> GetByLocation([FromBody] string state)
        {
            try
            {
                var myTask = Task.Run(() => storage.GetBatchesByLocationAsync(state));
                List<Library.Models.Batch> result = await myTask;
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return StatusCode(500);
            }
        }
    }
}