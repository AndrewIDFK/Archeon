using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x0200002C RID: 44
	public class StroidWormDeathDust : ModDust
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x00006080 File Offset: 0x00004280
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006090 File Offset: 0x00004290
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.98f;
			float num = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.4f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
