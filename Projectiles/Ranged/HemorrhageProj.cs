using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Ranged
{
	public class HemorrhageProj : ModProjectile
	{
		public override void SetDefaults() 
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 7;
			projectile.hide = true;
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
			width = height = 12;
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
			
			projectile.damage = 25;
			projectile.Damage();
			
			for (int i = 0; i < 4; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 125, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].noLight = true;
				Main.dust[num].color = Color.Red;
				Main.dust[num].noGravity = true;
				Main.dust[num].scale = 0.95f;
			}
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

		private const int maxFleshies = 4;
		private readonly Point[] _stickingFleshies = new Point[maxFleshies];

		bool onceDone = false;
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) 
		{
			if(onceDone == false)
			{
				IsStickingToTarget = true; 
				TargetWhoAmI = target.whoAmI;
				projectile.velocity = (target.Center - projectile.Center) * 0.75f; 
				projectile.netUpdate = true;
				UpdateStickyFleshies(target);
				onceDone = true;
			}
			projectile.damage = 0;
		}
		private void UpdateStickyFleshies(NPC target)
		{
			int currentFleshyIndex = 0;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI && currentProjectile.active && currentProjectile.owner == Main.myPlayer && currentProjectile.type == projectile.type && currentProjectile.modProjectile is HemorrhageProj FleshyProjectile && FleshyProjectile.IsStickingToTarget && FleshyProjectile.TargetWhoAmI == target.whoAmI) 
				{
					_stickingFleshies[currentFleshyIndex++] = new Point(i, currentProjectile.timeLeft); 
					if (currentFleshyIndex >= _stickingFleshies.Length)
						break;
				}
			}

			if (currentFleshyIndex >= maxFleshies)
			{
				int oldFleshyIndex = 0;
				for (int i = 1; i < maxFleshies; i++) 
				{
					if (_stickingFleshies[i].Y < _stickingFleshies[oldFleshyIndex].Y) {
						oldFleshyIndex = i;
					}
				}
				Main.projectile[_stickingFleshies[oldFleshyIndex].X].Kill();
			}
		}
		
		private const int ALPHA_REDUCTION = 15;

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
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); 

			if (Main.rand.NextBool(13)) 
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 125, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 100, Scale: 1.2f);
				dust.velocity += projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Main.rand.NextBool(17)) 
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 125, 0, 0, 154, Scale: 0.3f);
				dust.velocity += projectile.velocity * 0.5f;
				dust.velocity *= 0.5f;
			}
		}
		
		int alphaTimer;
		private void StickyAI()
		{
			projectile.ignoreWater = true;
			projectile.tileCollide = false; 
			const int aiFactor = 2;
			projectile.localAI[0] += 1f;
			alphaTimer++;
			if(alphaTimer <= 30)
			{
				projectile.scale += 0.0025f;
			}			
			if (alphaTimer > 30 && alphaTimer <= 61)
			{
				projectile.scale -= 0.0025f;
			}
			if(alphaTimer >= 62)
			{
				alphaTimer = 0;
			}		
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
					projectile.damage = 25;
					projectile.Damage();
				}
			}
			else 
			{
				projectile.Kill();
			}
		}
	}
}