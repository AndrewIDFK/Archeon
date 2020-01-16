using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x02000078 RID: 120
	public class StroidMinion : StroidMinionInfo
	{
		// Token: 0x06000214 RID: 532 RVA: 0x00012C10 File Offset: 0x00010E10
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Baby Stroider");
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00012C34 File Offset: 0x00010E34
		public override void SetDefaults()
		{
			base.projectile.netImportant = true;
			base.projectile.CloneDefaults(266);
			this.aiType = 266;
			base.projectile.width = 36;
			base.projectile.height = 26;
			Main.projFrames[base.projectile.type] = 6;
			base.projectile.friendly = true;
			Main.projPet[base.projectile.type] = true;
			base.projectile.minion = true;
			base.projectile.netImportant = true;
			base.projectile.minionSlots = 1f;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 9999999;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.Homing[base.projectile.type] = true;
			this.inertia = 34f;
			this.shoot = base.mod.ProjectileType("StroidKalonShot");
			this.shootSpeed = 13f;
			ProjectileID.Sets.LightPet[base.projectile.type] = true;
			Main.projPet[base.projectile.type] = true;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00012D84 File Offset: 0x00010F84
		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
			{
				modPlayer.StroidMinion = false;
			}
			if (modPlayer.StroidMinion)
			{
				base.projectile.timeLeft = 2;
			}
		}
		public override void AI()
		{
			bool flag2 = base.projectile.type == base.mod.ProjectileType("StroidMinion");
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			player.AddBuff(base.mod.BuffType("BabyStroidBuff"), 3600, true);
			if (flag2)
			{
				if (player.dead)
				{
					modPlayer.StroidMinion = false;
				}
				if (modPlayer.StroidMinion)
				{
					base.projectile.timeLeft = 2;
				}
			}
		}
		// Token: 0x06000217 RID: 535 RVA: 0x00012DE0 File Offset: 0x00010FE0
		public override void CreateDust()
		{
			if (base.projectile.ai[0] == 0f)
			{
				if (Utils.NextBool(Main.rand, 5))
				{
					int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height / 2, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 0, default(Color), 1f);
					Dust dust = Main.dust[num];
					dust.velocity.Y = dust.velocity.Y - 1f;
				}
			}
			else if (Utils.NextBool(Main.rand, 3))
			{
				Vector2 velocity = base.projectile.velocity;
				if (velocity != Vector2.Zero)
				{
					velocity.Normalize();
				}
				int num2 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, base.mod.DustType("StroidWormDeathDust"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[num2].velocity -= 1f * velocity;
			}
			Lighting.AddLight((int)(base.projectile.Center.X / 16f), (int)(base.projectile.Center.Y / 16f), 0.6f, 0.9f, 1.3f);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00012F70 File Offset: 0x00011170
		public override void SelectFrame()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter >= 6)
			{
				base.projectile.frameCounter = 0;
				base.projectile.frame = (base.projectile.frame + 1) % 3;
			}
		}
	}
}
