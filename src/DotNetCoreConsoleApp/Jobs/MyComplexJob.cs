using System;

using FluentScheduler;

namespace DotNetCoreConsoleApp.Jobs
{
	public class MyComplexJob : IJob
	{
		private string _message;
		private DateTime _dateTime;

		public MyComplexJob()
		{
		}

		public MyComplexJob(string message, DateTime dateTime)
		{
			_message = message;
			_dateTime = dateTime;
		}

		public void Execute()
		{
			Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Starting Job '{nameof(MyComplexJob)}'.");
		}
	}
}