using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x02000027 RID: 39
	public class FlameFrostBrandFireDust : ModDust
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x00005D72 File Offset: 0x00003F72
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005D84 File Offset: 0x00003F84
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.05f;
			dust.position += dust.velocity;
			dust.scale -= 0.07f;
			float num = 0.25f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.38f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
