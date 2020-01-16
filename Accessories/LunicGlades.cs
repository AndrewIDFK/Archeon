using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Accessories
{
	// Token: 0x0200000E RID: 14
	[AutoloadEquip(EquipType.Shoes)]
	public class LunicGlades : ModItem
	{
		// Token: 0x06000052 RID: 82 RVA: 0x000045D9 File Offset: 0x000027D9
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunic Glades");
			base.Tooltip.SetDefault("You are a [c/D81010:God] of Movement!\nExtrodinary movement speed and acceleration\nAll the effects of the Everglades");
			Main.RegisterItemAnimation(base.item.type, new DrawAnimationVertical(5, 9));
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004614 File Offset: 0x00002814
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 16;
			base.item.value = Item.buyPrice(0, 28, 75, 0);
			base.item.value = Item.sellPrice(0, 28, 75, 0);
			base.item.rare = 9;
			base.item.accessory = true;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004680 File Offset: 0x00002880
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("Everglades"), 1);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 12);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000046E4 File Offset: 0x000028E4
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
