using System;

namespace EnvisionInterfaceEngine.Common.HL7
{
	public class Delimiter
	{
		public static string StringSegmentTerminator { get { return Convert.ToChar(0x0d).ToString(); } }
		public static string StringFieldSeparate { get { return "|"; } }
		public static string StringComponentSeparate { get { return "^"; } }
        public static string StringSubcomponentSeparate { get { return " "; } }
        public static string StringRepetitionSeparate { get { return " "; } }
        public static string StringEscapeCharacter { get { return " "; } }
	}
}