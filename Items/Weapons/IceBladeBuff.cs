using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Weapons
{
	// Token: 0x0200009C RID: 156
	public class IceBladeBuff : GlobalItem
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x00018470 File Offset: 0x00016670
		public override void SetDefaults(Item item)
		{
			if (item.type == 724)
			{
				item.damage = 22;
				item.useTime = 15;
				item.useAnimation = 15;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00018497 File Offset: 0x00016697
		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (item.type == 724)
			{
				target.AddBuff(44, 280, false);
			}
		}
	}
}
