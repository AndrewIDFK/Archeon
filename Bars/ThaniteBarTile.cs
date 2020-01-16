using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x0200001A RID: 26
	public class ThaniteBarTile : ModTile
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00005238 File Offset: 0x00003438
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("ThaniteBar");
			this.minPick = 192;
			base.AddMapEntry(new Color(140, 55, 120));
		}
	}
}
