using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Armor.Feral
{
	[AutoloadEquip(EquipType.Body)]
	public class FeralChestplate : ModItem
	{

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Feral Chestplate");
			Tooltip.SetDefault("Increases minion damage by 20% and your max amount of minions by 2");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.rare = 7;
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.2f;
			player.maxMinions++;
			player.maxMinions++;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("FeralShard"), 12);
			modRecipe.AddIngredient(1006, 16); //Chloro Bar
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
