using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000BA RID: 186
	public class StroidWormerStaff : ModItem
	{
		// Token: 0x06000358 RID: 856 RVA: 0x0001C38A File Offset: 0x0001A58A
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Eel Staff");
			base.Tooltip.SetDefault("This Eel will most likely protect you...");
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0001C3AC File Offset: 0x0001A5AC
		public override void SetDefaults()
		{
			base.item.mana = 10;
			base.item.damage = 95;
			base.item.useStyle = 1;
			base.item.shootSpeed = 10f;
			base.item.shoot = base.mod.ProjectileType("StroidWormerHead");
			base.item.width = 26;
			base.item.height = 28;
			base.item.useAnimation = 36;
			base.item.useTime = 36;
			base.item.rare = 8;
			base.item.noMelee = true;
			base.item.knockBack = 4.5f;
			base.item.UseSound = SoundID.Item44;
			
			base.item.value = Item.buyPrice(0, 12, 0, 0);
			base.item.value = Item.sellPrice(0, 12, 0, 0);
			base.item.summon = true;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0001C4D7 File Offset: 0x0001A6D7
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0001C4DA File Offset: 0x0001A6DA
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0001C53C File Offset: 0x0001A73C
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float slotsUsed = 0f;
			(from x in Main.projectile
			where x.active && x.owner == player.whoAmI && x.minionSlots > 0f
			select x).ToList<Projectile>().ForEach(delegate(Projectile x)
			{
				slotsUsed += x.minionSlots;
			});
			if ((float)player.maxMinions - slotsUsed < 1f)
			{
				return false;
			}
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < 1000; i++)
			{
				Projectile projectile = Main.projectile[i];
				if (projectile.active && projectile.owner == player.whoAmI)
				{
					if (num == -1 && projectile.type == base.mod.ProjectileType("StroidWormerHead"))
					{
						num = i;
					}
					if (num2 == -1 && projectile.type == base.mod.ProjectileType("StroidWormerTail"))
					{
						num2 = i;
					}
					if (num != -1 && num2 != -1)
					{
						break;
					}
				}
			}
			if (num == -1 && num2 == -1)
			{
				int num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("StroidWormerHead"), damage, knockBack, player.whoAmI, 0f, 0f);
				int num4 = 0;
				for (int j = 0; j < 1; j++)
				{
					num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("StroidWormerBody"), damage, knockBack, player.whoAmI, (float)num3, 0f);
				}
				num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("StroidWormerTail"), damage, knockBack, player.whoAmI, (float)num3, 0f);
				Main.projectile[num4].localAI[1] = (float)num3;
				Main.projectile[num4].netUpdate = true;
			}
			else
			{
				int num5 = (int)Main.projectile[num2].ai[0];
				int num6 = 0;
				for (int k = 0; k < 3; k++)
				{
					num6 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("StroidWormerBody"), damage, knockBack, player.whoAmI, (float)Projectile.GetByUUID(Main.myPlayer, num5), 0f);
					num5 = num6;
				}
				Main.projectile[num6].localAI[1] = (float)num2;
				Main.projectile[num2].ai[0] = (float)num6;
				Main.projectile[num2].netUpdate = true;
				Main.projectile[num2].ai[1] = 1f;
			}
			return false;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001C800 File Offset: 0x0001AA00
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 24);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
