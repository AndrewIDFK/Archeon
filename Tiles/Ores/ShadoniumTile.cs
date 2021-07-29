using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles.Ores
{
	public class ShadoniumTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("ShadoniumOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("Shadonium Ore");
			AddMapEntry(new Color(90, 25, 143), modTranslation);
			this.minPick = 65;
			this.mineResist = 2f;
			this.dustType = 179;
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.14f;
			g = 0.07f;
			b = 0.343f;
		}
	}
}
