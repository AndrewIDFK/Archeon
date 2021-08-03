using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Ranged.PreHM
{
	public class ScarletSinew : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarlet Sinew");
			Tooltip.SetDefault("Turns wooden arrows into bloody arrows");
		}
		
		public override void SetDefaults()
		{
			item.damage = 26;
			item.noMelee = true;
			item.ranged = true;
			item.width = 26;
			item.height = 46;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 5;
			item.shoot = AmmoID.Arrow;
			item.useAmmo = AmmoID.Arrow;
			item.knockBack = 1f;
			item.value = Item.buyPrice(0, 0, 95, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shootSpeed = 8.5f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("BloodyArrowProj");
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(new Vector2(2f, 1f));
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 14);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
