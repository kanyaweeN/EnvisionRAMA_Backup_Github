namespace EnvisionInterfaceEngine.Common.HL7.Segment
{
    public class MSA
    {
        public MSA()
        {
            ACKNOWLEDGMENT_CODE = "AE";
            TEXT_MESSAGE = "Message Error";
        }

        public string ACKNOWLEDGMENT_CODE { get; set; }
        public string MESSAGE_CONTROL_ID { get; set; }
        public string TEXT_MESSAGE { get; set; }
    }
}
