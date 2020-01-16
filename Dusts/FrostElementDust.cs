using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x0200002B RID: 43
	public class FrostElementDust : ModDust
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00005FE4 File Offset: 0x000041E4
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00005FF4 File Offset: 0x000041F4
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.05f;
			dust.position += dust.velocity;
			dust.scale -= 0.08f;
			float num = 0.22f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.42f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
