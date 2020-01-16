using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x0200002D RID: 45
	public class UpperChargeDust : ModDust
	{
		// Token: 0x060000BB RID: 187 RVA: 0x0000611C File Offset: 0x0000431C
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000612C File Offset: 0x0000432C
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.02f;
			dust.position += dust.velocity;
			dust.scale -= 0.033f;
			float num = 0.22f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
