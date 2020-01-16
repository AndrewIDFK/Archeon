using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x02000028 RID: 40
	public class DefenseOrbDust : ModDust
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00005E10 File Offset: 0x00004010
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = false;
			dust.noLight = false;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005E20 File Offset: 0x00004020
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.02f;
			dust.position += dust.velocity;
			dust.scale -= 0.035f;
			float num = 0.25f * dust.scale;
			Lighting.AddLight(dust.position, 0.11f, 0.36f, 0.96f);
			if (dust.scale < 0.18f)
			{
				dust.active = false;
			}
			return false;
		}
		
		
	}
}
