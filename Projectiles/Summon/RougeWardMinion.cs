using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Projectiles.Summon
{
	public class RougeWardMinion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Guard");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 48;
			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.minion = true;
			projectile.minionSlots = 0.5f;
			projectile.timeLeft = 18000;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.timeLeft *= 5;
			projectile.alpha = 30;
		}
		
		int alphaTimer;
		int shootTimer;
		public override void AI()
		{	
			bool flag = projectile.type == mod.ProjectileType("RougeWardMinion");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			player.AddBuff(mod.BuffType("RougeWardMinionBuff"), 3600, true);
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.rougeWard = false;
				}
				if (modPlayer.rougeWard)
				{
					projectile.timeLeft = 2;
				}
			}
			
			if (projectile.ai[0] == 0f)
			{
				if (Utils.NextBool(Main.rand, 6))
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 105, 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.Y = dust.velocity.Y - 1f;
				}
			}
			else if (Utils.NextBool(Main.rand, 13))
			{
				Vector2 velocity = projectile.velocity;
				if (velocity != Vector2.Zero)
				{
					velocity.Normalize();
				}
				int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 105, 0f, 0f, 0, Color.Crimson, 1f);
				Main.dust[num2].velocity -= 1f * velocity;
			}
			alphaTimer++;
			if(alphaTimer <= 30)
			{
				projectile.alpha += 2;
				projectile.scale += 0.001f;
			}			
			if (alphaTimer > 30 && alphaTimer <= 61)
			{
				projectile.alpha -= 2;
				projectile.scale -= 0.001f;
			}
			if(alphaTimer >= 62)
			{
				alphaTimer = 0;
				projectile.alpha = 30;
				projectile.scale = 1;
			}	
			Vector2 idlePosition = player.Center;
			if (player.ownedProjectileCounts[mod.ProjectileType("PenumbraWardMinion")] == 1)
			{
				idlePosition.X = player.Center.X - 42;
				idlePosition.Y = player.Center.Y - 78;
			}
			else
			{
				idlePosition.X = player.Center.X - 12;
				idlePosition.Y = player.Center.Y - 78;
			}
			float distanceToIdlePosition = (idlePosition - projectile.Center).Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}
			projectile.position = idlePosition;
			
			shootTimer += 1;
			for (int i = 0; i < 200; i++)
			{
				NPC npc = Main.npc[i];
				float num2 = npc.position.X + (float)npc.width * 0.5f - projectile.Center.X;
				float num3 = npc.position.Y - projectile.Center.Y;
				float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
				if (num4 < 675f && !npc.friendly && npc.active && shootTimer > 88)
				{
					num4 = 3f / num4;
					num2 *= num4 * 5f;
					num3 *= num4 * 5f;
					int num5 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, num2 * 2f, num3 * 2f, mod.ProjectileType("RougeWardProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
					Main.projectile[num5].timeLeft = 150;
					Main.projectile[num5].netUpdate = true;
					projectile.netUpdate = true;
					shootTimer = 0;
				}
			}
		}
		
		public override bool CanDamage()
		{
			return false;
		}
	}
	
	public class RougeWardProj : ModProjectile
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
			projectile.minion = true;
			projectile.ignoreWater = true;
			projectile.timeLeft = 240;
		}

		public override void AI()
		{
			int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 114, projectile.velocity.X / 2, projectile.velocity.Y / 2, 100, default(Color), 1.4f);
			Main.dust[num].noGravity = true;
			Main.dust[num].velocity /= 3;
			Main.dust[num].color = Color.Crimson;
			
			if(Main.rand.Next(1) == 0)
			{
				int num168 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 90, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num168].noGravity = true;
				Main.dust[num168].velocity /= 1.5f;
				Main.dust[num168].color = Color.Red;
			}
		}
		
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}
