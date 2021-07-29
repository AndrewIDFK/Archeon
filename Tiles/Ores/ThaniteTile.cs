using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles.Ores
{
	public class ThaniteTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("ThaniteOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("Thanite Ore");
			AddMapEntry(new Color(142, 44, 130), modTranslation);
			this.minPick = 210;
			this.mineResist = 4.2f;
			this.dustType = 179;
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.295f;
			g = 0.045f;
			b = 0.147f;
		}
	}
}
