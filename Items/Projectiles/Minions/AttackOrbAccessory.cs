using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.Items.Projectiles.Minions
{
	public class AttackOrbAccessory : ModProjectile
	{
		private int Timer = 300;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Attack");
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
		}

		public override void SetDefaults()
		{
			base.projectile.width = 36;
			base.projectile.height = 36;
			base.projectile.tileCollide = false;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 8;
			base.projectile.timeLeft = 666666;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft *= 6;
			//projectile.scale = 0.98f;
		}
		
		
		
		public override void AI()
		{
			bool flag = base.projectile.type == base.mod.ProjectileType("AttackOrbAccessory");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (!modPlayer.AttackOrbAccessory)
			{
				base.projectile.active = false;
				return;
			}
			
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.DefOrbAcc = false;
				}
				if (modPlayer.DefOrbAcc)
				{
					base.projectile.timeLeft = 2;
				}
			}
			
			this.Timer--;
			if (this.Timer <= Main.rand.Next(25, 50))
			{
				int owner = base.projectile.owner;
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, base.mod.ProjectileType("AttackOrbAccessoryHeal"), 0, 0f, base.projectile.owner, (float)owner);
			
				this.Timer = Main.rand.Next(850, 950);
			}
			
			if (base.projectile.position.Y > player.position.Y - 110f)
			{
				if (base.projectile.velocity.Y > 0f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y * 0.97f;
				}
				base.projectile.velocity.Y = base.projectile.velocity.Y - 0.1f;
				if (base.projectile.velocity.Y > 4f)
				{
					base.projectile.velocity.Y = 4f;
				}
			}
			else if (base.projectile.position.Y < player.position.Y - 370f)
			{
				if (base.projectile.velocity.Y < 0f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y * 0.97f;
				}
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.1f;
				if (base.projectile.velocity.Y < -4f)
				{
					base.projectile.velocity.Y = -4f;
				}
			}
			if (base.projectile.position.X + (float)(base.projectile.width / 2) > player.position.X + (float)(player.width / 2) + 30f)
			{
				if (base.projectile.velocity.X > 0f)
				{
					base.projectile.velocity.X = base.projectile.velocity.X * 0.56f;
				}
				base.projectile.velocity.X = base.projectile.velocity.X - 0.1f;
				if (base.projectile.velocity.X > 4f)
				{
					base.projectile.velocity.X = 4f;
				}
			}
			if (base.projectile.position.X + (float)(base.projectile.width / 2) < player.position.X + (float)(player.width / 2) - 30f)
			{
				if (base.projectile.velocity.X < 0f)
				{
					base.projectile.velocity.X = base.projectile.velocity.X * 0.56f;
				}
				base.projectile.velocity.X = base.projectile.velocity.X + 0.1f;
				if (base.projectile.velocity.X < -4f)
				{
					base.projectile.velocity.X = -4f;
				}
			}

			if (base.projectile.localAI[0] == 0f)
			{
				int num = 35;
				for (int i = 0; i < num; i++)
				{
					Vector2 value = (Vector2.Normalize(base.projectile.velocity) * new Vector2((float)base.projectile.width / 2f, (float)base.projectile.height) * 0.75f).RotatedBy((double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.projectile.Center;
					Vector2 vector = value - base.projectile.Center;
					int num2 = Dust.NewDust(value + vector, 0, 0, mod.DustType("AttackOrbDust"), vector.X * 1.5f, vector.Y * 1.5f, 100, default(Color), 1.35f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector;
				}
				base.projectile.localAI[0] += 1f;
			}
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("AttackOrbDust"), base.projectile.velocity.X * 0.05f, base.projectile.velocity.Y * 0.05f, 0, default(Color), 1f);
			}
			
			this.Timer--;
			if (this.Timer <= Main.rand.Next(50, 100))
			{
				
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("AttackOrbAccShot"), 35, 6f, 255, 0f, 0f);
				
				this.Timer = Main.rand.Next(400, 500);
			}
		}
	}
}
