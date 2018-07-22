using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
	        var strings = new[] { "value1", "value2" };

	        return Ok(strings);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
	        const string value = "value";
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

			return CreatedAtAction("Get", new { id = value }, value);
		}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
	        //var existingItem = _service.GetById(id);
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        //_service.Remove(id);
	        return Ok();
		}
    }
}
