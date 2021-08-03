using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.Magic.PreHM
{
	public class FrozenOpus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Opus");
			Tooltip.SetDefault("Casts a frozen ball of frost");
		}

		public override void SetDefaults()
		{
			item.damage = 27;
			item.magic = true;
			item.width = 24;
			item.height = 28;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2.5f;
			item.value = Item.buyPrice(0, 0, 70, 0);
			item.rare = 4;
			item.mana = 5;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FrozenOpusProj");
			item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ItemID.IceBlock, 25);
			modRecipe.AddIngredient(ItemID.Book, 1);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
