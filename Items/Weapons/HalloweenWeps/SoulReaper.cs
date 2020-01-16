using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.HalloweenWeps
{
	public class SoulReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Soul Reaper");
			base.Tooltip.SetDefault("Consume a part of their soul \nHeals the player upon enemy hits \nUnleashes the soul of a foe upon enemy kills");
		}
		
		public override void SetDefaults()
		{
			base.item.damage = 70;
			base.item.melee = true;
			base.item.width = 54;
			base.item.height = 50;
			base.item.useTime = 18;
			base.item.useAnimation = 18;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 5, 50, 0);
			base.item.value = Item.sellPrice(0, 5, 50, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item24;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			
			item.scale = 1.2f;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 2))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("SoulReaperDust"), 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("SoulReaperDust"), 0f, 0f, 0, default(Color), 1f);
				
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (target.life <= 0)
			{
				for (int i = 0; i < 7; i++)
				{
					int num = Dust.NewDust(target.position, target.width, target.height, base.mod.DustType("SoulReaperDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 2.15f + (float)Main.rand.Next(-31, 31) * 0.0315f;
					
					
					int num3 = Dust.NewDust(target.position, target.width, target.height, base.mod.DustType("SoulReaperDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust3 = Main.dust[num3];
					dust3.velocity.X = dust3.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust3.velocity.Y = dust3.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust3.scale *= 2.35f + (float)Main.rand.Next(-31, 31) * 0.0325f;
				}
				
				for (int i = 0; i < 7; i++)
				{
					
					int num2 = Dust.NewDust(target.position, target.width, target.height, base.mod.DustType("SoulReaperDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust2 = Main.dust[num2];
					dust2.velocity.X = dust2.velocity.X + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust2.velocity.Y = dust2.velocity.Y + (float)Main.rand.Next(-50, 51) * 0.01f;
					dust2.scale *= 2.35f + (float)Main.rand.Next(-31, 31) * 0.0355f;
					
					
				}
				
				
				Projectile.NewProjectile(target.Center.X, target.Center.Y, target.velocity.X, target.velocity.Y - 12f, base.mod.ProjectileType("SoulReaperSoul"), base.item.damage * 2, base.item.knockBack, Main.myPlayer, 0f, 0f);
				
			}
			
			player.statLife += Main.rand.Next(6, 12);
			player.HealEffect(Main.rand.Next(6, 12), true);
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1729, 30); //Spooky Wood
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 15);  // Uhh.... Are you serious?
			modRecipe.AddIngredient(521, 5); // Soul of Night
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1729, 30); //Spooky Wood
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 15);  // Uhh.... Are you serious?
			modRecipe.AddIngredient(521, 5); // Soul of Night
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
