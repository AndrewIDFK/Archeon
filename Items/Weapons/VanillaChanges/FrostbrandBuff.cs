using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class FrostbrandBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 676)
			{
				item.damage = 48;
				item.useTime = 16;
				item.useAnimation = 16;
			}
		}

		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (item.type == 676)
			{
				target.AddBuff(44, 380, false);
			}
		}
	}
}
