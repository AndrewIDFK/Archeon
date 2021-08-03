using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Summon.HM
{
	public class PenumbraWard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Penumbra Ward");
			Tooltip.SetDefault("Summons a Dark Defender above you \nTakes up half a minion slot");
		}

		public override void SetDefaults()
		{
			item.damage = 34;
			item.summon = true;
			item.mana = 25;
			item.width = 42;
			item.height = 42;
			item.useTime = 19;
			item.useAnimation = 19;
			item.knockBack = 1f;
			item.useStyle = 1;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("PenumbraWardMinion");
			item.shootSpeed = 0f;
		}
		
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] <= 0;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position, Vector2.Zero, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
		
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(mod.ItemType("ShadoniumBar"), 18);
			modRecipe.AddIngredient(mod.ItemType("RougeWard"), 1);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
