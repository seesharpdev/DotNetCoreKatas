using System;

using DotNetCoreKatas.Core.Interfaces;

namespace DotNetCoreKatas.Core.Domain
{
	public abstract class AggregateRoot<T> 
		: Entity<T>, IAggregateRoot where T : IComparable<T>
	{
	}
}