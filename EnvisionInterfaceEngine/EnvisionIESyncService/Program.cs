﻿using System.ServiceProcess;

namespace EnvisionIESyncService
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service()
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
