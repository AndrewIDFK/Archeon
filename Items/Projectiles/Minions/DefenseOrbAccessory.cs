using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Archeon.Items.Projectiles.Minions
{
	public class DefenseOrbAccessory : ModProjectile
	{
		private int Timer = 500;
		
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("The Orb of Defense");
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
			bool flag = base.projectile.type == base.mod.ProjectileType("DefenseOrbAccessory");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (!modPlayer.DefenseOrbAccessory)
			{
				base.projectile.active = false;
				return;
			}
			
			/*int numxd = Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("DefenseOrbDust"), base.projectile.velocity.X * 2f, base.projectile.velocity.Y * 2f, 100, default(Color), 1.4f);
			Main.dust[numxd].velocity /= 50f;
			Main.dust[numxd].scale = 1.2f;
			Main.dust[numxd].noGravity = true;
			Main.dust[numxd].fadeIn = 1.2f;*/
			
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
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, base.mod.ProjectileType("DefenseOrbAccessoryHeal"), 0, 0f, base.projectile.owner, (float)owner);
			
				this.Timer = Main.rand.Next(850, 950);
			}
			
			if (base.projectile.position.Y > player.position.Y - 130f)
			{
				if (base.projectile.velocity.Y > 0f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y * 1.01f;
				}
				base.projectile.velocity.Y = base.projectile.velocity.Y - 0.1f;
				if (base.projectile.velocity.Y > 2f)
				{
					base.projectile.velocity.Y = 2f;
				}
			}
			else if (base.projectile.position.Y < player.position.Y - 390f)
			{
				if (base.projectile.velocity.Y < 0f)
				{
					base.projectile.velocity.Y = base.projectile.velocity.Y * 1.01f;
				}
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.1f;
				if (base.projectile.velocity.Y < -2f)
				{
					base.projectile.velocity.Y = -2f;
				}
			}
			if (base.projectile.position.X + (float)(base.projectile.width / 2) > player.position.X + (float)(player.width / 2) + 50f)
			{
				if (base.projectile.velocity.X > 0f)
				{
					base.projectile.velocity.X = base.projectile.velocity.X * 0.49f;
				}
				base.projectile.velocity.X = base.projectile.velocity.X - 0.1f;
				if (base.projectile.velocity.X > 2f)
				{
					base.projectile.velocity.X = 2f;
				}
			}
			if (base.projectile.position.X + (float)(base.projectile.width / 2) < player.position.X + (float)(player.width / 2) - 50f)
			{
				if (base.projectile.velocity.X < 0f)
				{
					base.projectile.velocity.X = base.projectile.velocity.X * 0.46f;
				}
				base.projectile.velocity.X = base.projectile.velocity.X + 0.1f;
				if (base.projectile.velocity.X < -2f)
				{
					base.projectile.velocity.X = -2f;
				}
			}
			if (base.projectile.localAI[0] == 0f)
			{
				int num = 35;
				for (int i = 0; i < num; i++)
				{
					Vector2 value = (Vector2.Normalize(base.projectile.velocity) * new Vector2((float)base.projectile.width / 2f, (float)base.projectile.height) * 0.75f).RotatedBy((double)((float)(i - (num / 2 - 1)) * 6.28318548f / (float)num), default(Vector2)) + base.projectile.Center;
					Vector2 vector = value - base.projectile.Center;
					int num2 = Dust.NewDust(value + vector, 0, 0, mod.DustType("DefenseOrbDust"), vector.X * 1.5f, vector.Y * 1.5f, 100, default(Color), 1.4f);
					Main.dust[num2].noGravity = true;
					Main.dust[num2].noLight = true;
					Main.dust[num2].velocity = vector;
				}
				base.projectile.localAI[0] += 1f;
			}
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, mod.DustType("DefenseOrbDust"), base.projectile.velocity.X * 0.05f, base.projectile.velocity.Y * 0.05f, 0, default(Color), 1f);
			}
		}
	}
}
