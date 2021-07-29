using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	public class ArcherGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archer Gloves");
			Tooltip.SetDefault("Used by the Cultists to overtake the Dungeon\n25% increased ranged damage\n20% increased bow Speed\nGreatly increases arrow velocity");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 7, 35, 0);
			item.rare = 9;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicQuiver = true;
			player.archery = true;
			player.rangedDamage += 0.25f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("LunarFragments"), 20);
			modRecipe.AddIngredient(ItemID.MagicQuiver, 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
