using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x02000099 RID: 153
	public class FrostbrandBuff : GlobalItem
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x000180C1 File Offset: 0x000162C1
		public override void SetDefaults(Item item)
		{
			if (item.type == 676)
			{
				item.damage = 48;
				item.useTime = 16;
				item.useAnimation = 16;
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x000180E8 File Offset: 0x000162E8
		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (item.type == 676)
			{
				target.AddBuff(44, 380, false);
			}
		}
	}
}
