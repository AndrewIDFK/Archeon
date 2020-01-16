using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class AttackOrbOuch : ModProjectile
    {
		
		
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Attack Orb");
		}
		
        public override void SetDefaults()
        {
			base.projectile.width = 4;
			base.projectile.height = 4;
			//base.projectile.aiStyle = 1;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 160;
			base.projectile.alpha = 140;
			base.projectile.light = 0.65f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.extraUpdates = 1;
			//this.aiType = 14;
			projectile.scale = 1.4f;
			projectile.hide = true;
			
			
			
           
        }
		
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.49f, 0.87f, 1.22f);
			/*int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("AttackOrbDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 0.5f;*/
			
			for (int num163 = 0; num163 < 10; num163++)
			{
				float x2 = base.projectile.position.X - base.projectile.velocity.X / 10f * (float)num163;
				float y2 = base.projectile.position.Y - base.projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("AttackOrbDust"));	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
				Main.dust[num164].scale = 1.45f;
			}

			base.projectile.ai[1] += 1f; 
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			float num = 85f;
			float scaleFactor = 15f;
			float num2 = 55f;
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 10;
			}
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			
			int num3 = (int)base.projectile.ai[0];
			if (num3 >= 0 && Main.player[num3].active && !Main.player[num3].dead)
			{
				if (base.projectile.Distance(Main.player[num3].Center) > num2)
				{
					Vector2 vector = base.projectile.DirectionTo(Main.player[num3].Center);
					if (vector.HasNaNs())
					{
						vector = Vector2.UnitY;
					}
					base.projectile.velocity = (base.projectile.velocity * (num - 1f) + vector * scaleFactor) / num;
					return;
				}
			}
			else
			{
				if (base.projectile.timeLeft > 30)
				{
					base.projectile.timeLeft = 30;
				}
				if (base.projectile.ai[0] != -1f)
				{
					base.projectile.ai[0] = -1f;
					base.projectile.netUpdate = true;
					return;
				}
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			
		}
    }
}