using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000064 RID: 100
	public class RockSteeleYoyoShot : ModProjectile
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000F360 File Offset: 0x0000D560
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 0;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 99;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			ProjectileID.Sets.YoyosLifeTimeMultiplier[base.projectile.type] = 8.5f;
			ProjectileID.Sets.YoyosMaximumRange[base.projectile.type] = 280f;
			ProjectileID.Sets.YoyosTopSpeed[base.projectile.type] = 15.5f;
		}
		
		public override void AI()
		{
			/*if (Main.rand.Next(1, 51) == 1)
			{
				switch (Main.rand.Next(1, 9))
				{
				case 1:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 1f, -8f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, 1.2f, 0.2f);
					return;
				case 2:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 4f, -6f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, 0.7f, 0.7f);
					return;
				case 3:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 9f, -1f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, 0.2f, 1.2f);
					return;
				case 4:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 5.5f, 5f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, -0.7f, 0.7f);
					return;
				case 5:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 1f, 9.4f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, -1.2f, -0.2f);
					return;
				case 6:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -2f, 6f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, -0.7f, -0.7f);
					return;
				case 7:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -7f, 2f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, -0.2f, -1.2f);
					return;
				case 8:
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -6f, -7f, base.mod.ProjectileType("RockSteeleYoyoShard"), 4, 0f, base.projectile.owner, 0.7f, -0.7f);
					break;
				default:
					return;
				}
			}*/
		}
	}
}
