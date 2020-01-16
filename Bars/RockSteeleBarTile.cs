using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Bars
{
	// Token: 0x02000014 RID: 20
	public class RockSteeleBarTile : ModTile
	{
		// Token: 0x0600006B RID: 107 RVA: 0x00004CBC File Offset: 0x00002EBC
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("RockSteeleBar");
			this.minPick = 179;
			base.AddMapEntry(new Color(37, 115, 117));
		}
	}
}
