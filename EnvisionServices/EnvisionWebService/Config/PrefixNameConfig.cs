using System.Configuration;

public class PrefixNameConfig : ConfigurationSection
{
	[ConfigurationProperty("PrefixName")]
	public PrefixNameElementCollection Element
	{
		get { return (PrefixNameElementCollection)this["PrefixName"]; }
	}
}
public class PrefixNameElementCollection : ConfigurationElementCollection
{
	public PrefixNameElement this[int index]
	{
		get
		{
			return (PrefixNameElement)base.BaseGet(index);
		}
		set
		{
			if (base.BaseGet(index) != null)
			{
				base.BaseRemoveAt(index);
			}
			this.BaseAdd(index, value);
		}
	}

	protected override ConfigurationElement CreateNewElement()
	{
		return new PrefixNameElement();
	}

	protected override object GetElementKey(ConfigurationElement element)
	{
		return ((PrefixNameElement)element).PrefixName;
	}
}
public class PrefixNameElement : ConfigurationElement
{
	[ConfigurationProperty("PrefixName", IsRequired = true)]
	public string PrefixName
	{
		get { return this["PrefixName"].ToString(); }
	}

	[ConfigurationProperty("PrefixNameEng", IsRequired = true)]
	public string PrefixNameEng
	{
		get { return this["PrefixNameEng"].ToString(); }
	}

	[ConfigurationProperty("Gender")]
	public string Gender
	{
		get { return this["Gender"].ToString(); }
	}
}