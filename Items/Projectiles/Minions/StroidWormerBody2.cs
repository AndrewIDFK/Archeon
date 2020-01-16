using System;
using Terraria;
using Terraria.ID;

namespace Archeon.Items.Projectiles.Minions
{
	// Token: 0x0200007B RID: 123
	public class StroidWormerBody2 : StroidWormerAI
	{
		// Token: 0x0600022D RID: 557 RVA: 0x000144B6 File Offset: 0x000126B6
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stroid Eel Body 2");
		}

		// Token: 0x0600022E RID: 558 RVA: 0x000144C8 File Offset: 0x000126C8
		public override void CheckActive()
		{
			Player player = Main.player[base.projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.dead)
			{
				modPlayer.StroidWormer = false;
			}
			if (modPlayer.StroidWormer)
			{
				base.projectile.timeLeft = 2;
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00014518 File Offset: 0x00012718
		public override void SetDefaults()
		{
			base.projectile.width = 24;
			base.projectile.height = 32;
			Main.projFrames[base.projectile.type] = 1;
			base.projectile.friendly = true;
			Main.projPet[base.projectile.type] = true;
			base.projectile.minion = true;
			base.projectile.minionSlots = 0.5f;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 18000;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.Homing[base.projectile.type] = true;
			this.aiType = 121;
			base.projectile.scale = 1.05f;
			base.projectile.damage = 65;
			base.projectile.alpha = 0;
			this.inertia = 1f;
			ProjectileID.Sets.NeedsUUID[base.mod.ProjectileType("StroidWormerBody2")] = true;
			ProjectileID.Sets.StardustDragon[base.mod.ProjectileType("StroidWormerBody2")] = true;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0001464D File Offset: 0x0001284D
		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}
