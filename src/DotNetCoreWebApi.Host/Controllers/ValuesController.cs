using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
	        var strings = new[] { "value1", "value2" };

	        return Ok(strings);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
	        const string value = "value";
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        return Ok(value);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

			return CreatedAtAction("Get", new { id = value }, value);
		}

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
			// TODO: Validate the id with the passed in object identifier (id == value.id)
			if (id.ToString() == value)
			{
				return NoContent();
	        }

	        return BadRequest();
		}

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
