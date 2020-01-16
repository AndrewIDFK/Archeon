using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items
{
	// Token: 0x02000034 RID: 52
	public class LunaticSiren : ModItem
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00006A48 File Offset: 0x00004C48
		public override void SetDefaults()
		{
			base.item.width = 32;
			base.item.height = 32;
			base.item.scale = 1f;
			base.item.maxStack = 30;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.UseSound = SoundID.Item1;
			base.item.noUseGraphic = true;
			base.item.useStyle = 1;
			base.item.value = Item.buyPrice(0, 1, 0, 0);
			base.item.value = Item.sellPrice(0, 1, 0, 0);
			base.item.rare = 12;
			base.item.consumable = true;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00006B0F File Offset: 0x00004D0F
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lunar Sigil");
			base.Tooltip.SetDefault("Alerts Lunatics to your location");
			Main.RegisterItemAnimation(base.item.type, new DrawAnimationVertical(8, 5));
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006B48 File Offset: 0x00004D48
		public override bool UseItem(Player player)
		{
			Main.NewText("Prepare for a fight!", 66, 65, 175, false);
			LunacyEvent.StartLunacyEvent();
			return true;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00006B64 File Offset: 0x00004D64
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(3467, 3);
			modRecipe.AddIngredient(3458, 3);
			modRecipe.AddIngredient(3456, 3);
			modRecipe.AddIngredient(3459, 3);
			modRecipe.AddIngredient(3457, 3);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
