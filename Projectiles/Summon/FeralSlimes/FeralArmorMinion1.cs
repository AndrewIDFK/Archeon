using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Archeon.Projectiles.Summon.FeralSlimes
{
	public class FeralArmorMinion1 : FeralArmorMinionAI
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poisonous Slime");
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(266);
			this.aiType = 266;
			projectile.width = 36;
			projectile.height = 26;
			Main.projFrames[projectile.type] = 6;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.netImportant = true;
			projectile.minionSlots = 0f;
			projectile.penetrate = -1;
			projectile.timeLeft = 2;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.LightPet[projectile.type] = false;
			Main.projPet[projectile.type] = true;
		}

		public override void AI()
		{
			projectile.damage = 45;
			bool flag = projectile.type == mod.ProjectileType("FeralArmorMinion1");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (!modPlayer.feralSlimes)
			{
				projectile.active = false;
				return;
			}
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.feralSlimes = false;
				}
				if (modPlayer.feralSlimes)
				{
					projectile.timeLeft = 2;
				}
			}
		}

		public override void CreateDust()
		{
			if (projectile.ai[0] == 0f)
			{
				if (Utils.NextBool(Main.rand, 5))
				{
					int num = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 207, 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.Y = dust.velocity.Y - 1f;
				}
			}
			else if (Utils.NextBool(Main.rand, 3))
			{
				Vector2 velocity = projectile.velocity;
				if (velocity != Vector2.Zero)
				{
					velocity.Normalize();
				}
				int num2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 207, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num2].velocity -= 1f * velocity;
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.75f, 0.15f, 0.2f);
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
		}
	}
}
