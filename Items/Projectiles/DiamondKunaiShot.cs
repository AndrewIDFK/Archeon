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
	public class DiamondKunaiShot : ModProjectile
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000E894 File Offset: 0x0000CA94
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Diamond Kunai");
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000E8A8 File Offset: 0x0000CAA8
		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 46;
			base.projectile.friendly = true;
			base.projectile.hostile = false;
			base.projectile.tileCollide = true;
			base.projectile.ignoreWater = true;
			base.projectile.thrown = true;
			base.projectile.penetrate = 2;
			base.projectile.aiStyle = 1;
			projectile.scale = 0.8f;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000E92C File Offset: 0x0000CB2C
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.1f, 0.1f, 0.1f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 63, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 35f;
			Main.dust[num].scale = 0.5f;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.immune[base.projectile.owner] = 1;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000EA18 File Offset: 0x0000CC18
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			int num5 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 63, base.projectile.velocity.X * 30.9f, base.projectile.velocity.Y * -21.9f, 0, default(Color), 1f);
			Main.dust[num5].velocity /= 80f;
			Main.dust[num5].scale = 1.1f;
			
		}
	}
}
