using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000097 RID: 151
	public class Flamebrand : ModItem
	{
		// Token: 0x060002AB RID: 683 RVA: 0x00017C08 File Offset: 0x00015E08
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Flamebrand");
			base.Tooltip.SetDefault("Shoots a powerful Fiery bolt");
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00017C2C File Offset: 0x00015E2C
		public override void SetDefaults()
		{
			base.item.damage = 68;
			base.item.melee = true;
			base.item.width = 46;
			base.item.height = 50;
			base.item.useTime = 39;
			base.item.useAnimation = 22;
			base.item.useStyle = 1;
			base.item.knockBack = 5.5f;
			base.item.value = Item.buyPrice(0, 1, 90, 0);
			base.item.value = Item.sellPrice(0, 1, 90, 0);
			base.item.rare = 5;
			base.item.shootSpeed = 12f;
			base.item.shoot = base.mod.ProjectileType("FlamebrandShot");
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.scale = 1.15f;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00017D2F File Offset: 0x00015F2F
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 480, false);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00017D40 File Offset: 0x00015F40
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 4))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 0, default(Color), 1f);
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00017DA0 File Offset: 0x00015FA0
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(502, 20);
			modRecipe.AddIngredient(base.mod.ItemType("FireBlade"), 1);
			modRecipe.AddIngredient(521, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
			modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(502, 20);
			modRecipe.AddIngredient(724, 1);
			modRecipe.AddIngredient(520, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(676, 1); //frostbrand
			modRecipe.AddRecipe();
		}
	}
}
