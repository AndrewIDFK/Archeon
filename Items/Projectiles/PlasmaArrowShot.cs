using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005E RID: 94
	public class PlasmaArrowShot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Arrow");
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
			base.projectile.extraUpdates = 1;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000E32C File Offset: 0x0000C52C
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.37f, 0f, 1.43f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 130f;
			Main.dust[num].scale = 0.55f;
			Main.dust[num].noGravity = true;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + MathHelper.ToRadians(270f);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000E43A File Offset: 0x0000C63A
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffType<CosmicalPoisoning>(), 600, false);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000E454 File Offset: 0x0000C654
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * 11.6f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -20.2f, base.projectile.velocity.Y * -10.7f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			int num6 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 13.9f, 0, default(Color), 1f);
			Main.dust[num6].velocity /= 80f;
			Main.dust[num6].scale = 1.1f;
		}
	}
}
