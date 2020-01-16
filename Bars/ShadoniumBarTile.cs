using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x02000016 RID: 22
	public class ShadoniumBarTile : ModTile
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00004ED0 File Offset: 0x000030D0
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("ShadoniumBar");
			this.minPick = 90;
			base.AddMapEntry(new Color(95, 20, 185));
		}
	}
}
