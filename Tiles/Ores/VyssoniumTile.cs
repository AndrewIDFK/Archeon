using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Tiles.Ores
{
	public class VyssoniumTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileMergeDirt[(int)Type] = true;
			Main.tileLighted[(int)Type] = true;
			Main.tileBlockLight[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("VyssoniumOre");
			ModTranslation modTranslation = CreateMapEntryName(null);
			modTranslation.SetDefault("Vyssonium Ore");
			AddMapEntry(new Color(126, 14, 23), modTranslation);
			this.minPick = 65;
			this.mineResist = 2f;
			this.dustType = 90;
			this.soundType = 21;
			Main.tileSpelunker[(int)Type] = true;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.278f;
			g = 0.039f;
			b = 0.033f;
		}
	}
}
