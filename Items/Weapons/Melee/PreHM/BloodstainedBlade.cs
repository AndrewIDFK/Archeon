using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.PreHM
{
	public class BloodstainedBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodstained Blade");
			Tooltip.SetDefault("Chance to release blood from enemies on hit");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 34;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 2, 20, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if(Main.rand.Next(2) == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					float xStuff = Main.rand.Next(-3, 3);
					float yStuff = Main.rand.Next(-3, -1);
					Projectile.NewProjectile(target.Center.X, target.position.Y - 4, xStuff, yStuff, mod.ProjectileType("BloodthirstBloodProj"), item.damage, item.knockBack / 5, Main.myPlayer, 0f, 0f);
				}
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 8))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 125, 0f, 0f, 0, default(Color), 1f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 16);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
