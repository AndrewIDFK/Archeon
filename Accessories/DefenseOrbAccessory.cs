using System;
using Terraria;
using Terraria.ModLoader;

namespace Archeon.Accessories
{
	public class DefenseOrbAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Defense");
			base.Tooltip.SetDefault("Summons a Defense Orb to aid you in your journey!");
		}
		
		public override void SetDefaults()
		{
			base.item.width = 20;
			base.item.height = 26;
			base.item.value = Item.buyPrice(0, 1, 30, 0);
			base.item.rare = 4;
			base.item.accessory = true;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			return !player.GetModPlayer<MyPlayer>().DefenseOrbAccessory;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>().DefenseOrbAccessory = true;
			if (player.whoAmI == Main.myPlayer)
			{
				if (player.ownedProjectileCounts[base.mod.ProjectileType("DefenseOrbAccessory")] < 1)
				{
					Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, base.mod.ProjectileType("DefenseOrbAccessory"), (int)(0.65f * player.minionDamage), 1f, Main.myPlayer, 0f, 0f);
				}
				if (player.FindBuffIndex(base.mod.BuffType("DefenseOrbAccessory")) == -1)
				{
					player.AddBuff(base.mod.BuffType("DefenseOrbAccessory"), 6900, true);
				}
			}
		}
	}
}
