using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x02000027 RID: 39
	public class ShroomSharkFlameDust : ModDust
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x00005D72 File Offset: 0x00003F72
		public override void OnSpawn(Dust dust)
		{
			dust.scale = Main.rand.NextFloat(0.9f, 1f);
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x0037A134 File Offset: 0x00378334
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.02f;
			if (dust.scale < 0.3f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
