using DotNetCoreKatas.Core.Interfaces;
using DotNetCoreKatas.Domain.Events;

namespace DotNetCoreKatas.Domain.Models
{
	public partial class BookDomainModel : IAggregateRoot<int>
	{
		/// <inheritdoc />
		/// <summary>
		/// This should be our only option to instantiate a new Book AR.
		/// </summary>
		/// <param name="id"></param>
		private BookDomainModel(int id)
			: this()
		{
			Id = id;
		}

		/// <summary>
		/// Needed by EF Core.
		/// </summary>
		private BookDomainModel()
		{
		}

		public static BookDomainModel Create(int id)
		{
			return new BookDomainModel(1);
		}

		public int Id { get; private set; }

		public string Isbn { get; private set; }

		public string Title { get; set; }

		public int Version { get; private set; }

		public BookDomainModel SetTitle(string title)
		{
			Title = title;

			var @event = new BookTitleUpdatedEvent(Id, title);

			return this;
		}

		public BookDomainModel SetIsbn(string isbn)
		{
			Isbn = isbn;

			return this;
		}
	}
}