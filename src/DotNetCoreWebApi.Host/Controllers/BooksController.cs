using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using DotNetCoreKatas.Command.Adapter.Commands;
using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Query.Contracts.Adapters;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreWebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
	    #region Private Members

	    private readonly IBooksQueryAdapter _queryAdapter;
	    private readonly IBooksCommandAdapter _commandAdapter;

	    #endregion

	    #region Ctor's

	    public BooksController(IBooksQueryAdapter queryAdapter, IBooksCommandAdapter commandAdapter)
	    {
		    _queryAdapter = queryAdapter;
		    _commandAdapter = commandAdapter;
	    }

		#endregion

	    [HttpGet]
        public async Task<ActionResult> Get()
        {
			var books = await _queryAdapter.GetAll();

	        return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        var book = await _queryAdapter.GetById(id);

	        return Ok(book);
        }

        [HttpPost]
        public ActionResult Post([FromBody] BookReadModel model)
        {
	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

	        _commandAdapter.CreateBook(new CreateBookCommand { Id = model.Id });

			return CreatedAtAction("Get", new { id = model }, model);
		}

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookReadModel model)
        {
			if (id != model.Id)
			{
				return NoContent();
	        }

	        _commandAdapter.UpdateBook(new UpdateBookCommand { Id = model.Id });

			return BadRequest();
		}

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        var command = new DeleteBookCommand { Id = id };
	        _commandAdapter.DeleteBook(command);

	        return Ok();
		}
    }
}
