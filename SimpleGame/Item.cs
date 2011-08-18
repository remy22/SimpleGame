﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleGame
{
	[Serializable]
	public class Item : ISerializable
	{
		public enum ItemType { None, Weapon, Armour, Consumable }

		protected string name;
		protected int weight;
		protected int value;
		protected int id;
		protected System.Drawing.Image picture;
		protected ItemType type;

		public Item(int itemid)
		{
			this.id = itemid;
			this.name = ItemStats.GetStat(itemid, "name");
			this.weight = int.Parse(ItemStats.GetStat(itemid, "weight"));
			this.value = int.Parse(ItemStats.GetStat(itemid, "value"));
			this.type = this.setItemType(itemid);
		}

		protected ItemType setItemType(int itemid)
		{
			switch (ItemStats.GetStat(itemid, "type"))
			{
				case "weapon":
					return ItemType.Weapon;
				case "armour":
					return ItemType.Armour;
				case "consumable":
					return ItemType.Consumable;
				default:
					return ItemType.None;
			}
		}

		virtual public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("id", this.id);
			info.AddValue("name", this.name);
			info.AddValue("value", this.value);
			info.AddValue("weight", this.weight);
			info.AddValue("type", this.type);
			info.AddValue("picture", this.picture);
		}

		public Item()
		{
		}

		public int ID
		{
			get { return id; }
		}

		public string UsageVerb
		{
			get
			{
				switch (this.type)
				{
					case Item.ItemType.Weapon:
						return "wield";
					case Item.ItemType.Armour:
						return "wear";
					default:
						return "use";
				}
			}
		}

		public virtual string Name
		{
			get { return name; }
		}

		public int Weight
		{
			get { return weight; }
		}
		
		public int Value
		{
			get { return value; }
		}

		public ItemType Type
		{
			get { return type; }
		}

		public System.Drawing.Image Picture
		{
			get { return picture; }
		}
	}
}