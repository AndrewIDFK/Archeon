using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.AirElementEye
{
    public class AirElementEyeShot : ModProjectile
    {
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Aero Eye");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
			projectile.hide = true;
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(83, (int)projectile.position.X, (int)projectile.position.Y, 20);
                projectile.localAI[0] = 1f;
            }		
			
            int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust2"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.65f;
			Main.dust[num].noGravity = true;
			
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AirElementDust2"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.65f;
			Main.dust[num2].noGravity = true;
			
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			
			
			
        }
    }
}