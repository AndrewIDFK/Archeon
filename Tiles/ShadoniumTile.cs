using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles
{
	// Token: 0x020000D4 RID: 212
	public class ShadoniumTile : ModTile
	{
		// Token: 0x060003F5 RID: 1013 RVA: 0x000240F4 File Offset: 0x000222F4
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = base.mod.ItemType("ShadoniumOre");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("Shadonium Ore");
			base.AddMapEntry(new Color(90, 25, 143), modTranslation);
			this.minPick = 65;
			this.mineResist = 2f;
			this.dustType = 179;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x000241A8 File Offset: 0x000223A8
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.14f;
			g = 0.07f;
			b = 0.343f;
		}
	}
}
