using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Models;
using DotNetCoreKatas.Query.Contracts.Models;

namespace DotNetCoreKatas.Query.Adapter.Mappers
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