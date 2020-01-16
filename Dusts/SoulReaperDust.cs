using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	// Token: 0x02000029 RID: 41
	public class SoulReaperDust : ModDust
	{
		// Token: 0x060000AF RID: 175 RVA: 0x00005EAC File Offset: 0x000040AC
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = false;
			dust.noLight = false;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005EBC File Offset: 0x000040BC
		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.05f;
			dust.position += dust.velocity;
			dust.scale -= 0.078f;
			float num = 0.32f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.41f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
