using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000BF RID: 191
	public class ThaniteSword : ModItem
	{
		// Token: 0x06000370 RID: 880 RVA: 0x0001CDEA File Offset: 0x0001AFEA
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thanite Sword");
			base.Tooltip.SetDefault("Creates extreme explosions on impact");
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001CE0C File Offset: 0x0001B00C
		public override void SetDefaults()
		{
			base.item.damage = 60;
			base.item.melee = true;
			base.item.width = 50;
			base.item.height = 56;
			base.item.useTime = 10;
			base.item.useAnimation = 10;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 2, 30, 0);
			base.item.value = Item.sellPrice(0, 2, 30, 0);
			base.item.rare = 6;
			base.item.shootSpeed = 14f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.scale = 1.2f;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001CEF4 File Offset: 0x0001B0F4
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 2))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 179, 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 179, 0f, 0f, 0, default(Color), 1f);
				
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0001CFE8 File Offset: 0x0001B1E8
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(5) == 1)
			{
				Projectile.NewProjectile(target.position.X + 8f, target.position.Y + 18f, 0f, 0f, base.mod.ProjectileType("ThaniteExplosion"), damage / 2, 1f, Main.myPlayer, 0f, 1f);
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001D04C File Offset: 0x0001B24C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ThaniteBar"), 16);
			modRecipe.AddIngredient(521, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
