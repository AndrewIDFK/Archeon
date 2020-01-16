using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace Archeon.Items.Projectiles
{
	// Token: 0x02000049 RID: 73
	public class BlackLightShot : ModProjectile
	{
		// Token: 0x06000139 RID: 313 RVA: 0x00008592 File Offset: 0x00006792
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Black Hole");
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000085A4 File Offset: 0x000067A4
		public override void SetDefaults()
		{
			base.projectile.width = 38;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			Main.projFrames[base.projectile.type] = 6;
			base.projectile.hostile = false;
			base.projectile.magic = true;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.scale = 1.2f;
			this.drawOriginOffsetY = 3;
			this.drawOriginOffsetX = -2f;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00008648 File Offset: 0x00006848
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.5f, 0.2f, 1.65f);
			int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 179, base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 0.85f;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 260f)
			{
				base.projectile.Kill();
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00008794 File Offset: 0x00006994
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
		{
			ArcheonGlobalProjectile.DrawCenteredAndAfterimage(base.projectile, lightColor, ProjectileID.Sets.TrailingMode[base.projectile.type], 1);
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter >= 35)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
				if (base.projectile.frame > 5)
				{
					base.projectile.frame = 0;
				}
			}
			return true;
		}
		
		
	}
}
