using System.Collections.Generic;
using System.Xml.Linq;
using XmlUtilities;

namespace Game
{
	public static class StringsManager
	{
		static Dictionary<string, string> m_strings;

		public static string GetString(string name)
		{
			string result = default(string);
			return !StringsManager.m_strings.TryGetValue(name, out result) ? "<Plchldr>" : result;
		}

		public static void LoadStrings()
		{
			m_strings = new Dictionary<string, string>();
			for (var i = ContentManager.ConbineXElements(ContentManager.Get<XElement>("Strings"), ModsManager.GetEntries(".str"), null, "Name", "Strings").Elements().GetEnumerator(); i.MoveNext();)
			{
				StringsManager.m_strings.Add(XmlUtils.GetAttributeValue<string>(i.Current, "Name"), i.Current.Value.Replace("\\n", "\n"));
			}
		}
	}
}