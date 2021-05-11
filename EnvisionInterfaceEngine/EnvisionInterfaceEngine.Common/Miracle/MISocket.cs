using System;

namespace EnvisionInterfaceEngine.Common.Miracle
{
    public class MISocket
    {
        public static string StringStartMessage { get { return Convert.ToChar(0x0b).ToString(); } }
        public static string StringEndMessage { get { return Convert.ToChar(0x1c).ToString() + Convert.ToChar(0x0d).ToString(); } }
    }
}
