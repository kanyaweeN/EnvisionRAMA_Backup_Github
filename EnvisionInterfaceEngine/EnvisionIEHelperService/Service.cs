using System.ServiceProcess;
using System.Timers;
using EnvisionIEHelper;
using EnvisionInterfaceEngine.Common.Global;

namespace EnvisionIEHelperService
{
    public class Service : ServiceBase
    {
        private Timer timer;

        public Service() { ServiceName = "EnvisionIEHelperService"; }

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

			using (Helper service = new Helper())
				service.Invoke();

            timer.Interval = Config.TimeInterval;
            timer.Start();
        }
    }
}
