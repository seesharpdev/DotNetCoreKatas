using System.ComponentModel.DataAnnotations;

using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Domain.Models
{
	public class BookDomainModel : IAggregateRoot<int>
	{
		#region Ctor's

		/// <summary>
		/// This should be our only option to instantiate a new Book AR.
		/// </summary>
		/// <param name="id"></param>
		public BookDomainModel(int id)
		{
			Id = id;
		}

		/// <summary>
		/// Needed by EF Core.
		/// </summary>
		// ReSharper disable once UnusedMember.Local
		private BookDomainModel()
		{
		}

		#endregion

		[Key]
		public int Id { get; }
	}
}