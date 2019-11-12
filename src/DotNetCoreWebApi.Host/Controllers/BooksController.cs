using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using DotNetCoreKatas.Command.Adapter.Contracts;
using DotNetCoreKatas.Command.Contracts; // TODO: Move to DotNetCoreKatas.Domain.
using DotNetCoreKatas.Core.Interfaces.Querying;
using DotNetCoreKatas.Query.Contracts.Models;
using DotNetCoreWebApi.Host.Infrastructure.Filters;

namespace DotNetCoreWebApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
	    #region Private Members

	    private readonly IQueryAdapter<BookReadModel, int> _queryAdapter;
		private readonly IAzureServiceBusCommandAdapter _commandAdapter;

	    #endregion

	    #region Ctor's

	    public BooksController(
		    IQueryAdapter<BookReadModel, int> queryAdapter, 
		    IAzureServiceBusCommandAdapter commandAdapter)
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
		[ModelValidation]
        public ActionResult Post([FromBody] BookReadModel model)
        {
	        var command = new RegisterBookCommand { Id = model.Id };
	        _commandAdapter.Dispatch(command);

			return CreatedAtAction("Get", new { id = model.Id }, model);
		}

        [HttpPut("{id}")]
		[ModelValidation]
        public ActionResult Put(int id, [FromBody] BookReadModel model)
        {
			if (id != model.Id)
			{
				return BadRequest();
			}

	        var command = new UpdateBookCommand { Id = model.Id };
	        _commandAdapter.Dispatch(command);

	        return NoContent();
		}

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
	        if (id == 0)
	        {
		        return NotFound();
	        }

	        var command = new DeleteBookCommand { Id = id };
	        _commandAdapter.Dispatch(command);

	        return Ok();
		}
    }
}
