using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A2 RID: 162
	public class LunarPhantom : ModItem
	{
		// Token: 0x060002DF RID: 735 RVA: 0x00018D60 File Offset: 0x00016F60
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Phantom");
			base.Tooltip.SetDefault("Lunarian Power!\nShoots 2 arrows that shoot arrows towards enemies");
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00018D84 File Offset: 0x00016F84
		public override void SetDefaults()
		{
			base.item.damage = 145;
			base.item.crit = 22;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.width = 69;
			base.item.height = 40;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
			base.item.useStyle = 5;
			base.item.shoot = base.mod.ProjectileType("LunarPhantomArrow");
			base.item.useAmmo = AmmoID.Arrow;
			base.item.knockBack = 4f;
			base.item.value = Item.buyPrice(0, 13, 20, 0);
			base.item.value = Item.sellPrice(0, 13, 20, 0);
			base.item.rare = 10;
			base.item.UseSound = SoundID.Item5;
			base.item.autoReuse = true;
			base.item.shootSpeed = 13f;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00018EA6 File Offset: 0x000170A6
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00018EBC File Offset: 0x000170BC
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num = 2;
			for (int i = 0; i < num; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(5f));
				float scaleFactor = 1.2f - Utils.NextFloat(Main.rand) * 0.25f;
				value *= scaleFactor;
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.8f, value.Y * 1.8f, base.mod.ProjectileType("LunarPhantomArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00018F6C File Offset: 0x0001716C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("LunarFragment"), 30);
			modRecipe.AddIngredient(3540, 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
