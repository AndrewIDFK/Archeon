using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Melee.HM
{
	public class DiamondKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piercing Dagger");
			Tooltip.SetDefault("Permanently decreases enemies defense \nEvery hit decreases defense by 5%");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.knockBack = 2.75f;
			item.value = Item.buyPrice(0, 1, 65, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("DiamondKnifeProj");
			item.shootSpeed = 17.5f;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Utils.NextBool(Main.rand, 5))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 63, 0f, 0f, 0, default(Color), 1f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(182, 20);
			modRecipe.AddIngredient(520, 5);
			modRecipe.AddIngredient(521, 5);
			modRecipe.AddIngredient(502, 10);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
