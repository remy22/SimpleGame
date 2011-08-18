﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame
{
	public static class StatParser
	{
		public static string XMLStats(int entityid, string stat, string statsfile)
		{
			System.IO.StringReader entitystats = new System.IO.StringReader(statsfile);
			System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(entitystats);
			string idtag = "id" + entityid.ToString();
			while (xmlReader.Read())
			{
				if (xmlReader.NodeType == System.Xml.XmlNodeType.Element && xmlReader.Name == idtag)
				{
					if (xmlReader.HasAttributes)
					{
						return xmlReader.GetAttribute(stat);
					}
				}
			}
			return "0";
		}
	}
}