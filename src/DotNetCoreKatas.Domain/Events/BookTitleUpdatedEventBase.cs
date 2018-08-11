using System;

using DotNetCoreKatas.Core.Interfaces.Domain;
using DotNetCoreKatas.Domain.Models;

namespace DotNetCoreKatas.Domain.Events
{
	public abstract class BookTitleUpdatedEventBase : IDomainEvent<BookDomainModel>
	{
		public BookTitleUpdatedEventBase()
		{
			CorrelationId = Guid.NewGuid();
		}

		public Guid CorrelationId { get; }

		public abstract string Describe();
	}
}