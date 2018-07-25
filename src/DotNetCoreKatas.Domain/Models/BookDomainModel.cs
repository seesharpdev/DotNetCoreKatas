using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Domain.Models
{
	public class BookDomainModel : IAggregateRoot<int>
	{
		#region Private Members

		private int _id;

		#endregion

		/// <inheritdoc />
		/// <summary>
		/// This should be our only option to instantiate a new Book AR.
		/// </summary>
		/// <param name="id"></param>
		public BookDomainModel(int id)
			: this()
		{
			_id = id;
		}

		/// <summary>
		/// Needed by EF Core.
		/// </summary>
		private BookDomainModel()
		{
		}

		public int Id => _id;
	}
}