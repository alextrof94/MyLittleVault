using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLittleVaultJsonEditor
{
	public class MlvMenuItem
	{
		[JsonIgnore]
		public List<MlvMenuItem> ParentList;

		public string Name;
		public bool Enabled = true;
		public MlvMenuItemType Type;
		public string Value;
		public List<MlvMenuItem> Childs;

		public MlvMenuItem(string name, string value, MlvMenuItemType type, List<MlvMenuItem> parentList = null)
		{
			Name = name;
			Type = type;
			Value = value;
			Childs = new List<MlvMenuItem>();
			ParentList = parentList;
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
