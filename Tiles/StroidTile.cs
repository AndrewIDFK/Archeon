using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles
{
	// Token: 0x020000D5 RID: 213
	public class StroidTile : ModTile
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x000241CC File Offset: 0x000223CC
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("StroidOre");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("Stroid Ore");
			base.AddMapEntry(new Color(170, 199, 265), modTranslation);
			this.minPick = 215;
			this.mineResist = 6.5f;
			this.dustType = base.mod.DustType("StroidWormDeathDust");
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00024294 File Offset: 0x00022494
		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00024297 File Offset: 0x00022497
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.27f;
			g = 0.359f;
			b = 0.565f;
		}
	}
}
