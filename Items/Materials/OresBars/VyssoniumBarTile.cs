using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace Archeon.Items.Materials.OresBars
{
	public class VyssoniumBarTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)Type] = true;
			Main.tileFrameImportant[(int)Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			this.drop = mod.ItemType("VyssoniumBar");
			this.minPick = 90;
			AddMapEntry(new Color(136, 32, 65));
		}
	}
}
