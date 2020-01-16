using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000832 RID: 2098
	public class RingFire : ModItem
	{
		// Token: 0x06003358 RID: 13144 RVA: 0x0030B781 File Offset: 0x00309981
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flaming Torrent");
			base.Tooltip.SetDefault("Casts a Flaming torrent of fire");
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x0030B7A4 File Offset: 0x003099A4
		public override void SetDefaults()
		{
			base.item.damage = 30;
			base.item.magic = true;
			base.item.mana = 30;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 32;
			base.item.useAnimation = 32;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 3.4f;
			base.item.value = Item.buyPrice(0, 2, 15, 0);
			base.item.rare = 5;
			base.item.UseSound = SoundID.Item84;
			base.item.autoReuse = false;
			base.item.shoot = base.mod.ProjectileType("RingFireShot");
			base.item.shootSpeed = 18f;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = 0.01f;
			double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)(num);
			double num3 = (double)(num);
			for (int i = 0; i < 1; i++)
			{
				double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(29f * (float)i);
				Projectile.NewProjectile(position.X, position.Y, (float)(Math.Sin(num4) * 5.0), (float)(Math.Cos(num4) * 5.0), type, damage, knockBack, Main.myPlayer, 0f, 0f);
			}
			return false;
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x0030B9BC File Offset: 0x00309BBC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(175, 25);
			modRecipe.AddIngredient(ItemID.Bone, 15);
			modRecipe.AddIngredient(531);
			modRecipe.AddTile(TileID.Bookcases);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
