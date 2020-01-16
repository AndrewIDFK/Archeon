using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Accessories
{
	// Token: 0x0200000B RID: 11
	[AutoloadEquip(EquipType.Shoes)]
	public class Everglades : ModItem
	{
		// Token: 0x06000043 RID: 67 RVA: 0x000040F9 File Offset: 0x000022F9
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Everglades");
			base.Tooltip.SetDefault("Become the master of movement!\nAll the effects of the accessories used to craft it.\nHas a greatly improved dash.");
		}

		// Token: 0x06000044 RID: 68 RVA: 0x0000411C File Offset: 0x0000231C
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 6, 75, 0);
			base.item.value = Item.sellPrice(0, 6, 75, 0);
			base.item.rare = 7;
			base.item.accessory = true;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004188 File Offset: 0x00002388
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 10);
			modRecipe.AddIngredient(984, 1); // Master Ninja Gear
			modRecipe.AddIngredient(1862, 1); // frostspark boots
			modRecipe.AddIngredient(159, 1); // Red Balloon
			modRecipe.AddIngredient(158, 1); // Horseshoe 
			modRecipe.AddIngredient(908, 1); // Lava Waders: walk on lava, water no fire block damage and 7 sec lava immunity.
			modRecipe.AddTile(114);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00004200 File Offset: 0x00002400
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
