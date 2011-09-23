﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleGame
{
	public partial class InventoryEntry : UserControl
	{

		private Logic.Item item;
		
		public InventoryEntry()
		{
			InitializeComponent();
			this.itemIcon.Click += new EventHandler(this.clicked);
			this.itemNameLabel.Click += new EventHandler(this.clicked);
		}

		public void UpdateEntry()
		{
			if (item != null)
			{
				this.itemNameLabel.Text = item.Name;
				this.itemIcon.Image = Art.GetItemImage(item.ID);
			}
			else
			{
				this.itemNameLabel.Text = null;
				this.itemIcon.Image = null;
			}
		}

		private void clicked(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		public void Highlight()
		{
			this.itemIcon.BackColor = Color.FromArgb(229, 244, 255);
			this.itemNameLabel.BackColor = Color.FromArgb(229, 244, 255);
		}
		public void UnHighlight()
		{
			this.itemIcon.BackColor = SystemColors.Control;
			this.itemNameLabel.BackColor = SystemColors.Control;
		}

		public Logic.Item Item
		{
			get { return item; }
			set
			{
				item = value;
				UpdateEntry();
			}
		}
	}
}