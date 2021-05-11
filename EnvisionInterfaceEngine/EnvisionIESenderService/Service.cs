using System.ServiceProcess;
using System.Timers;
using EnvisionIESender;
using EnvisionInterfaceEngine.Common.Global;

namespace EnvisionIESenderService
{
    public class Service : ServiceBase
    {
        private Timer timer;

        public Service() { ServiceName = "EnvisionIESenderService"; }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 1000;
            timer.Start();
        }
        protected override void OnStop() { timer.Stop(); }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

			using (Sender service = new Sender())
				service.Invoke();

            timer.Interval = Config.TimeInterval;
            timer.Start();
        }
    }
}