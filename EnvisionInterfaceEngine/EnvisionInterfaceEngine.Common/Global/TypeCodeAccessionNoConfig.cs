using System.Configuration;

namespace EnvisionInterfaceEngine.Common.Global
{
    public class TypeCodeAccessionNoConfig : ConfigurationSection
    {
        [ConfigurationProperty("TypeCodeAccessionNo")]
        public TypeCodeAccessionNoElementCollection Element { get { return (TypeCodeAccessionNoElementCollection)this["TypeCodeAccessionNo"]; } }
    }
    public class TypeCodeAccessionNoElementCollection : ConfigurationElementCollection
    {
        public TypeCodeAccessionNoElement this[int index]
        {
            get { return (TypeCodeAccessionNoElement)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);

                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement() { return new TypeCodeAccessionNoElement(); }
        protected override object GetElementKey(ConfigurationElement element) { return ((TypeCodeAccessionNoElement)element).TypeCode; }
    }
    public class TypeCodeAccessionNoElement : ConfigurationElement
    {
        [ConfigurationProperty("TypeCode", IsRequired = true)]
        public string TypeCode { get { return this["TypeCode"].ToString(); } }

        [ConfigurationProperty("ModalityUid")]
        public string ModalityUid { get { return this["ModalityUid"].ToString(); } }

        [ConfigurationProperty("ModalityTypeUid")]
        public string ModalityTypeUid { get { return this["ModalityTypeUid"].ToString(); } }
    }
}