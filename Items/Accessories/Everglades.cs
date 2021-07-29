using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class Everglades : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Everglades");
			Tooltip.SetDefault("Become the master of movement!\nAll the effects of the accessories used to craft it\nHas a greatly improved dash");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 6, 75, 0);
			item.rare = 7;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 10);
			modRecipe.AddIngredient(984, 1); // Master Ninja Gear
			modRecipe.AddIngredient(1862, 1); // frostspark boots
			modRecipe.AddIngredient(159, 1); // Red Balloon
			modRecipe.AddIngredient(158, 1); // Horseshoe 
			modRecipe.AddIngredient(908, 1); // Lava Waders: walk on lava and water, \ no fire block damage and 7 second lava immunity.
			modRecipe.AddTile(114);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{	
			//Master Ninja Gear
			player.blackBelt = true;
			player.spikedBoots = 2;
			// EverGlades Dash
			player.GetModPlayer<MyPlayer>().dashMod = 4;
			//frostSpark Boots
			player.accRunSpeed = 9.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.45f;
			player.iceSkate = true;
			//Red Balloon
			player.jumpBoost = true;
			//HorseShoe
			player.noFallDmg = true;
			// Lava Waders
			player.lavaMax += 420;
			player.waterWalk = true;
			player.fireWalk = true;
			//Flight
			player.wingTimeMax = 55;
		}
	}
}
