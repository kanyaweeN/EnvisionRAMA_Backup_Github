using EnvisionInterfaceEngine.Common.HL7.Segment;

namespace EnvisionInterfaceEngine.Common.HL7
{
    public class HL7ACK
    {
        public HL7ACK()
        {
            MSH = new MSH();
            MSA = new MSA();
        }

        public MSH MSH { get; set; }
        public MSA MSA { get; set; }
    }
}