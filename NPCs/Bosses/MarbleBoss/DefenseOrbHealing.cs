using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.NPCs.Bosses.MarbleBoss
{
    public class DefenseOrbHealing : ModProjectile
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
			//base.projectile.aiStyle = 1;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 85;
			base.projectile.alpha = 140;
			base.projectile.light = 0.65f;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.extraUpdates = 1;
			//this.aiType = 14;
			projectile.scale = 1.4f;
			projectile.hide = true;
			
			
			
			
           
        }

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			/*Rectangle rectangle4 = new Rectangle((int)base.projectile.position.X, (int)base.projectile.position.Y, projectile.width, projectile.height);
			for (int j = 0; j < 200; j++)
			{
				if (Main.npc[j].active && !Main.npc[j].dontTakeDamage && Main.npc[j].lifeMax > 1)
				{
					Rectangle value12 = new Rectangle((int)Main.npc[j].position.X, (int)Main.npc[j].position.Y, Main.npc[j].width, Main.npc[j].height);
					if (rectangle4.Intersects(value12))	
					{
						int numLife = target.lifeMax / 150;
						if (numLife > target.lifeMax - target.life)
						{
							numLife = target.lifeMax - target.life;
						}
						target.life += numLife;	
					
						target.HealEffect(numLife, true);
					
						target.netUpdate = true;
						//Main.npc[num584].AddBuff(num583, 1500);
						projectile.Kill();
					}
				}
			}*/
			
				int numLife = target.lifeMax / 150;
				if (numLife > target.lifeMax - target.life)
				{
					numLife = target.lifeMax - target.life;
				}
				target.life += numLife;	
				
				target.HealEffect(numLife, true);
				
				target.netUpdate = true;
				
				knockback = 0f;
				damage = 0;
				crit = false;
				if(projectile.damage >= 1)
				{
					projectile.damage = 0;
				}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
		
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
        }
		
        public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, 0.13f, 0.27f, 0.84f);
			
			int num21 = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, base.mod.DustType("DefenseOrbHealingDust"), base.projectile.velocity.X * -0.2f, base.projectile.velocity.Y * -0.2f, 0, default(Color), 1f);
			Main.dust[num21].velocity /= 160f;
			Main.dust[num21].scale = 0.5f;
			
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
			
			
			
			
			float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 9000f;
			bool flag = false;
			
			
			for (int j = 0; j < 125; j++)
			{
				if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
				{
					float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
					float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
					float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
					if (num7 < num4)
					{
						num4 = num7;
						num2 = num5;
						num3 = num6;
						flag = true;
					}
				}
			}
			if (flag)
			{
				float num8 = 35f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector.X;
				float num10 = num3 - vector.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
			}
				
			/*bool expertBoomer = Main.expertMode || !Main.expertMode;
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
			}*/	
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(SoundID.Item10, base.projectile.position);
			
		}
    }
}