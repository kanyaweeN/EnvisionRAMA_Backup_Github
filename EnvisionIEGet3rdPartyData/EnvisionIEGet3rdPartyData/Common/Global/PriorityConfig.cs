using System;
using System.Configuration;

namespace EnvisionIEGet3rdPartyData.Common.Global
{
    public class PriorityConfig : ConfigurationSection
    {
        [ConfigurationProperty("Priorities")]
        public PrioritiesElementCollection Element { get { return (PrioritiesElementCollection)this["Priorities"]; } }
    }
    public class PrioritiesElementCollection : ConfigurationElementCollection
    {
        public PriorityElement this[int index]
        {
            get { return (PriorityElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement() { return new PriorityElement(); }

        protected override object GetElementKey(ConfigurationElement element) { return ((PriorityElement)element).PriorityUid; }
    }
    public class PriorityElement : ConfigurationElement
    {
        [ConfigurationProperty("PriorityUid", IsKey = true, IsRequired = true)]
        public string PriorityUid { get { return this["PriorityUid"].ToString(); } }

        [ConfigurationProperty("PriorityStatus", IsRequired = true)]
        public char PriorityStatus { get { return Convert.ToChar(this["PriorityStatus"]); } }
    }
}