using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles
{
	// Token: 0x020000D3 RID: 211
	public class RockSteeleTile : ModTile
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x0002401C File Offset: 0x0002221C
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("RockSteeleOre");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("RockSteele Ore");
			base.AddMapEntry(new Color(30, 116, 255), modTranslation);
			this.minPick = 180;
			this.mineResist = 2.5f;
			this.dustType = 88;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000240D0 File Offset: 0x000222D0
		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x000240D3 File Offset: 0x000222D3
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.034f;
			g = 0.126f;
			b = 0.225f;
		}
	}
}
