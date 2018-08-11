using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Domain.Models
{
	public class DomainModel : IAggregateRoot<int>
	{
		#region Private Members

		// Backing Fields needed by EF to hydrate our models.
		private int _id;
		private int _version;

		#endregion

		/// <summary>
		/// This should be our only option to instantiate a new Aggregate Root.
		/// </summary>
		/// <param name="id"></param>
		public DomainModel(int id)
			: this()
		{
			_id = id;
		}

		/// <summary>
		/// Needed by the EF/ORM. Do not remove.
		/// </summary>
		private DomainModel()
		{
		}

		public virtual int Id => _id;

		public virtual int Version => _version;
	}
}