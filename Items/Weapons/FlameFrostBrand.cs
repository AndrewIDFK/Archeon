using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000097 RID: 151
	public class FlameFrostBrand : ModItem
	{
		// Token: 0x060002AB RID: 683 RVA: 0x00017C08 File Offset: 0x00015E08
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flamefrostbrand");
			base.Tooltip.SetDefault("Shoots 2 Freezing Fiery bolts");
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00017C2C File Offset: 0x00015E2C
		public override void SetDefaults()
		{
			base.item.damage = 85;
			base.item.melee = true;
			base.item.width = 46;
			base.item.height = 50;
			base.item.useTime = 23;
			base.item.useAnimation = 18;
			base.item.useStyle = 1;
			base.item.knockBack = 5.5f;
			base.item.value = Item.buyPrice(0, 4, 20, 0);
			base.item.value = Item.sellPrice(0, 4, 20, 0);
			base.item.rare = 6;
			base.item.shootSpeed = 12f;
			base.item.shoot = base.mod.ProjectileType("FlameFrostBrandFireShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.scale = 1.2f;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00017D2F File Offset: 0x00015F2F
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 480, false);
			target.AddBuff(44, 480, false);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00017D40 File Offset: 0x00015F40
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 4))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("FlameFrostBrandFrostDust"), 0f, 0f, 0, default(Color), 1f);
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("FlameFrostBrandFireDust"), 0f, 0f, 0, default(Color), 1f);
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{	
			float numberProjectiles = 1; // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(3f);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles))) * .4f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 2.25f, perturbedSpeed.Y * 1.85f, base.mod.ProjectileType("FlameFrostBrandFireShot"), damage, knockBack, player.whoAmI);
			}
			
			float numberProjectiles2 = 1; // 3, 4, or 5 shots
			float rotation2 = MathHelper.ToRadians(5f);
			for (int i = 0; i < numberProjectiles2; i++)
			{
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles2))) * .5f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X * 2.05f, perturbedSpeed2.Y * 2.05f, base.mod.ProjectileType("FlameFrostBrandFrostShot"), damage, knockBack, player.whoAmI);
			}
			return false;
		}
		

		// Token: 0x060002AF RID: 687 RVA: 0x00017DA0 File Offset: 0x00015FA0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("Flamebrand"), 1);
			modRecipe.AddIngredient(676);
			modRecipe.AddIngredient(base.mod.ItemType("FireElement"), 5);
			modRecipe.AddIngredient(base.mod.ItemType("FrostElement"), 5);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
