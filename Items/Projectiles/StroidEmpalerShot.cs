using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000068 RID: 104
	public class StroidEmpalerShot : ModProjectile
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x0000F79C File Offset: 0x0000D99C
		public override void SetDefaults()
		{
			base.projectile.width = 46;
			base.projectile.height = 46;
			base.projectile.aiStyle = 19;
			base.projectile.scale = 1.15f;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.ownerHitCheck = true;
			base.projectile.melee = true;
			base.projectile.timeLeft = 120;
			base.projectile.hide = true;
			base.projectile.alpha = 0;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000F841 File Offset: 0x0000DA41
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000F850 File Offset: 0x0000DA50
		public float movementFactor
		{
			get
			{
				return base.projectile.ai[0];
			}
			set
			{
				base.projectile.ai[0] = value;
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x0000F860 File Offset: 0x0000DA60
		public override void AI()
		{
			Player player = Main.player[base.projectile.owner];
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			base.projectile.direction = player.direction;
			player.heldProj = base.projectile.whoAmI;
			player.itemTime = player.itemAnimation;
			base.projectile.position.X = vector.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = vector.Y - (float)(base.projectile.height / 2);
			if (!player.frozen)
			{
				if (this.movementFactor == 0f)
				{
					this.movementFactor = 2.8f;
					base.projectile.netUpdate = true;
				}
				if (player.itemAnimation < player.itemAnimationMax / 5)
				{
					this.movementFactor -= 2.5f;
				}
				else
				{
					this.movementFactor += 1.8f;
				}
			}
			base.projectile.position += base.projectile.velocity * this.movementFactor;
			if (player.itemAnimation == 0)
			{
				base.projectile.Kill();
			}
			base.projectile.rotation = Utils.ToRotation(base.projectile.velocity) + MathHelper.ToRadians(135f);
			if (base.projectile.spriteDirection == -1)
			{
				base.projectile.rotation -= MathHelper.ToRadians(90f);
			}
			if (Utils.NextBool(Main.rand, 3))
			{
				Dust dust = Dust.NewDustDirect(base.projectile.position, base.projectile.height, base.projectile.width, 88, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 88, default(Color), 1.2f);
				dust.velocity += base.projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Utils.NextBool(Main.rand, 4))
			{
				Dust dust2 = Dust.NewDustDirect(base.projectile.position, base.projectile.height, base.projectile.width, 88, 0f, 0f, 88, default(Color), 0.3f);
				dust2.velocity += base.projectile.velocity * 0.5f;
				dust2.velocity *= 0.5f;
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000FB3A File Offset: 0x0000DD3A
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(base.mod.BuffType("CosmicalPoisoning"), 600, false);
		}
	}
}
