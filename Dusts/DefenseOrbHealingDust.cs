using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x02000027 RID: 39
	public class DefenseOrbHealingDust : ModDust
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x00005D72 File Offset: 0x00003F72
		public override void OnSpawn(Dust dust)
		{
			dust.scale = Main.rand.NextFloat(0.9f, 1f);
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x0037A134 File Offset: 0x00378334
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.02f;
			dust.position += dust.velocity;
			dust.scale -= 0.035f;
			float num = 0.25f * dust.scale;
			Lighting.AddLight(dust.position, 0.21f, 0.17f, 1.48f);
			if (dust.scale < 0.18f)
			{
				dust.active = false;
			}
			return false;
		}
		
		
	}
}
