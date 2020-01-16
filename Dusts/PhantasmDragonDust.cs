using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x0200002A RID: 42
	public class PhantasmDragonDust : ModDust
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x00005F48 File Offset: 0x00004148
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = false;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00005F58 File Offset: 0x00004158
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale -= 0.04f;
			float num = 0.25f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.25f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
