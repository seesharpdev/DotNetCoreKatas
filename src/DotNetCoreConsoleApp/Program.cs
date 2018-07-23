using System;
using System.Threading.Tasks;
using FluentScheduler;
using Serilog;
using Serilog.Events;

namespace DotNetCoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
	        Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Starting DotNetCoreConsoleApp...");
	        //Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Press Control + C to exit.");

			BoostrapLogger();
	        BoostrapScheduler();

	        //Console.WriteLine("Press any key to exit...");
	        Console.ReadKey();
        }

	    private static void BoostrapLogger()
	    {
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateLogger();
		}

		private static void BoostrapScheduler()
	    {
		    Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Starting JobManager...");

			var schedulerTask = Task.Factory.StartNew(() =>
				{
					JobManager.Initialize(new SchedulerJobsRegistry());
					JobManager.JobException += OnJobException();
				});

			Console.WriteLine($"{DateTime.UtcNow.ToLocalTime()} | Running JobManager...");
		}

	    private static Action<JobExceptionInfo> OnJobException()
	    {
		    return info => Log.Fatal("An error just happened with a scheduled job: " + info.Exception);
	    }
    }
}
