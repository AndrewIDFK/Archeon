using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000098 RID: 152
	public class ShroomShark : ModItem
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x00017E5A File Offset: 0x0001605A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Shroomshark");
			base.Tooltip.SetDefault("Shoot 2 Shroomite bullets at a time\nRight-click for a flamethrower\n35% chance to not consume ammo and gel");
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00017E7C File Offset: 0x0001607C
		public override void SetDefaults()
		{
			base.item.damage = 30;
			base.item.crit = 3;
			base.item.ranged = true;
			base.item.width = 18;
			base.item.height = 18;
			base.item.useTime = 8;
			base.item.useAnimation = 8;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.6f;
			base.item.value = Item.buyPrice(0, 6, 50, 0);
			base.item.value = Item.sellPrice(0, 6, 50, 0);
			base.item.rare = 9;
			base.item.UseSound = SoundID.Item40;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 20f;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x000173E4 File Offset: 0x000155E4
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				base.item.damage = 64;
				base.item.ranged = true;
				base.item.useTime = 4;
				base.item.useAnimation = 12;
				base.item.useStyle = 5;
				base.item.noMelee = true;
				base.item.knockBack = 1.2f;
				base.item.UseSound = SoundID.Item34;
				base.item.autoReuse = true;
				base.item.shootSpeed = 8.5f;
				base.item.shoot = base.mod.ProjectileType("ShroomSharkFlame");
				base.item.useAmmo = 23;
			}
			else
			{
				base.item.damage = 32;
				base.item.crit = 4;
				base.item.ranged = true;
				base.item.useTime = 8;
				base.item.useAnimation = 8;
				base.item.useStyle = 5;
				base.item.noMelee = true;
				base.item.knockBack = 0.75f;
				base.item.UseSound = SoundID.Item40;
				base.item.autoReuse = true;
				base.item.shootSpeed = 20f;
				base.item.useAmmo = AmmoID.Bullet;
				base.item.shoot = base.mod.ProjectileType("ShroomiteBulletShot");
			}
			return base.CanUseItem(player);
		}

		

		// Token: 0x060002B3 RID: 691 RVA: 0x00017F8C File Offset: 0x0001618C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("FlamingShark"), 1);
			modRecipe.AddIngredient(1552, 15);
			modRecipe.AddTile(247);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00017FE1 File Offset: 0x000161E1
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.35f;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00017FF7 File Offset: 0x000161F7
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-12f, -3f));
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00018010 File Offset: 0x00016210
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				int num2 = 1;
				for (int i = 0; i < num2; i++)
				{
					Vector2 value11 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(2.5f));
					float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.45f;
					value11 *= scaleFactor;
					Projectile.NewProjectile(position.X, position.Y, value11.X, value11.Y, base.mod.ProjectileType("ShroomSharkFlame"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			else
			{
				Vector2 value1 = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
				if (Collision.CanHit(position, 0, 0, position + value1, 0, 0))
				{
					position += value1;
				}
				int num = 2;
				for (int i = 0; i < num; i++)
				{
					Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(8.5f));
					float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.45f;
					value *= scaleFactor;
					Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, base.mod.ProjectileType("ShroomiteBulletShot"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}		
			return false;
		}
	}
}
