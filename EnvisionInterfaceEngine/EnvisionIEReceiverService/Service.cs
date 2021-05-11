using System.ServiceProcess;
using System.Timers;
using EnvisionIEReceiver;
using EnvisionInterfaceEngine.Common.Global;

namespace EnvisionIEReceiverService
{
    public class Service : ServiceBase
    {
        private Timer timer;

        public Service() { ServiceName = "EnvisionIEReceiverService"; }

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

			using (Receiver service = new Receiver())
				service.Invoke();

            timer.Interval = Config.TimeInterval;
            timer.Start();
        }
    }
}
