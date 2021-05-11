using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using System;

namespace EnvisionInterfaceEngine.Operational.HL7
{
    public class GenerateACK
    {
        public static string ConvertToHL7(HL7ACK hl7Ack)
        {
            string format = "MSH|^~\\&|||||{0}||ACK|{1}"
                            + Delimiter.StringSegmentTerminator
                            + "MSA|{2}|{1}|{3}"
                            + Delimiter.StringSegmentTerminator;

            return string.Format(format, DateTime.Now.ToString("yyyyMMddHHmmssffff"), hl7Ack.MSH.MESSAGE_CONTROL_ID, hl7Ack.MSA.ACKNOWLEDGMENT_CODE, hl7Ack.MSA.TEXT_MESSAGE);
        }

        public static HL7ACK ConvertToObject(string hl7Text)
        {
            string[] message = HL7Manager.splitSegmentTerminator(hl7Text);

            HL7ACK hl7_ack = new HL7ACK();

            foreach (string segment in message)
            {
                MIStringArray msgField = new MIStringArray(HL7Manager.splitFieldSeparator(segment));

                switch (msgField[0])
                {
                    case "MSH":
                        hl7_ack.MSH.MESSAGE_TYPE = msgField[8];
                        hl7_ack.MSH.MESSAGE_CONTROL_ID = msgField[9];
                        break;
                    case "MSA":
                        hl7_ack.MSA.ACKNOWLEDGMENT_CODE = msgField[1];
                        hl7_ack.MSA.TEXT_MESSAGE = msgField[3];
                        break;
                }
            }

            return hl7_ack;
        }
    }
}