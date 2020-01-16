using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles.ElementalArrows
{
	// Token: 0x0200006B RID: 107
	public class AirElementArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Air Elemental Arrow");
		}
		
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = 1;
		}
		
		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 160f;
			Main.dust[num].scale = 1.35f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 160f;
			Main.dust[num2].scale = 1.35f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 160f;
			Main.dust[num3].scale = 1.35f;
			
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 5;
			target.AddBuff(base.mod.BuffType("AirElementDebuff"), 240, false);
			target.AddBuff(164, 120, false);
		}

		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num].velocity /= 15f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 15f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 15f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 15f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 15f;
			Main.dust[num5].scale = 1.1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 15f;
			Main.dust[num6].scale = 1.1f;
			int num7 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num7].velocity /= 15f;
			Main.dust[num7].scale = 1.1f;
			int num8 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 1f);
			Main.dust[num8].velocity /= 15f;
			Main.dust[num8].scale = 1.1f;
		}
	}
}
