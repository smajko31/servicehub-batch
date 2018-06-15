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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory"></param>
        public BatchController(ILoggerFactory loggerFactory) : base(loggerFactory) { }

        /// <summary>
        /// Temporary storage
        /// </summary>
        public MemoryUtility utility = new MemoryUtility();

        /// <summary>
        /// Get all batches from database
        /// </summary>
        /// <returns>A List of all the batch models from the database</returns>
        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches")]
        public async Task<IActionResult> Get()
        {
            var myTask = Task.Run(() => utility.GetAllBatches());
            List<Library.Models.Batch> result = await myTask;

            return Ok(result);
        }

        /// <summary>
        /// Return all batches based on skill
        /// </summary>
        /// <param name="skill">Batch skill ex. Java</param>
        /// <returns>List of Batches</returns>
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches/skill")]
        public async Task<IActionResult> GetBySkill([FromBody] string skill)
        {
            var myTask = Task.Run(() => utility.GetBatchesBySkill(skill));
            List<Library.Models.Batch> result = await myTask;
            return Ok(result);
        }

        /// <summary>
        /// Takes an address model and extracts the city and state. Returns batches based on city and state.
        /// </summary>
        /// <param name="myAddress">Address model with filled City and State</param>
        /// <returns>List of Batches</returns>
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Library.Models.Batch>))]
        [Route("api/Batches/location")]
        public async Task<IActionResult> GetByLocation([FromBody] string state)
        {
            var myTask = Task.Run(() => utility.GetBatchesByLocation(state));
            List<Library.Models.Batch> result = await myTask;
            return Ok(result);
        }
    }
}