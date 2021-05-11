using System.Configuration;

namespace EnvisionInterfaceEngine.Common.Global
{
    public class FacilityConfig : ConfigurationSection
    {
        [ConfigurationProperty("Facility")]
        public FacilityElementCollection Element { get { return (FacilityElementCollection)this["Facility"]; } }
    }
    public class FacilityElementCollection : ConfigurationElementCollection
    {
        public FacilityElement this[int index]
        {
            get { return (FacilityElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);

                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement() { return new FacilityElement(); }
        protected override object GetElementKey(ConfigurationElement element) { return ((FacilityElement)element).FacilityName; }
    }
    public class FacilityElement : ConfigurationElement
    {
        [ConfigurationProperty("FacilityName", IsRequired = true)]
        public string FacilityName { get { return this["FacilityName"].ToString(); } }

        [ConfigurationProperty("UnitUid")]
        public string UnitUid { get { return this["UnitUid"].ToString(); } }
    }
}