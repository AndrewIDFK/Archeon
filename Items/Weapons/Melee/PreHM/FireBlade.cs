using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class FireBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Blade");
			Tooltip.SetDefault("Shoots a fiery bolt");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 34;
			item.height = 40;
			item.useTime = 38;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 4.75f;
			item.value = Item.buyPrice(0, 0, 65, 0);
			item.rare = 4;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("FireBladeProj");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 380, false);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 5))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 0, default(Color), 1f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(173, 5);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 12);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.IceBlock, 15);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 12);
			modRecipe.AddTile(16);
			modRecipe.SetResult(724, 1); // Ice Blade
			modRecipe.AddRecipe();
		}
	}
}
