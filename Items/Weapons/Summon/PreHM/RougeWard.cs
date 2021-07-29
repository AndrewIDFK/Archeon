using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Summon.PreHM
{
	public class RougeWard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rouge Ward");
			Tooltip.SetDefault("Summons a Crimson Guard above you \nTakes up half a minion slot");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.summon = true;
			item.mana = 25;
			item.width = 42;
			item.height = 42;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("RougeWardMinion");
			item.shootSpeed = 0f;
			item.knockBack = 1f;
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
			modRecipe.AddIngredient(mod.ItemType("VyssoniumBar"), 18);
			modRecipe.AddIngredient(ItemID.CrimtaneBar, 6);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
