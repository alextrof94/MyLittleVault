using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleVault
{
	public class MlvMenuItem
	{
		public string Name;
		public bool Enabled = true;
		public MlvMenuItemType Type;
		public string Value;
		public List<MlvMenuItem> Childs;

		public MlvMenuItem(string name, string value, MlvMenuItemType type)
		{
			Name = name;
			Type = type;
			if (Type == MlvMenuItemType.Folder)
				Childs = new List<MlvMenuItem>();
			else
				Value = value;
		}
	}

	public class MlvMenuItemRoot
	{
		public List<MlvMenuItem> RootItems = new List<MlvMenuItem>();
	}

	public enum MlvMenuItemType
	{
		Text, Hidden, Folder
	}
}
