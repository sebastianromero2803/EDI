using EDI.Contracts.Repository;
using EDI.Core.V1;
using EDI.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EDIController : ControllerBase
    {
        private readonly EDICore _ediCore;

        public EDIController(IEDIRepository context, ILogger<X12_315> logger)
        {
            _ediCore = new EDICore(context, logger);
        }

        // GET: api/<EDIController>
        [HttpGet]
        public string Get()
        {
            var response = _ediCore.GetContainer();
            return response;
        }

        // GET api/<EDIController>/5
        [HttpGet("{id}")]
        [ActionName("GetAll")]
        public async Task<List<Item>> GetAll()
        {
            return await _ediCore.GetAllContainers("SELECT * FROM c");
        }

        // POST api/<EDIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EDIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EDIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
