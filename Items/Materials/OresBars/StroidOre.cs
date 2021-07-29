using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Materials.OresBars
{

	public class StroidOre : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stroid Ore");
			Tooltip.SetDefault("Superb material from another world");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.useTime = 10;
			item.useAnimation = 15;
			item.rare = 6;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("StroidTile");
			item.maxStack = 999;
			item.UseSound = SoundID.Item1;
		}
	}
}
