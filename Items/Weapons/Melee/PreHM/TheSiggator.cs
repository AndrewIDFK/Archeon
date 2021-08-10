using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class TheSiggator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Siggator");
			Tooltip.SetDefault("A yoyo from beyond the fourth wall");
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.useTime = 15;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.channel = true;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 0, 45, 0);
			item.rare = 3;
			item.shoot = mod.ProjectileType("SiggatorProj");
			item.noUseGraphic = true;
			item.noMelee = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.WoodYoyo, 1);
			modRecipe.AddIngredient(ItemID.IceBlock, 15);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 5);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
