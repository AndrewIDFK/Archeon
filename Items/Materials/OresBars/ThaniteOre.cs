using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials.OresBars
{
	public class ThaniteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thanite Ore");
			Tooltip.SetDefault("You keep thinking it's trying to tell you something");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 10;
			item.useAnimation = 15;
			item.rare = 5;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 20, 0);
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("ThaniteTile");
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
		}
	}
}
