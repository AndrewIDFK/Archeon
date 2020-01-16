using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000096 RID: 150
	public class FireBlade : ModItem
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x000179E2 File Offset: 0x00015BE2
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fire Blade");
			base.Tooltip.SetDefault("Shoots a Fiery bolt");
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00017A04 File Offset: 0x00015C04
		public override void SetDefaults()
		{
			base.item.damage = 32;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 40;
			base.item.useTime = 41;
			base.item.useAnimation = 19;
			base.item.useStyle = 1;
			base.item.knockBack = 5.75f;
			base.item.value = Item.buyPrice(0, 0, 65, 0);
			base.item.value = Item.sellPrice(0, 0, 65, 0);
			base.item.rare = 4;
			base.item.shootSpeed = 12f;
			base.item.shoot = base.mod.ProjectileType("FireBladeShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.scale = 1.15f;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00017B07 File Offset: 0x00015D07
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 380, false);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00017B18 File Offset: 0x00015D18
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 5))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00017B78 File Offset: 0x00015D78
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(173, 5);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 12);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(664, 15);
			modRecipe.AddRecipeGroup("GoldOrPlatinumBar", 12);
			modRecipe.AddTile(16);
			modRecipe.SetResult(724, 1); // Ice Blade
			modRecipe.AddRecipe();
		}
	}
}
