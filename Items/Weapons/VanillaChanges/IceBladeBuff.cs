using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons.VanillaChanges
{
	public class IceBladeBuff : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == 724)
			{
				item.damage = 22;
				item.useTime = 15;
				item.useAnimation = 15;
			}
		}

		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (item.type == 724)
			{
				target.AddBuff(44, 220, false);
			}
		}
	}
}
