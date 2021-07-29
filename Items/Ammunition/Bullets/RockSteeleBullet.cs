using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Ammunition.Bullets
{
	public class RockSteeleBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("RockSteele bullet");
			Tooltip.SetDefault("A bullet made from a powerful alloy\n20% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.rare = 4;
			item.shoot = base.mod.ProjectileType("RockSteeleBulletShot");
			item.shootSpeed = 18f;
			item.ammo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) > 0.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(97, 250);
			modRecipe.AddIngredient(mod.ItemType("RockSteeleBar"), 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 250);
			modRecipe.AddRecipe();
		}
	}
}
