using System.Configuration;
using System;

namespace EnvisionInterfaceEngine.Common.Global
{
    public class BidirectionalNewOrderConfig : ConfigurationSection
    {
        [ConfigurationProperty("BidirectionalNewOrder")]
        public BidirectionalNewOrderElementCollection Element { get { return (BidirectionalNewOrderElementCollection)this["BidirectionalNewOrder"]; } }
    }
    public class BidirectionalNewOrderElementCollection : ConfigurationElementCollection
    {
        public BidirectionalNewOrderElement this[int index]
        {
            get { return (BidirectionalNewOrderElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);

                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement() { return new BidirectionalNewOrderElement(); }
        protected override object GetElementKey(ConfigurationElement element) { return ((BidirectionalNewOrderElement)element).AETitleId; }
    }
    public class BidirectionalNewOrderElement : ConfigurationElement
    {
        [ConfigurationProperty("AETitleId", IsKey = true, IsRequired = true)]
        public int AETitleId { get { return Convert.ToInt32(this["AETitleId"]); } }

        [ConfigurationProperty("ReferenceUnitId", DefaultValue = 0)]
        public int ReferenceUnitId { get { return Convert.ToInt32(this["ReferenceUnitId"]); } }

        [ConfigurationProperty("IsAllowed", IsRequired = true)]
        public bool IsAllowed { get { return Convert.ToBoolean(this["IsAllowed"]); } }
    }
}