using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles.Ores
{
	public class StroidTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("StroidOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("Stroid Ore");
			AddMapEntry(new Color(170, 199, 265), modTranslation);
			this.minPick = 215;
			this.mineResist = 6.5f;
			this.dustType = mod.DustType("StroidWormDeathDust");
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override bool CanExplode(int i, int j)
		{
			return false;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.27f;
			g = 0.359f;
			b = 0.565f;
		}
	}
}
