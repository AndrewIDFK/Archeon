using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Bullets
{
	public class BlazingBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing bullet");
			Tooltip.SetDefault("The bullet burns the enemies\n5% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = Item.buyPrice(0, 0, 2, 50);
			item.rare = 2;
			item.shoot = base.mod.ProjectileType("BlazingBulletShot");
			item.shootSpeed = 22f;
			item.ammo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) > 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(97, 150);
			modRecipe.AddIngredient(175, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 150);
			modRecipe.AddRecipe();
		}
	}
}
