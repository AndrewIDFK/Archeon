using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000832 RID: 2098
	public class PlasmaRazorBlade : ModItem
	{
		// Token: 0x06003358 RID: 13144 RVA: 0x0030B781 File Offset: 0x00309981
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Torrent");
			base.Tooltip.SetDefault("Casts 2 deadly Plasma torrents");
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x0030B7A4 File Offset: 0x003099A4
		public override void SetDefaults()
		{
			base.item.damage = 55;
			base.item.magic = true;
			base.item.mana = 18;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 3.9f;
			base.item.value = Item.buyPrice(0, 7, 10, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item84;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("PlasmaRazorBladeShot");
			base.item.shootSpeed = 10f;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int num = 2;
			for (int i = 0; i < num; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(22f));
				float scaleFactor = 1f - Utils.NextFloat(Main.rand) * 0.2f;;
				value *= scaleFactor;
				Projectile.NewProjectile(position.X, position.Y, value.X / 1.5f, value.Y / 1.5f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		// Token: 0x0600335B RID: 13147 RVA: 0x0030B9BC File Offset: 0x00309BBC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "PlasmiteBar", 15);
			modRecipe.AddIngredient(ItemID.RazorbladeTyphoon);
			modRecipe.AddIngredient(null, "RingFire");
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
