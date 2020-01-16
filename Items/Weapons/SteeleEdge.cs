using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x020000B4 RID: 180
	public class SteeleEdge : ModItem
	{
		// Token: 0x06000336 RID: 822 RVA: 0x0001B587 File Offset: 0x00019787
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Steele Edge");
			base.Tooltip.SetDefault("Inflics Steele Poisoning upon enemies");
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0001B5AC File Offset: 0x000197AC
		public override void SetDefaults()
		{
			base.item.damage = 69;
			base.item.melee = true;
			base.item.width = 40;
			base.item.height = 40;
			base.item.useTime = 17;
			base.item.useAnimation = 17;
			base.item.useStyle = 1;
			base.item.knockBack = 7f;
			base.item.value = Item.buyPrice(0, 1, 40, 0);
			base.item.value = Item.sellPrice(0, 1, 40, 0);
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.useTurn = true;
			base.item.scale = 1.2f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 3))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, base.mod.DustType("SteeleDust"), 0f, 0f, 0, default(Color), 1f);
				
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.item.owner] = 0;
			target.AddBuff(base.mod.BuffType("SteeleDebuff"), 280, false);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001B89C File Offset: 0x00019A9C
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
