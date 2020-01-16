using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000098 RID: 152
	public class FlamingShark : ModItem
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x00017E5A File Offset: 0x0001605A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Magmashark");
			base.Tooltip.SetDefault("Shoots 2 blazing bullets at a time\nRight-click for a flamethrower\n25% chance to not consume ammo and gel");
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00017E7C File Offset: 0x0001607C
		public override void SetDefaults()
		{
			base.item.damage = 24;
			base.item.crit = 1;
			base.item.ranged = true;
			base.item.width = 18;
			base.item.height = 18;
			base.item.useTime = 9;
			base.item.useAnimation = 9;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 0.6f;
			base.item.value = Item.buyPrice(0, 3, 30, 0);
			base.item.value = Item.sellPrice(0, 3, 30, 0);
			base.item.rare = 7;
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
				base.item.damage = 45;
				base.item.ranged = true;
				base.item.useTime = 7;
				base.item.useAnimation = 21;
				base.item.useStyle = 5;
				base.item.noMelee = true;
				base.item.knockBack = 1.1f;
				base.item.UseSound = SoundID.Item34;
				base.item.autoReuse = true;
				base.item.shootSpeed = 8.5f;
				base.item.shoot = base.mod.ProjectileType("FlamingSharkFlame");
				base.item.useAmmo = 23;
			}
			else
			{
				base.item.damage = 21;
				base.item.crit = 1;
				base.item.ranged = true;
				base.item.useTime = 9;
				base.item.useAnimation = 9;
				base.item.useStyle = 5;
				base.item.noMelee = true;
				base.item.knockBack = 0.6f;
				base.item.UseSound = SoundID.Item40;
				base.item.autoReuse = true;
				base.item.shootSpeed = 20f;
				base.item.useAmmo = AmmoID.Bullet;
				base.item.shoot = base.mod.ProjectileType("BlazingBulletShot");
			}
			return base.CanUseItem(player);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x000174D8 File Offset: 0x000156D8
		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 2f, speedY * 2f, base.mod.ProjectileType("DeepSeaGlaivePearl"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return true;
		}*/

		// Token: 0x060002B3 RID: 691 RVA: 0x00017F8C File Offset: 0x0001618C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LavaPump"), 1);
			modRecipe.AddIngredient(533, 1);
			modRecipe.AddIngredient(506, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00017FE1 File Offset: 0x000161E1
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) >= 0.25f;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00017FF7 File Offset: 0x000161F7
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-10f, -2f));
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00018010 File Offset: 0x00016210
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
			{
				int num2 = 1;
				for (int i = 0; i < num2; i++)
				{
					Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(3.5f));
					float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.3f;
					value *= scaleFactor;
					Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, base.mod.ProjectileType("FlamingSharkFlame"), damage, knockBack, player.whoAmI, 0f, 0f);
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
					Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(11f));
					float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.3f;
					value *= scaleFactor;
					Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, base.mod.ProjectileType("BlazingBulletShot"), damage, knockBack, player.whoAmI, 0f, 0f);
				}
			}
			
			return false;
		}
	}
}
