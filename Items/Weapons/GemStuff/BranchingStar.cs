using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.GemStuff
{
	// Token: 0x02000832 RID: 2098
	public class BranchingStar : ModItem
	{
		// Token: 0x06003358 RID: 13144 RVA: 0x0030B781 File Offset: 0x00309981
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Branching Star");
			base.Tooltip.SetDefault("Casts a web of gem prisms");
		}

		// Token: 0x06003359 RID: 13145 RVA: 0x0030B7A4 File Offset: 0x003099A4
		public override void SetDefaults()
		{
			base.item.damage = 65;
			base.item.magic = true;
			base.item.mana = 15;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 21;
			base.item.useAnimation = 21;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 1.2f;
			base.item.value = Item.buyPrice(0, 1, 10, 0);
			base.item.rare = 4;
			base.item.UseSound = SoundID.Item84;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("RubyWeb");
			base.item.shootSpeed = 10f;
		}

		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			
			int numberProjectiles = 1; // 1 of each gem Prism
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(27f));
				float scaleFactor = 1.28f - Utils.NextFloat(Main.rand) * 0.91f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, base.mod.ProjectileType("DiamondWeb"), damage + 12, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(28f));
				float scaleFactor = 1.29f - Utils.NextFloat(Main.rand) * 0.92f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, type, damage + 8, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(29f));
				float scaleFactor = 1.30f - Utils.NextFloat(Main.rand) * 0.93f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, base.mod.ProjectileType("EmeraldWeb"), damage + 4, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(30f));
				float scaleFactor = 1.31f - Utils.NextFloat(Main.rand) * 0.94f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X, value.Y, base.mod.ProjectileType("SapphireWeb"), damage + 2, knockBack, player.whoAmI, 0f, 0f);
			}
			
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 value = Utils.RotatedByRandom(new Vector2(speedX, speedY), (double)MathHelper.ToRadians(31f));
				float scaleFactor = 1.29f - Utils.NextFloat(Main.rand) * 0.88f;
				value *= scaleFactor;
				
				Projectile.NewProjectile(position.X, position.Y, value.X * 1.45f, value.Y * 1.45f, base.mod.ProjectileType("AmethystWeb"), damage + 1, knockBack, player.whoAmI, 0f, 0f);
			}
			return false; 
		}

		/*public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(ItemID.Diamond);
			modRecipe.AddIngredient(null, "RingFire");
			modRecipe.AddTile(TileID.Anvil);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}*/
	}
}
