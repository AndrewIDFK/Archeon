using System;
using Archeon.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200005F RID: 95
	public class PlasmaShurikenShot : ModProjectile
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000E894 File Offset: 0x0000CA94
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plasma Shuriken");
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000E8A8 File Offset: 0x0000CAA8
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 26;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.thrown = true;
			base.projectile.penetrate = 3;
			base.projectile.aiStyle = 2;
			this.aiType = 3;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000E92C File Offset: 0x0000CB2C
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 1.3f, 0f, 1.3f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 35f;
			Main.dust[num].scale = 0.45f;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000E9FC File Offset: 0x0000CBFC
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffType<CosmicalPoisoning>(), 460, false);
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000EA18 File Offset: 0x0000CC18
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * 33.9f, base.projectile.velocity.Y * 21.9f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.1f;
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -22.4f, base.projectile.velocity.Y * -13.6f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.1f;
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -30.2f, base.projectile.velocity.Y * -14.7f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.1f;
			int num4 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * -10.4f, base.projectile.velocity.Y * 2.9f, 0, default(Color), 1f);
			Main.dust[num4].velocity /= 80f;
			Main.dust[num4].scale = 1.1f;
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 249, base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			
		}
	}
}
