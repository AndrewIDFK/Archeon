using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B8 RID: 184
	public class StroidKalon : ModItem
	{
		// Token: 0x0600034E RID: 846 RVA: 0x0001C041 File Offset: 0x0001A241
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Kalon");
			base.Tooltip.SetDefault("Summons a Stroid Baby to fight along your side!");
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0001C064 File Offset: 0x0001A264
		public override void SetDefaults()
		{
			base.item.damage = 90;
			base.item.summon = true;
			base.item.mana = 45;
			base.item.width = 26;
			base.item.height = 28;
			base.item.useTime = 20;
			base.item.useAnimation = 20;
		
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.knockBack = 3f;
			base.item.value = Item.buyPrice(0, 6, 30, 0);
			base.item.value = Item.sellPrice(0, 6, 30, 0);
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item44;
			base.item.shoot = base.mod.ProjectileType("StroidMinion");
			base.item.shootSpeed = 8f;
			
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0001C18F File Offset: 0x0001A38F
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0001C192 File Offset: 0x0001A392
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0001C1AC File Offset: 0x0001A3AC
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(base.mod.ItemType("StroidBar"), 18);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
