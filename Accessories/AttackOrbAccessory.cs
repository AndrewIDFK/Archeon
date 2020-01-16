using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Accessories
{
	public class AttackOrbAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Attack");
			base.Tooltip.SetDefault("Summons an Attack Orb to fight for you!");
		}
		
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.value = Item.buyPrice(0, 1, 30, 0);
			base.item.rare = 4;
			base.item.accessory = true;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			return !player.GetModPlayer<MyPlayer>().AttackOrbAccessory;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>().AttackOrbAccessory = true;
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.ownedProjectileCounts[base.mod.ProjectileType("AttackOrbAccessory")] < 1)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, base.mod.ProjectileType("AttackOrbAccessory"), (int)(0.65f * player.minionDamage), 1f, Main.myPlayer, 0f, 0f);
				}
				if (player.FindBuffIndex(base.mod.BuffType("AttackOrbAccessory")) == -1)
				{
					player.AddBuff(base.mod.BuffType("AttackOrbAccessory"), 6900, true);
				}
			}
		}
	}
}
