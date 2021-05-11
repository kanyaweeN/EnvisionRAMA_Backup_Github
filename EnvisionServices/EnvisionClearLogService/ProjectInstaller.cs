using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace EnvisionClearLogService
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
			svc.ServiceName = "EnvisionClearLogService";
			svc.DisplayName = "EnvisionClearLogService";
            svc.Description = "";
			svc.StartType = ServiceStartMode.Automatic;

            Installers.Add(prc);
            Installers.Add(svc);
        }
    }
}
