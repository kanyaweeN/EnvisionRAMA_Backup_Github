using System.ServiceProcess;
using System.Timers;
using EnvisionClearLog;

namespace EnvisionClearLogService
{
	public class Service : ServiceBase
	{
		private Timer timer;

		public Service()
		{
			ServiceName = "EnvisionClearLogService";
		}

		protected override void OnStart(string[] args)
		{
			timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
			timer.Interval = 1000;
			timer.Start();
		}
		protected override void OnStop()
		{
			timer.Stop();
		}

		private void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			timer.Stop();

			new ClearLog().Invoke();

			timer.Interval = ConfigService.TimeInterval;
			timer.Start();
		}
	}
}
