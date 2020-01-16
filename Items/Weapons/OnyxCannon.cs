using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000A5 RID: 165
	public class OnyxCannon : ModItem
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0001903E File Offset: 0x0001723E
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Onyx Cannon");
			base.Tooltip.SetDefault("Fires 13 bullets and an Onyx Blast each round");
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00019060 File Offset: 0x00017260
		public override void SetDefaults()
		{
			base.item.damage = 47;
			base.item.crit = 2;
			base.item.ranged = true;
			base.item.width = 18;
			base.item.height = 18;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = Item.buyPrice(0, 4, 25, 0);
			base.item.value = Item.sellPrice(0, 4, 25, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item40;
			base.item.autoReuse = true;
			base.item.shoot = 10;
			base.item.shootSpeed = 24f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00019170 File Offset: 0x00017370
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ExoStick"), 1);
			modRecipe.AddIngredient(3467, 5);
			modRecipe.AddIngredient(3788, 1);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000191D1 File Offset: 0x000173D1
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-4f, -1f));
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000191E8 File Offset: 0x000173E8
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 value = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + value, 0, 0))
			{
				position += value;
			}
			int num = 13;
			for (int i = 0; i < num; i++)
			{
				Vector2 value2 = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(13f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.5f;
				value2 *= scaleFactor;
				Projectile.NewProjectile(position.X, position.Y, value2.X, value2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			Projectile.NewProjectile(position.X, position.Y, speedX / 2f, speedY / 2f, 661, 124, 10f, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
