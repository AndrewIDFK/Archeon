using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.TheHallowedOne
{
	// Token: 0x02000054 RID: 84
	public class HallowedOneShotStraightDown : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Hallowed's Pierce");
		}
		// Token: 0x0600016E RID: 366 RVA: 0x0000AEBC File Offset: 0x000090BC
		public override void SetDefaults()
		{
			base.projectile.scale = 1.3f;
			base.projectile.extraUpdates = 0;
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.aiStyle = 27;
			base.projectile.hostile = true;
			base.projectile.penetrate = 1;
			base.projectile.melee = true;
			Main.PlaySound(SoundID.Item15, base.projectile.position);
			base.projectile.timeLeft = 245;
			base.projectile.hide = true;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AF54 File Offset: 0x00009154
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 1.25f;
			int num22 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num22].velocity /= 160f;
			Main.dust[num22].scale = 1.3f;
			int num23 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust1"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num23].velocity /= 160f;
			Main.dust[num23].scale = 1.3f;
			int num25 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("StroidDust2"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num25].velocity /= 160f;
			Main.dust[num25].scale = 1.25f;	
		}
	}
}
