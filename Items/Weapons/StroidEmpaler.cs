using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B7 RID: 183
	public class StroidEmpaler : ModItem
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0001BD9C File Offset: 0x00019F9C
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Empaler");
			base.Tooltip.SetDefault("A spear forged from Stars");
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0001BDC0 File Offset: 0x00019FC0
		public override void SetDefaults()
		{
			base.item.damage = 149;
			base.item.melee = true;
			base.item.width = 40;
			base.item.maxStack = 1;
			base.item.height = 40;
			base.item.useTime = 18;
			base.item.scale = 1.15f;
			base.item.useAnimation = 18;
			base.item.useStyle = 5;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 14, 50, 0);
			base.item.value = Item.sellPrice(0, 14, 50, 0);
			base.item.rare = 8;
			base.item.shoot = base.mod.ProjectileType("StroidEmpalerShot");
			base.item.shootSpeed = 6.5f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			base.item.noUseGraphic = true;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001BEEC File Offset: 0x0001A0EC
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[base.item.shoot] < 1;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0001BF04 File Offset: 0x0001A104
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX * 2f, speedY * 2f, base.mod.ProjectileType("StroidEmpalerBeam"), damage, knockBack, player.whoAmI, 0f, 0f);
			return true;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001BF5C File Offset: 0x0001A15C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 14);
			modRecipe.AddIngredient(1228, 1);
			modRecipe.AddIngredient(550, 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(19, 10);
			modRecipe.AddIngredient(178, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(277, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(706, 10);
			modRecipe.AddIngredient(178, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(277, 1);
			modRecipe.AddRecipe();
		}
	}
}
