using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles
{
	// Token: 0x020000D6 RID: 214
	public class ThaniteTile : ModTile
	{
		// Token: 0x060003FC RID: 1020 RVA: 0x000242B8 File Offset: 0x000224B8
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("ThaniteOre");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("Thanite Ore");
			base.AddMapEntry(new Color(142, 44, 130), modTranslation);
			this.minPick = 210;
			this.mineResist = 4.2f;
			this.dustType = 179;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00024372 File Offset: 0x00022572
		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00024375 File Offset: 0x00022575
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.295f;
			g = 0.045f;
			b = 0.147f;
		}
	}
}
