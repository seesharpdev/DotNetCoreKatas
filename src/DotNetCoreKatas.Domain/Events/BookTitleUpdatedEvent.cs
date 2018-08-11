using DotNetCoreKatas.Core.Interfaces.Domain;
using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Domain.Events
{
	public class BookTitleUpdatedEvent : BookTitleUpdatedEventBase, IDomainEvent<BookDomainModel>
	{
		private readonly int _id;
		private readonly string _title;

		public BookTitleUpdatedEvent(int id, string title)
			: base()
		{
			_id = id;
			_title = title;
		}

		public override string Describe()
		{
			return $"Book with {_id} had its title set to {_title}.";
		}
	}
}