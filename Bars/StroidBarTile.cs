using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x02000018 RID: 24
	public class StroidBarTile : ModTile
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00005080 File Offset: 0x00003280
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("StroidBar");
			this.minPick = 160;
			base.AddMapEntry(new Color(140, 199, 245));
		}
	}
}
