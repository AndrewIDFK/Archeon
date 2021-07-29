using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class CrimtaneNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Necklace");
			Tooltip.SetDefault("It glows when in contact with evil\nIncreased damage and melee speed while in the Crimson");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 1, 75, 0);
			item.rare = 3;
			item.accessory = true;
		}

		public override void AddRecipes()		
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 10);
			modRecipe.AddIngredient(1329, 5);
			modRecipe.AddTile(26);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneCrimson)
			{
				player.meleeDamage += 0.15f;
				player.meleeSpeed += 0.2f;
				Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.54f, 0.02f, 0.07f);
			}
		}
	}
}
