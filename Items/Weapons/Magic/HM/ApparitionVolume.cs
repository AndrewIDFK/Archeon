using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.HM
{
	public class ApparitionVolume : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apparition Volume");
			Tooltip.SetDefault("Casts multiple apparitions around the player");
		}

		public override void SetDefaults()
		{
			item.damage = 48;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 29;
			item.useAnimation = 29;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = Item.buyPrice(0, 4, 20, 0);
			item.rare = 5;
			item.mana = 10;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ApparitionVolumeProj");
			item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 3; i++)
			{
				float num = Utils.NextFloat(Main.rand) * 30f;
				position = position + Utils.ToRotationVector2(num) * MathHelper.Lerp(-120f, 120f, Utils.NextFloat(Main.rand));
				Projectile.NewProjectile(position.X, position.Y, 0f, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.SpellTome, 1);
			modRecipe.AddIngredient(ItemID.CrystalShard, 20);
			modRecipe.AddTile(TileID.Bookcases);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
