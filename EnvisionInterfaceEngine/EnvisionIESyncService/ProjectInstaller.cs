using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace EnvisionIESyncService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            ServiceProcessInstaller prc = new ServiceProcessInstaller();
            prc.Account = ServiceAccount.LocalSystem;
            prc.Password = null;
            prc.Username = null;

            ServiceInstaller svc = new ServiceInstaller();
            svc.ServiceName = "EnvisionIESyncService";
            svc.DisplayName = "EnvisionIESyncService";
            svc.Description = "";
			svc.StartType = ServiceStartMode.Automatic;
			svc.DelayedAutoStart = true;

            Installers.Add(prc);
            Installers.Add(svc);
        }
    }
}
