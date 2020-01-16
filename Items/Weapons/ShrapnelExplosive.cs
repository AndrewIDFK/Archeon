using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	internal class ShrapnelExplosive : ModItem
	{
		// TODO, count as explosive for demolitionist spawn

		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Splitter Bomb");
			base.Tooltip.SetDefault("A Bomb that splits into 7 smaller explosives");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.shootSpeed = 9f;
			item.shoot = ProjectileType<Projectiles.ShrapnelExplosive>();
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 0, 15, 0);
			item.rare = 6;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(166, 15);
			recipe.AddIngredient(169, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}