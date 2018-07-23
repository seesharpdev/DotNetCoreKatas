using System;

using FluentScheduler;

namespace DotNetCoreConsoleApp.Jobs
{
	public class MyOtherJob : IJob
	{
		public void Execute()
		{
			Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Starting Job '{nameof(MyOtherJob)}'.");
		}
	}
}