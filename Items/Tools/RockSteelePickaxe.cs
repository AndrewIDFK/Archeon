using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Tools
{
	// Token: 0x02000083 RID: 131
	public class RockSteelePickaxe : ModItem
	{
		// Token: 0x06000254 RID: 596 RVA: 0x00015B66 File Offset: 0x00013D66
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("RockSteele Pickaxe");
			base.Tooltip.SetDefault("Heaviest Light-weight pickaxe you've ever held");
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00015B88 File Offset: 0x00013D88
		public override void SetDefaults()
		{
			base.item.damage = 22;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 5;
			base.item.useAnimation = 15;
			base.item.pick = 195;
			base.item.useStyle = 1;
			base.item.knockBack = 8f;
			base.item.value = Item.buyPrice(0, 1, 10, 0);
			base.item.value = Item.sellPrice(0, 1, 10, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00015C6C File Offset: 0x00013E6C
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("RockSteeleBar"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
