using System.Collections.Generic;

namespace Envision.Operational.Scanner
{
    public class ScannerDevice
    {
        public ScannerDevice() { Items = new List<ScannerItem>(); }

        public string DeviceId { get; set; }
        public string Name { get; set; }

        public List<ScannerItem> Items { get; set; }
    }

    public class ScannerItem
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public bool IsReadOnly { get; set; }
        public ScannerItemSubType SubType { get; set; }
        public int SubTypeDefault { get; set; }
        public int SubTypeMax { get; set; }
        public int SubTypeMin { get; set; }
        public int SubTypeStep { get; set; }
        public List<int> SubTypeValues { get; set; }
    }

    public enum ScannerItemSubType
    {
        Unspecified = 0,
        Range = 1,
        List = 2,
        Flag = 3
    }
}