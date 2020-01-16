using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009B RID: 155
	public class IAW : ModItem
	{
		// Token: 0x060002BF RID: 703 RVA: 0x00018288 File Offset: 0x00016488
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The IAW");
			base.Tooltip.SetDefault("Has a sticker of KennyS on the side of it");
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000182AC File Offset: 0x000164AC
		public override void SetDefaults()
		{
			base.item.damage = 70;
			base.item.crit = 46;
			base.item.ranged = true;
			base.item.width = 16;
			base.item.height = 16;
			base.item.useTime = 45;
			base.item.useAnimation = 45;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 14f;
			base.item.value = Item.buyPrice(0, 1, 10, 0);
			base.item.value = Item.sellPrice(0, 1, 10, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item38;
			base.item.autoReuse = false;
			base.item.shoot = 10;
			base.item.shootSpeed = 26f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000183BC File Offset: 0x000165BC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("VyssoniumBar"), 18);
			modRecipe.AddIngredient(800, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("ShadoniumBar"), 18);
			modRecipe.AddIngredient(96, 1);
			modRecipe.AddTile(16);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00018452 File Offset: 0x00016652
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(-5f, 2f));
		}
	}
}
