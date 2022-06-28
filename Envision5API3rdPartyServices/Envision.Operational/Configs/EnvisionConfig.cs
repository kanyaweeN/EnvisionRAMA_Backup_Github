using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Operational.Configs
{
    public class EnvisionConfig
    {
        public static string ConnectionString { get; set; } = string.Empty;
        public static string ConnectionStringDw { get; set; } = string.Empty;
        public static bool KeepLog { get; set; }
        public static string KeepLogPath { get; set; } = string.Empty;
        public static string NLS { get; set; } = string.Empty;
        public static int TimeInterval { get; set; }
    }
}
