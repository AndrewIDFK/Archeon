using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x02000012 RID: 18
	public class PlasmiteBarTile : ModTile
	{
		// Token: 0x06000065 RID: 101 RVA: 0x00004B10 File Offset: 0x00002D10
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("PlasmiteBar");
			this.minPick = 210;
			base.AddMapEntry(new Color(76, 36, 76));
		}
	}
}
