using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using DotNetCoreKatas.Query.Contracts.Adapters;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreWebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
	    #region Private Members

	    private readonly IBooksQueryAdapter _adapter;

		#endregion

	    #region Ctor's

	    public BooksController(IBooksQueryAdapter adapter)
	    {
		    _adapter = adapter;
	    }

		#endregion

	    [HttpGet]
        public async Task<ActionResult> Get()
        {
			var books = await _adapter.GetAll();

	        return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        var book = await _adapter.GetById(id);

	        return Ok(book);
        }

		/// <summary>
		/// The Post method should expect a 'ICreateBookCommand'.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] BookReadModel model)
        {
	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

			// TODO: Implement the CommandService

			return CreatedAtAction("Get", new { id = model }, model);
		}

		/// <summary>
		/// The Put method should expect a 'IUpdateBookCommand'.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="model"></param>
		/// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookReadModel model)
        {
			if (id != model.Id)
			{
				return NoContent();
	        }

	        // TODO: Implement the CommandService

			return BadRequest();
		}

		/// <summary>
		/// The Delete method should expect a 'IDeleteBookCommand'.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
	        if (id == 0)
	        {
		        return NotFound();
	        }

			// TODO: Implement the CommandService

	        return Ok();
		}
    }
}
