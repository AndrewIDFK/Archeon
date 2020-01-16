using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles
{
	// Token: 0x020000D2 RID: 210
	public class PlasmiteTile : ModTile
	{
		// Token: 0x060003ED RID: 1005 RVA: 0x00023F40 File Offset: 0x00022140
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("PlasmiteOre");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("Plasmite Ore");
			base.AddMapEntry(new Color(183, 10, 112), modTranslation);
			this.minPick = 215;
			this.mineResist = 7.5f;
			this.dustType = 179;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00023FF7 File Offset: 0x000221F7
		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00023FFA File Offset: 0x000221FA
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.236f;
			g = 0.054f;
			b = 0.223f;
		}
	}
}
