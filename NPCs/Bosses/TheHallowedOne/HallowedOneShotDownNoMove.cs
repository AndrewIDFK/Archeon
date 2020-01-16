using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.TheHallowedOne
{
	// Token: 0x02000054 RID: 84
	public class HallowedOneShotDownNoMove : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Halloween's Pierce");
		}
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.3f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.aiStyle = 27;
			base.projectile.hostile = true;
			base.projectile.penetrate = 4;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.hide = true;
			base.projectile.timeLeft = 12;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1.35f;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.35f;
			int num23 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num23].velocity /= 160f;
			Main.dust[num23].scale = 1.35f;
			
		}
		
		

		// Token: 0x060015C2 RID: 5570 RVA: 0x0011CCC0 File Offset: 0x0011AEC0
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item8, base.projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust2"), base.projectile.oldVelocity.X * 2.5f, base.projectile.oldVelocity.Y * 2.5f, 0, default(Color), 1f);
			}
			
			Projectile.NewProjectile(base.projectile.Center.X + 4.5f, base.projectile.Center.Y + 4.5f, projectile.velocity.X, projectile.velocity.Y + 12.21f, base.mod.ProjectileType("HallowedOneShotStraightDown"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);

		}
	}
}
