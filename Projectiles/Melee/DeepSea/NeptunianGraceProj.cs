using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Melee.DeepSea
{
	public class NeptunianGraceProj : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.hide = true;
			projectile.scale = 0.95f;
		}
		
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) 
		{
			if (projectile.ai[0] == 1f)
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) 
				{
					if (Main.npc[npcIndex].behindTiles)
					{
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else drawCacheProjsBehindNPCs.Add(index);
					return;
				}
			}
			drawCacheProjsBehindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
		{
			width = height = 10;
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) 
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8) 
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft) 
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y); 
			Vector2 usePos = projectile.position;
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			for (int i = 0; i < 8; i++)
			{
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 172);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				dust.color = Color.Aqua;
				usePos -= rotVector * 8f;
			}
			
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14, 1f, 0f);
			projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 42;
			projectile.height = 42;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 100, default(Color), 1f);
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(6) * 0.1f;
				}
			}
			for (int j = 0; j < 8; j++)
			{
				int num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 2;
				num2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1f);
			}
			projectile.damage = 280;
			projectile.Damage();
		}

		public bool IsStickingToTarget 
		{
			get => projectile.ai[0] == 1f;
			set => projectile.ai[0] = value ? 1f : 0f;
		}

		public int TargetWhoAmI 
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		private const int maxJavs = 12;
		private readonly Point[] _stickingJavelins = new Point[maxJavs];

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) 
		{
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI;
			projectile.velocity = (target.Center - projectile.Center) * 0.75f; 
			projectile.netUpdate = true;
			projectile.damage = 0;
			UpdateStickyJavelins(target);
		}
		private void UpdateStickyJavelins(NPC target)
		{
			int currentJavelinIndex = 0;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI && currentProjectile.active && currentProjectile.owner == Main.myPlayer && currentProjectile.type == projectile.type && currentProjectile.modProjectile is TideStriderProj javelinProjectile && javelinProjectile.IsStickingToTarget && javelinProjectile.TargetWhoAmI == target.whoAmI) 
				{
					_stickingJavelins[currentJavelinIndex++] = new Point(i, currentProjectile.timeLeft); 
					if (currentJavelinIndex >= _stickingJavelins.Length)
						break;
				}
			}

			if (currentJavelinIndex >= maxJavs)
			{
				int oldJavelinIndex = 0;
				for (int i = 1; i < maxJavs; i++) 
				{
					if (_stickingJavelins[i].Y < _stickingJavelins[oldJavelinIndex].Y) {
						oldJavelinIndex = i;
					}
				}
				Main.projectile[_stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}
		
		private const int MAX_TICKS = 66;
		private const int ALPHA_REDUCTION = 30;

		public override void AI()
		{
			UpdateAlpha();
			if (IsStickingToTarget)
			{
				StickyAI();
			}
			else 
			{
				NormalAI();
			}
		}

		private void UpdateAlpha()
		{
			if (projectile.alpha > 0) 
			{
				projectile.alpha -= ALPHA_REDUCTION;
			}

			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
		}
		int tideTimer;
		private void NormalAI()
		{
			TargetWhoAmI++;
			if (TargetWhoAmI >= MAX_TICKS) 
			{
				const float velXmult = 0.9975f; 
				const float velYmult = 0.25f;
				TargetWhoAmI = MAX_TICKS;
				projectile.velocity.X *= velXmult;
				projectile.velocity.Y += velYmult;
			}
			tideTimer++;
			if(tideTimer == 1)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X / 20, projectile.velocity.Y / 20, mod.ProjectileType("NeptunianGraceTrail"), projectile.damage / 2, 0, projectile.owner, 0f, 0f);
				tideTimer = 0;
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); 

			if (Main.rand.NextBool(3)) 
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 172, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(8)) 
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 229, 0, 0, 254, Scale: 0.3f);
				dust.color = Color.Brown;
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}

		private void StickyAI()
		{
			projectile.ignoreWater = true;
			projectile.tileCollide = false; 
			const int aiFactor = 2;
			projectile.localAI[0] += 1f;

			bool hitEffect = projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200) 
			{
				projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) 
			{	
				projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
				projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect) 
				{
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else 
			{
				projectile.Kill();
			}
		}
	}
	
	public class NeptunianGraceTrail : ModProjectile
	{
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/BlankProj";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 50;
		}

		public override void AI()
		{
			if(Main.rand.Next(3) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
				Main.dust[num].scale = 1f;
				Main.dust[num].velocity /= 20;
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Aqua;
			}
			if(Main.rand.Next(6) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 30;
				Main.dust[num168].color = Color.Aqua;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
			float numberProjectiles = 2;	
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 vector = new Vector2(projectile.Center.X, projectile.Center.Y);
				float stuff = Main.rand.Next(-6, 6);
				Projectile.NewProjectile(vector.X, vector.Y, stuff, stuff, mod.ProjectileType("NeptunianGraceTrailSplit"), projectile.damage / 2, 2f, Main.myPlayer, 0f, 0f);
			}
		}
	}
	
	public class NeptunianGraceTrailSplit : ModProjectile
	{	
		public override string Texture
		{
			get
			{
				return "Archeon/Projectiles/BlankProj";
			}
		}
		
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
			projectile.melee = true;
			projectile.hide = true;
			projectile.timeLeft = 50;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 18f)
			{
				projectile.ai[0] = 18f;
				projectile.velocity.Y = projectile.velocity.Y + 0.38f;
			}
			if (projectile.velocity.Y > 19f)
			{
				projectile.velocity.Y = 19f;
			}
			float num2 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
			float num3 = projectile.localAI[0];
			if (num3 == 0f)
			{
				projectile.localAI[0] = num2;
				num3 = num2;
			}
			float num4 = projectile.position.X;
			float num5 = projectile.position.Y;
			float num6 = 300f;
			bool flag = false;
			int num7 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(i + 1)))
					{
						float num8 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
						float num9 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
						float num10 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num8) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num9);
						if (num10 < num6 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[i].position, Main.npc[i].width, Main.npc[i].height))
						{
							num6 = num10;
							num4 = num8;
							num5 = num9;
							flag = true;
							num7 = i;
						}
					}
				}
				if (flag)
				{
					projectile.ai[1] = (float)(num7 + 1);
				}
				flag = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num11 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num11].active && Main.npc[num11].CanBeChasedBy(this, true) && !Main.npc[num11].dontTakeDamage)
				{
					float num12 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
					float num13 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
					if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num12) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num13) < 1000f)
					{
						flag = true;
						num4 = Main.npc[num11].position.X + (float)(Main.npc[num11].width / 2);
						num5 = Main.npc[num11].position.Y + (float)(Main.npc[num11].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag = false;
			}
			if (flag)
			{
				float num14 = num3;
				Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num15 = num4 - vector.X;
				float num16 = num5 - vector.Y;
				float num17 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
				num17 = num14 / num17;
				num15 *= num17;
				num16 *= num17;
				int num18 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num18 - 1) + num15) / (float)num18;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num18 - 1) + num16) / (float)num18;	
			}
			
			if(Main.rand.Next(3) == 0)
			{
				int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 229, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.2f); 
				Main.dust[num].velocity /= 10;
				Main.dust[num].noGravity = true;
				Main.dust[num].color = Color.Aqua;
			}
			if(Main.rand.Next(5) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 172, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.1f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 20;
				Main.dust[num168].color = Color.Brown;
			}
		}
	}
}