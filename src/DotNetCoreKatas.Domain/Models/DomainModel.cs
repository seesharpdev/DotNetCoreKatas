using DotNetCoreKatas.Core.Domain;

namespace DotNetCoreKatas.Domain.Models
{
	public class DomainModel : AggregateRoot<int>
	{
		/// <summary>
		/// This should be our only option to instantiate a new Aggregate Root.
		/// </summary>
		/// <param name="id"></param>
		public DomainModel(int id)
		{
			Id = id;
		}

		/// <summary>
		///  Needed by the EF/ORM.
		/// </summary>
		private DomainModel()
		{
		}
	}
}