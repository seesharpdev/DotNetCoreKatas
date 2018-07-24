using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.QueryAdapter.Contracts;

namespace DotNetCoreKatas.QueryAdapter.Mappers
{
	public class BookModelMapper : IModelMapper<BookDomainModel, BookReadModel>
	{
		public BookReadModel Map(BookDomainModel model)
		{
			var readModel = new BookReadModel
				{
					Id = model.Id
				};

			return readModel;
		}
	}
}