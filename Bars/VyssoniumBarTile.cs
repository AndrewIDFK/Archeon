using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x0200001C RID: 28
	public class VyssoniumBarTile : ModTile
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00005450 File Offset: 0x00003650
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("VyssoniumBar");
			this.minPick = 90;
			base.AddMapEntry(new Color(136, 32, 65));
		}
	}
}
