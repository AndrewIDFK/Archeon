using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class DefenseOrbHealingUp : ModProjectile
    {
		
		private int marbieHeal;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Healing Shard");
		}
		
        public override void SetDefaults()
        {
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.aiStyle = 1;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			base.projectile.ranged = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 1;
			base.projectile.alpha = 140;
			base.projectile.light = 0.65f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.extraUpdates = 1;
			this.aiType = 14;
			projectile.scale = 1.4f;
			projectile.hide = true;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			bool expertBoomer = Main.expertMode || !Main.expertMode;
			
			
				float numHeal = expertBoomer ? 90f : 120f;
				
				this.marbieHeal++;
				if ((float)this.marbieHeal >= numHeal)
				{
					this.marbieHeal = 0;
					if (Main.netMode != 1)
					{
						int numLife = target.lifeMax / 350;
						if (numLife > target.lifeMax - target.life)
						{
							numLife = target.lifeMax - target.life;
						}
						if (numLife > 0)
						{
							target.life += numLife;
							
							target.HealEffect(numLife, true);
							
							target.netUpdate = true;
						}
					}
				}				
			
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
        }
		
        public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.13f, 0.27f, 0.84f);
			
			for (int num163 = 0; num163 < 10; num163++)
			{
				float x2 = base.projectile.position.X - base.projectile.velocity.X / 10f * (float)num163;
				float y2 = base.projectile.position.Y - base.projectile.velocity.Y / 10f * (float)num163;
				int num164 = Dust.NewDust(new Vector2(x2, y2), 1, 1, mod.DustType("DefenseOrbHealingDust"));	
				Main.dust[num164].position.X = x2;
				Main.dust[num164].position.Y = y2;
				Main.dust[num164].velocity *= 0f;
				Main.dust[num164].noGravity = true;
				Main.dust[num164].scale = 1.45f;
			}		
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			
			Projectile.NewProjectile(base.projectile.Center.X + 6.5f, base.projectile.Center.Y + 6.5f, projectile.velocity.X, projectile.velocity.Y - 26.2f, base.mod.ProjectileType("DefenseOrbHealingUp2"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
		}
    }
}