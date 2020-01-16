using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B0 RID: 176
	public class RockSteeleBullet : ModItem
	{
		// Token: 0x06000322 RID: 802 RVA: 0x0001ABA9 File Offset: 0x00018DA9
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele bullet");
			base.Tooltip.SetDefault("The bullets turn small when put into your inventory\n20% chance to not consume ammo");
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001ABCC File Offset: 0x00018DCC
		public override void SetDefaults()
		{
			base.item.damage = 10;
			base.item.ranged = true;
			base.item.width = 8;
			base.item.height = 8;
			base.item.maxStack = 4444;
			base.item.consumable = true;
			base.item.knockBack = 2.5f;
			base.item.value = Item.buyPrice(0, 0, 10, 0);
			base.item.value = Item.sellPrice(0, 0, 2, 50);
			base.item.rare = 4;
			base.item.shoot = base.mod.ProjectileType("RockSteeleBulletShot");
			base.item.shootSpeed = 16f;
			base.item.ammo = AmmoID.Bullet;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0001ACA7 File Offset: 0x00018EA7
		public override bool ConsumeAmmo(Player player)
		{
			return Utils.NextFloat(Main.rand) > 0.2f;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001ACBC File Offset: 0x00018EBC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(97, 144);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 144);
			modRecipe.AddRecipe();
		}
	}
}
