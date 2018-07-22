using System;

namespace DotNetCoreKatas.Core.Domain
{
	public class Entity<T> where T : IComparable<T>
	{
	}
}