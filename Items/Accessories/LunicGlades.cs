using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class LunicGlades : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunic Glades");
			Tooltip.SetDefault("You are a [c/D81010:God] of Movement!\nExtraordinary movement speed and acceleration\nAll the effects of the Everglades");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 9));
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 16;
			item.value = Item.buyPrice(0, 28, 75, 0);
			item.rare = 9;
			item.accessory = true;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("Everglades"), 1);
			modRecipe.AddIngredient(mod.ItemType("LunarFragment"), 16);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//Master Ninja Gear
			player.blackBelt = true;
			player.spikedBoots = 2;
			// EverGlades Dash
			player.GetModPlayer<MyPlayer>().dashMod = 3;
			//frostSpark Boots
			player.accRunSpeed = 12.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.85f;
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
			player.wingTimeMax = 125;
		}
	}
}
