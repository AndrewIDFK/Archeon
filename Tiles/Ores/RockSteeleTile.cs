using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles.Ores
{
	public class RockSteeleTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("RockSteeleOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("RockSteele Ore");
			AddMapEntry(new Color(30, 116, 255), modTranslation);
			this.minPick = 180;
			this.mineResist = 2.5f;
			this.dustType = 88;
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.034f;
			g = 0.126f;
			b = 0.225f;
		}
	}
}
