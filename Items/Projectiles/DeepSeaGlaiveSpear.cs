using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Archeon.Items.Projectiles
{
	// Token: 0x02000052 RID: 82
	public class DeepSeaGlaiveSpear : ModProjectile
	{
		// Token: 0x06000165 RID: 357 RVA: 0x0000A1F4 File Offset: 0x000083F4
		public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.aiStyle = 19;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.ownerHitCheck = true;
			base.projectile.melee = true;
			base.projectile.timeLeft = 85;
			base.projectile.hide = true;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000166 RID: 358 RVA: 0x0000A27D File Offset: 0x0000847D
		// (set) Token: 0x06000167 RID: 359 RVA: 0x0000A28C File Offset: 0x0000848C
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

		// Token: 0x06000168 RID: 360 RVA: 0x0000A29C File Offset: 0x0000849C
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
					this.movementFactor = 1.2f;
					base.projectile.netUpdate = true;
				}
				if (player.itemAnimation < player.itemAnimationMax / 4)
				{
					this.movementFactor -= 1f;
				}
				else
				{
					this.movementFactor += 1f;
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
			if (Utils.NextBool(Main.rand, 8))
			{
				Dust dust = Dust.NewDustDirect(base.projectile.position, base.projectile.height, base.projectile.width, 15, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 77, default(Color), 0.55f);
				dust.velocity += base.projectile.velocity * 0.3f;
				dust.velocity *= 0.2f;
			}
			if (Utils.NextBool(Main.rand, 7))
			{
				Dust dust2 = Dust.NewDustDirect(base.projectile.position, base.projectile.height, base.projectile.width, 15, 0f, 0f, 77, default(Color), 0.3f);
				dust2.velocity += base.projectile.velocity * 0.5f;
				dust2.velocity *= 0.5f;
			}
		}
	}
}
