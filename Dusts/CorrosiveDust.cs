using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Dusts
{
	public class CorrosiveDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
		}

		public override bool Update(Dust dust)
		{
			dust.rotation += dust.velocity.X * 0.05f;
			dust.position += dust.velocity;
			dust.scale -= 0.12f;
			float num = 0.22f * dust.scale;
			Lighting.AddLight(dust.position, num, num, num);
			if (dust.scale < 0.34f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}
