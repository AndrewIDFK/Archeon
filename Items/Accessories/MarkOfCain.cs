using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class MarkOfCain : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mark of Cain");
			Tooltip.SetDefault("A seal of the first killer that corrupts the vessel\nIncreases melee prowess when fighting, but damages you while not fighting");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.MarkOfCain = true;
		}
	}
}
