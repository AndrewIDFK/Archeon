using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A7 RID: 167
	public class PhantasmDragonStaff : ModItem
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x000194D7 File Offset: 0x000176D7
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Phantasm Dragon Staff");
			base.Tooltip.SetDefault("A tamed Baby Phantasm will protect you!");
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000194FC File Offset: 0x000176FC
		public override void SetDefaults()
		{
			base.item.mana = 10;
			base.item.damage = 152;
			base.item.useStyle = 1;
			base.item.shootSpeed = 10f;
			base.item.shoot = base.mod.ProjectileType("PhantasmDragonHead");
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

		// Token: 0x060002F5 RID: 757 RVA: 0x0001962A File Offset: 0x0001782A
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0001962D File Offset: 0x0001782D
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00019690 File Offset: 0x00017890
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
					if (num == -1 && projectile.type == base.mod.ProjectileType("PhantasmDragonHead"))
					{
						num = i;
					}
					if (num2 == -1 && projectile.type == base.mod.ProjectileType("PhantasmDragonTail"))
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
				int num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("PhantasmDragonHead"), damage, knockBack, player.whoAmI, 0f, 0f);
				int num4 = 0;
				for (int j = 0; j < 1; j++)
				{
					num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("PhantasmDragonBody"), damage, knockBack, player.whoAmI, (float)num3, 0f);
				}
				num3 = Projectile.NewProjectile(position.X, position.Y, 0f, 0f, base.mod.ProjectileType("PhantasmDragonTail"), damage, knockBack, player.whoAmI, (float)num3, 0f);
				Main.projectile[num4].localAI[1] = (float)num3;
				Main.projectile[num4].netUpdate = true;
			}
			else
			{
				int num5 = (int)Main.projectile[num2].ai[0];
				int num6 = 0;
				for (int k = 0; k < 3; k++)
				{
					num6 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, base.mod.ProjectileType("PhantasmDragonBody"), damage, knockBack, player.whoAmI, (float)Projectile.GetByUUID(Main.myPlayer, num5), 0f);
					num5 = num6;
				}
				Main.projectile[num6].localAI[1] = (float)num2;
				Main.projectile[num2].ai[0] = (float)num6;
				Main.projectile[num2].netUpdate = true;
				Main.projectile[num2].ai[1] = 1f;
			}
			return false;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00019954 File Offset: 0x00017B54
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 36);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
