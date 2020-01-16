using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Enemies.FireElementHover
{
    public class FireElementHoverShot : ModProjectile
    {
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fire Guardian");
		}
		
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 360;
			projectile.hide = true;
        }

		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Burning, 240);
        }
		
        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(43, (int)projectile.position.X, (int)projectile.position.Y, 20);
                projectile.localAI[0] = 1f;
            }
			
            int num = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FireElementDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num].velocity /= 80f;
			Main.dust[num].scale = 1.6f;
			Main.dust[num].noGravity = true;
			
			int num2 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FireElementDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num2].velocity /= 80f;
			Main.dust[num2].scale = 1.6f;
			Main.dust[num2].noGravity = true;
			
			int num3 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("FireElementDust"), base.projectile.velocity.X * -0.5f, base.projectile.velocity.Y * -0.5f, 0, default(Color), 1f);
			Main.dust[num3].velocity /= 80f;
			Main.dust[num3].scale = 1.6f;
			Main.dust[num3].noGravity = true;		
        }
    }
}