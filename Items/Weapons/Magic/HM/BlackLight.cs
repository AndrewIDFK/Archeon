using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.HM
{
	public class BlackLight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blackout");
			Tooltip.SetDefault("Creates a consuming abyss");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2f;
			item.value = Item.buyPrice(0, 2, 10, 0);
			item.rare = 6;
			item.mana = 15;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BlackLightProj");
			item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 12);
			modRecipe.AddIngredient(531, 1);
			modRecipe.AddIngredient(173, 6);
			modRecipe.AddTile(101);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 12);
			modRecipe.AddIngredient(531, 1);
			modRecipe.AddIngredient(173, 6);
			modRecipe.AddTile(101);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
