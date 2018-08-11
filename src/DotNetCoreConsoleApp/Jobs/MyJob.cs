using System;

using FluentScheduler;

namespace DotNetCoreConsoleApp.Jobs
{
	public class MyJob : IJob
	{
		public void Execute()
		{
			Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Starting Job '{nameof(MyJob)}'.");
		}
	}
}