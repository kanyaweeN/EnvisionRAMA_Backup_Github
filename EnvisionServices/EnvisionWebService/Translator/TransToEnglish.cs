using System;
using System.Web.Services;
using myTTranslite_TypeLib;

public class TransToEnglish
{
	public static string Trans(string thaiText)
	{
		return new TransToEnglishLocal().Trans(thaiText);
	}
}
public class TransToEnglishLocal : WebService
{
	private TTransliteCtrlClass cls_translate;

	public TransToEnglishLocal()
	{
		if (Application["TransToEnglish"] == null)
		{
			cls_translate = new TTransliteCtrlClass();
			cls_translate.Initial(ConfigService.ThaiRomanPath);

			Application.Lock();
			Application["TransToEnglish"] = cls_translate;
			Application.UnLock();
		}
		else
		{
			cls_translate = (TTransliteCtrlClass)Application["TransToEnglish"];
		}
	}

	public string Trans(string thaiText)
	{
		string result = string.Empty;

		if (cls_translate != null && thaiText != null && thaiText.Trim() != string.Empty)
		{
			try
			{
				result = cls_translate.Roman(thaiText, "else", "word");
				result = result.Remove(result.IndexOf(Convert.ToChar(63688))).Trim();

				if (result.Length > 0)
				{
					result = result.Substring(0, 1).ToUpper() + result.Substring(1);
				}
			}
			catch { }
		}

		return result;
	}
}