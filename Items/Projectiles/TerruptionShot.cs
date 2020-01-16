using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x0200006C RID: 108
	public class TerruptionShot : ModProjectile
	{
		// Token: 0x060001D1 RID: 465 RVA: 0x00010234 File Offset: 0x0000E434
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 27;
			base.projectile.friendly = true;
			base.projectile.penetrate = 2;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000102B0 File Offset: 0x0000E4B0
		public override void AI()
		{
			Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 135, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 0;
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x00010334 File Offset: 0x0000E534
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
		}
	}
}
