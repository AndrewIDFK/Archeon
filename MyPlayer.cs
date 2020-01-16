using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;

namespace Archeon
{
	// Token: 0x02000006 RID: 6
	public class MyPlayer : ModPlayer
	{
		
		// Token: 0x06000027 RID: 39 RVA: 0x0000399F File Offset: 0x00001B9F
		public override void ResetEffects()
		{
			this.Pet = false;
			this.customdebuff = false;
			this.dashMod = 0;
			this.dodgeDash = false;
			this.dodgeDashDamage = false;
			
			this.StroidMinion = false;
			this.StroidWormer = false;
			
			this.FireNado = false;
			this.FrostNado = false;
			this.AirNado = false;
			this.EarthNado = false;
			
			this.DarkMatterTornado = false;
			
			this.PhantasmDragonMinion = false;
			
			//Armor
			this.ShadoniumHelmet2 = false;
			this.VyssoniumHelmet1 = false;
			this.VyssoniumHelmet2 = false;
			
			this.DefenseOrbAccessory = false;	
			this.DefOrbAcc = false;
			this.AttackOrbAccessory = false;
			this.AttOrbAcc = false;
			this.dodgeDashAcc = false;
			
			this.EmeraldCircleS = false;
			this.ECS = false;
			this.RubyCircleS = false;
			this.RCS = false;
			this.TopazCircleS = false;
			this.TCS = false;
		}
		
		public override void UpdateDead()
		{
			this.dodgeDashDamage = false;
		}
		
		public override void PostUpdateMiscEffects()
		{
			if (base.player.ownedProjectileCounts[base.mod.ProjectileType("DefenseOrbAccessory")] > 1)
			{
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].type == base.mod.ProjectileType("DefenseOrbAccessory"))
					{
						Main.projectile[i].Kill();
					}
				}
			}
			
			if (base.player.ownedProjectileCounts[base.mod.ProjectileType("AttackOrbAccessory")] > 1)
			{
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].type == base.mod.ProjectileType("AttackOrbAccessory"))
					{
						Main.projectile[i].Kill();
					}
				}
			}
			
			if (this.dodgeDashDamage)
			{
				base.player.statDefense /= 2;
			}
		}
		
		public override void OnHitByNPC(NPC target, int damage, bool crit)
		{
			if (this.dodgeDashDamage = true)
			{
				damage = (int)((double)damage * 2);
			}
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (base.player.whoAmI == Main.myPlayer)
			{
				if (this.ShadoniumHelmet2 && damage > 30)
				{
					base.player.immuneTime += 15;
					base.player.AddBuff(base.mod.BuffType("ShadoniumArmorSpeed"), 115, true);
				}
				if (this.VyssoniumHelmet2 && damage > 0)
				{
					
					base.player.AddBuff(base.mod.BuffType("VyssoniumArmorMeleeSpeed"), 240, true);
				}
			}
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (this.VyssoniumHelmet1)
			{
				if (Main.rand.Next(4) == 0)
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 225, false);
				}
				else if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (this.VyssoniumHelmet1)
			{
				if (Main.rand.Next(4) == 0)
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 225, false);
				}
				else if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(base.mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
		}
		
		public override void PostUpdateRunSpeeds()
		{
			if (base.player.pulley && this.dashMod > 0)
			{
				this.ModDashMovement();
				return;
			}
			if (base.player.grappling[0] == -1 && !base.player.tongued)
			{
				this.ModHorizontalMovement();
				if (this.dashMod > 0)
				{
					this.ModDashMovement();
				}
			}
		}
		
		public void ModDashMovement()
		{
			if (base.player.dashDelay > 0)
			{
				return;
			}
			
			if (this.dashMod == 1 && base.player.dashDelay < 0 && base.player.whoAmI == Main.myPlayer)
			{
				Rectangle rectangle5 = new Rectangle((int)((double)base.player.position.X + (double)base.player.velocity.X * 0.5 - 4.0), (int)((double)base.player.position.Y + (double)base.player.velocity.Y * 0.5 - 4.0), base.player.width + 8, base.player.height + 8);
				for (int m = 0; m < 200; m++)
				{
					if (Main.npc[m].active && !Main.npc[m].dontTakeDamage && !Main.npc[m].friendly && !Main.npc[m].townNPC && Main.npc[m].immune[base.player.whoAmI] <= 0 && Main.npc[m].damage > 0)
					{
						NPC npc5 = Main.npc[m];
						Rectangle rect5 = npc5.getRect();
						if (rectangle5.Intersects(rect5) && (npc5.noTileCollide || base.player.CanHit(npc5)))
						{
							this.OnDodge();
							break;
						}
					}
				}
				for (int n = 0; n < 1000; n++)
				{
					if (Main.projectile[n].active && !Main.projectile[n].friendly && Main.projectile[n].hostile && Main.projectile[n].damage > 0)
					{
						Rectangle rect6 = Main.projectile[n].getRect();
						if (rectangle5.Intersects(rect6))
						{
							this.OnDodge();
							break;
						}
					}
				}
			}
			if (base.player.dashDelay < 0)
			{
				float num12 = 14f;
				float num13 = 0.985f;
				float num14 = Math.Max(base.player.accRunSpeed, base.player.maxRunSpeed);
				float num15 = 0.94f;
				int dashDelay = 28;
				
				if (this.dashMod == 1)
				{
					for (int num16 = 0; num16 < 2; num16++)
					{
						int dustz;
						if (base.player.velocity.Y == 0f)
						{
							dustz = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + (float)base.player.height - 4f), base.player.width, 16, 235, 0f, 0f, 100, default(Color), 1.4f);
						}
						else
						{
							dustz = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + (float)(base.player.height / 2) - 8f), base.player.width, 8, 235, 0f, 0f, 100, default(Color), 1.4f);
						}
						Main.dust[dustz].velocity *= 0.1f;
						Main.dust[dustz].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[dustz].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
					}
				}
				
				if (this.dashMod == 3)
				{
					for (int num34 = 0; num34 < 24; num34++)
					{
						int num68 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + 4f), base.player.width, base.player.height - 8, mod.DustType("LunarDust2"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num68].velocity *= 0.1f;
						Main.dust[num68].scale *= 0.35f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num68].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
						Main.dust[num68].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num68].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}	
				
				if (this.dashMod == 4)
				{
					for (int num33 = 0; num33 < 24; num33++)
					{
						int num69 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + 4f), base.player.width, base.player.height - 8, mod.DustType("EverGladesDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num69].velocity *= 0.1f;
						Main.dust[num69].scale *= 0.35f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num69].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
						Main.dust[num69].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num69].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (this.dashMod == 5)
				{
					for (int num24 = 0; num24 < 24; num24++)
					{
						int num25 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + 4f), base.player.width, base.player.height - 8, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num25].velocity *= 0.1f;
						Main.dust[num25].scale *= 0.7f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num25].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
						Main.dust[num25].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num25].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (this.dashMod == 6)
				{
					for (int num24 = 0; num24 < 24; num24++)
					{
						int num25 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y + 4f), base.player.width, base.player.height - 8, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num25].velocity *= 0.1f;
						Main.dust[num25].scale *= 0.6f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num25].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
						Main.dust[num25].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num25].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (this.dashMod > 0)
				{
					base.player.vortexStealthActive = false;
					if (base.player.velocity.X > num12 || base.player.velocity.X < -num12)
					{
						base.player.velocity.X = base.player.velocity.X * num13;
						return;
					}
					if (base.player.velocity.X > num14 || base.player.velocity.X < -num14)
					{
						base.player.velocity.X = base.player.velocity.X * num15;
						return;
					}
					base.player.dashDelay = dashDelay;
					if (base.player.velocity.X < 0f)
					{
						base.player.velocity.X = -num14;
						return;
					}
					if (base.player.velocity.X > 0f)
					{
						base.player.velocity.X = num14;
						return;
					}
				}
			}
			else if (this.dashMod > 0 && !base.player.mount.Active)
			{
				
				if (this.dashMod == 1)
				{
					int num28 = 0;
					bool flag = false;
					if (this.dashTimeMod > 0)
					{
						this.dashTimeMod--;
					}
					if (this.dashTimeMod < 0)
					{
						this.dashTimeMod++;
					}
					if (base.player.controlRight && base.player.releaseRight)
					{
						if (this.dashTimeMod > 0)
						{
							num28 = 1;
							flag = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = 15;
						}
					}
					else if (base.player.controlLeft && base.player.releaseLeft)
					{
						if (this.dashTimeMod < 0)
						{
							num28 = -1;
							flag = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = -15;
						}
					}
					if (flag)
					{
						base.player.velocity.X = 14.5f * (float)num28;
						Point point = (base.player.Center + new Vector2((float)(num28 * base.player.width / 2 + 2), base.player.gravDir * -(float)base.player.height / 2f + base.player.gravDir * 2f)).ToTileCoordinates();
						Point point2 = (base.player.Center + new Vector2((float)(num28 * base.player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
						{
							base.player.velocity.X = base.player.velocity.X / 2f;
						}
						base.player.dashDelay = -1;
						for (int num29 = 0; num29 < 20; num29++)
						{
							int num30 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, 235, 0f, 0f, 100, default(Color), 2f);
							Dust dust = Main.dust[num30];
							dust.position.X = dust.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust2 = Main.dust[num30];
							dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-5, 6);
							Main.dust[num30].velocity *= 0.2f;
							Main.dust[num30].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num30].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
						}
						return;
					}
				}
				
				if (this.dashMod == 3)
				{
					int num20 = 0;
					bool flag3 = false;
					if (this.dashTimeMod > 0)
					{
						this.dashTimeMod--;
					}
					if (this.dashTimeMod < 0)
					{
						this.dashTimeMod++;
					}
					if (base.player.controlRight && base.player.releaseRight)
					{
						if (this.dashTimeMod > 0)
						{
							num20 = 1;
							flag3 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = 31;
						}
					}
					else if (base.player.controlLeft && base.player.releaseLeft)
					{
						if (this.dashTimeMod < 0)
						{
							num20 = -1;
							flag3 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = -31;
						}
					}
					if (flag3)
					{
						base.player.velocity.X = 26.9f * (float)num20;
						Point point14 = (base.player.Center + new Vector2((float)(num20 * base.player.width / 2 + 2), base.player.gravDir * -(float)base.player.height / 2f + base.player.gravDir * 2f)).ToTileCoordinates();
						Point point15 = (base.player.Center + new Vector2((float)(num20 * base.player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point14.X, point14.Y) || WorldGen.SolidOrSlopedTile(point15.X, point15.Y))
						{
							base.player.velocity.X = base.player.velocity.X / 2f;
						}
						base.player.dashDelay = -1;
						for (int num61 = 0; num61 < 70; num61++)
						{
							int num62 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, mod.DustType("LunarDust2"), 0f, 0f, 100, default(Color), 3f);
							Dust dust14 = Main.dust[num62];
							dust14.position.X = dust14.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust15 = Main.dust[num62];
							dust15.position.Y = dust15.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num62].velocity *= 0.2f;
							Main.dust[num62].scale *= 0.3f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num62].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
							Main.dust[num62].noGravity = true;
							Main.dust[num62].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (this.dashMod == 4)
				{
					int num30 = 0;
					bool flag4 = false;
					if (this.dashTimeMod > 0)
					{
						this.dashTimeMod--;
					}
					if (this.dashTimeMod < 0)
					{
						this.dashTimeMod++;
					}
					if (base.player.controlRight && base.player.releaseRight)
					{
						if (this.dashTimeMod > 0)
						{
							num30 = 1;
							flag4 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = 29;
						}
					}
					else if (base.player.controlLeft && base.player.releaseLeft)
					{
						if (this.dashTimeMod < 0)
						{
							num30 = -1;
							flag4 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = -29;
						}
					}
					if (flag4)
					{
						base.player.velocity.X = 26.9f * (float)num30;
						Point point19 = (base.player.Center + new Vector2((float)(num30 * base.player.width / 2 + 2), base.player.gravDir * -(float)base.player.height / 2f + base.player.gravDir * 2f)).ToTileCoordinates();
						Point point20 = (base.player.Center + new Vector2((float)(num30 * base.player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point19.X, point19.Y) || WorldGen.SolidOrSlopedTile(point20.X, point20.Y))
						{
							base.player.velocity.X = base.player.velocity.X / 2f;
						}
						base.player.dashDelay = -1;
						for (int num51 = 0; num51 < 70; num51++)
						{
							int num52 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, mod.DustType("EverGladesDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust19 = Main.dust[num52];
							dust19.position.X = dust19.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust20 = Main.dust[num52];
							dust20.position.Y = dust20.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num52].velocity *= 0.2f;
							Main.dust[num52].scale *= 0.3f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num52].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
							Main.dust[num52].noGravity = true;
							Main.dust[num52].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (this.dashMod == 5)
				{
					int num40 = 0;
					bool flag5 = false;
					if (this.dashTimeMod > 0)
					{
						this.dashTimeMod--;
					}
					if (this.dashTimeMod < 0)
					{
						this.dashTimeMod++;
					}
					if (base.player.controlRight && base.player.releaseRight)
					{
						if (this.dashTimeMod > 0)
						{
							num40 = 1;
							flag5 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = 25;
						}
					}
					else if (base.player.controlLeft && base.player.releaseLeft)
					{
						if (this.dashTimeMod < 0)
						{
							num40 = -1;
							flag5 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = -25;
						}
					}
					if (flag5)
					{
						base.player.velocity.X = 25.9f * (float)num40;
						Point point9 = (base.player.Center + new Vector2((float)(num40 * base.player.width / 2 + 2), base.player.gravDir * -(float)base.player.height / 2f + base.player.gravDir * 2f)).ToTileCoordinates();
						Point point10 = (base.player.Center + new Vector2((float)(num40 * base.player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point9.X, point9.Y) || WorldGen.SolidOrSlopedTile(point10.X, point10.Y))
						{
							base.player.velocity.X = base.player.velocity.X / 2f;
						}
						base.player.dashDelay = -1;
						for (int num41 = 0; num41 < 70; num41++)
						{
							int num42 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust9 = Main.dust[num42];
							dust9.position.X = dust9.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust10 = Main.dust[num42];
							dust10.position.Y = dust10.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num42].velocity *= 0.2f;
							Main.dust[num42].scale *= 0.8f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num42].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
							Main.dust[num42].noGravity = true;
							Main.dust[num42].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (this.dashMod == 6)
				{
					int num50 = 0;
					bool flag6 = false;
					if (this.dashTimeMod > 0)
					{
						this.dashTimeMod--;
					}
					if (this.dashTimeMod < 0)
					{
						this.dashTimeMod++;
					}
					if (player.altFunctionUse == 1 && player.direction == 1)
					{
						if (this.dashTimeMod > 0)
						{
							num50 = 1;
							flag6 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = 25;
						}
					}
					else if (player.altFunctionUse == 1 && player.direction == -1)
					{
						if (this.dashTimeMod < 0)
						{
							num50 = -1;
							flag6 = true;
							this.dashTimeMod = 0;
						}
						else
						{
							this.dashTimeMod = -25;
						}
					}
					if (flag6)
					{
						base.player.velocity.X = 25.9f * (float)num50;
						Point point11 = (base.player.Center + new Vector2((float)(num50 * base.player.width / 2 + 3), base.player.gravDir * -(float)base.player.height / 2f + base.player.gravDir * 2f)).ToTileCoordinates();
						Point point12 = (base.player.Center + new Vector2((float)(num50 * base.player.width / 2 + 3), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point11.X, point11.Y) || WorldGen.SolidOrSlopedTile(point12.X, point12.Y))
						{
							base.player.velocity.X = base.player.velocity.X / 2f;
						}
						base.player.dashDelay = -1;
						for (int num41 = 0; num41 < 70; num41++)
						{
							int num43 = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust11 = Main.dust[num43];
							dust11.position.X = dust11.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust12 = Main.dust[num43];
							dust12.position.Y = dust12.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num43].velocity *= 0.2f;
							Main.dust[num43].scale *= 0.45f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num43].shader = GameShaders.Armor.GetSecondaryShader(base.player.ArmorSetDye(), base.player);
							Main.dust[num43].noGravity = true;
							Main.dust[num43].fadeIn = 0.5f;
						}
						return;
					}
				}
			}
		}
		
		public void ModHorizontalMovement()
		{
			float num = (base.player.accRunSpeed + base.player.maxRunSpeed) / 2f;
			if (base.player.controlLeft && base.player.velocity.X > -base.player.accRunSpeed && base.player.dashDelay >= 0)
			{
				if (base.player.velocity.X < -num && base.player.velocity.Y == 0f && !base.player.mount.Active)
				{
					int num2 = 0;
					if (base.player.gravDir == -1f)
					{
						num2 -= base.player.height;
					}
					if (this.dashMod == 1)
					{
						int num3 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num2), base.player.width + 8, 4, 16, -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
						Main.dust[num3].velocity.X = Main.dust[num3].velocity.X * 0.2f;
						Main.dust[num3].velocity.Y = Main.dust[num3].velocity.Y * 0.2f;
						Main.dust[num3].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
						Main.dust[num3].scale *= 0.5f + (float)Main.rand.Next(10) * 0.01f;
					}
					if (this.dashMod == 3)
					{
						int num5 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num2), base.player.width + 2, 2, mod.DustType("LunarDust2"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num5].velocity.X = Main.dust[num5].velocity.X * 0.2f;
						Main.dust[num5].velocity.Y = Main.dust[num5].velocity.Y * 0.2f;
						Main.dust[num5].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
						Main.dust[num5].scale *= 0.45f + (float)Main.rand.Next(10) * 0.01f;
					}	
					if (this.dashMod == 4)
					{
						int num6 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num2), base.player.width + 2, 2, mod.DustType("EverGladesDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num6].velocity.X = Main.dust[num6].velocity.X * 0.2f;
						Main.dust[num6].velocity.Y = Main.dust[num6].velocity.Y * 0.2f;
						Main.dust[num6].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
						Main.dust[num6].scale *= 0.45f + (float)Main.rand.Next(10) * 0.01f;
					}			
					if (this.dashMod == 5)
					{
						int num7 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num2), base.player.width + 6, 4, mod.DustType("AllElementDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num7].velocity.X = Main.dust[num7].velocity.X * 0.2f;
						Main.dust[num7].velocity.Y = Main.dust[num7].velocity.Y * 0.2f;
						Main.dust[num7].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
					}
					if (this.dashMod == 6)
					{
						int num8 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num2), base.player.width + 6, 4, mod.DustType("AllElementDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.2f;
						Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.2f;
						Main.dust[num8].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
					}
				}
			}
			
			else if (base.player.controlRight && base.player.velocity.X < base.player.accRunSpeed && base.player.dashDelay >= 0 && base.player.velocity.X > num && base.player.velocity.Y == 0f && !base.player.mount.Active)
			{
				int num9 = 0;
				if (base.player.gravDir == -1f)
				{
					num9 -= base.player.height;
				}
				if (this.dashMod == 1)
				{
					int num10 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num9), base.player.width + 8, 4, 16, -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num10].velocity.X = Main.dust[num10].velocity.X * 0.2f;
					Main.dust[num10].velocity.Y = Main.dust[num10].velocity.Y * 0.2f;
					Main.dust[num10].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
					Main.dust[num10].scale *= 0.5f + (float)Main.rand.Next(10) * 0.01f;
				}
				if (this.dashMod == 3)
				{
					int num23 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num9), base.player.width + 2, 4, mod.DustType("LunarDust2"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num23].velocity.X = Main.dust[num23].velocity.X * 0.2f;
					Main.dust[num23].velocity.Y = Main.dust[num23].velocity.Y * 0.2f;
					Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
				}
				if (this.dashMod == 4)
				{
					int num24 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num9), base.player.width + 2, 4, mod.DustType("EverGladesDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num24].velocity.X = Main.dust[num24].velocity.X * 0.2f;
					Main.dust[num24].velocity.Y = Main.dust[num24].velocity.Y * 0.2f;
					Main.dust[num24].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
				}
				if (this.dashMod == 5)
				{
					int num14 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num9), base.player.width + 6, 4, mod.DustType("AllElementDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num14].velocity.X = Main.dust[num14].velocity.X * 0.2f;
					Main.dust[num14].velocity.Y = Main.dust[num14].velocity.Y * 0.2f;
					Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
				}
			}
			
			else if (player.altFunctionUse == 1 && base.player.velocity.X < base.player.accRunSpeed && base.player.dashDelay >= 0 && base.player.velocity.X > num && base.player.velocity.Y == 0f && !base.player.mount.Active)
			{
				int num10 = 0;
				if (base.player.gravDir == -1f)
				{
					num10 -= base.player.height;
				}
				if (this.dashMod == 6)
				{
					int num15 = Dust.NewDust(new Vector2(base.player.position.X - 4f, base.player.position.Y + (float)base.player.height + (float)num10), base.player.width + 6, 4, mod.DustType("AllElementDust"), -base.player.velocity.X * 0.5f, base.player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num15].velocity.X = Main.dust[num15].velocity.X * 0.2f;
					Main.dust[num15].velocity.Y = Main.dust[num15].velocity.Y * 0.2f;
					Main.dust[num15].shader = GameShaders.Armor.GetSecondaryShader(base.player.cShoe, base.player);
				}
			}
		}
		
		private void OnDodge()
		{
			if (base.player.whoAmI == Main.myPlayer && this.dodgeDashAcc && !this.dodgeDashDamage)
			{
				base.player.AddBuff(base.mod.BuffType("DodgeDashDamage"), 300, true);
				base.player.immune = true;
				base.player.immuneTime = 110;
				if (base.player.longInvince)
				{
					base.player.immuneTime += 80;
				}
				for (int i = 0; i < base.player.hurtCooldowns.Length; i++)
				{
					base.player.hurtCooldowns[i] = base.player.immuneTime;
				}
				for (int j = 0; j < 100; j++)
				{
					int num = Dust.NewDust(new Vector2(base.player.position.X, base.player.position.Y), base.player.width, base.player.height, mod.DustType("StroidDust2"), 0f, 0f, 100, default(Color), 2f);
					Dust dust = Main.dust[num];
					dust.position.X = dust.position.X + (float)Main.rand.Next(-20, 21);
					Dust dust2 = Main.dust[num];
					dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-20, 21);
					Main.dust[num].velocity *= 0.4f;
					Main.dust[num].scale *= 0.6f + (float)Main.rand.Next(40) * 0.01f;
					Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(base.player.cWaist, base.player);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
						Main.dust[num].noGravity = true;
					}
				}
				if (base.player.whoAmI == Main.myPlayer)
				{
					NetMessage.SendData(62, -1, -1, null, base.player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		
		

		// Token: 0x06000028 RID: 40 RVA: 0x000039C4 File Offset: 0x00001BC4
		public override void UpdateBiomes()
		{
			this.zoneStroidBiome = (ArcheonWorld.StroidBiome > 20);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000039D8 File Offset: 0x00001BD8
		public override bool CustomBiomesMatch(Player other)
		{
			MyPlayer modPlayer = other.GetModPlayer<MyPlayer>();
			return this.zoneStroidBiome == modPlayer.zoneStroidBiome;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000039FC File Offset: 0x00001BFC
		public override void CopyCustomBiomesTo(Player other)
		{
			MyPlayer modPlayer = other.GetModPlayer<MyPlayer>();
			modPlayer.zoneStroidBiome = this.zoneStroidBiome;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003A1C File Offset: 0x00001C1C
		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = default(BitsByte);
			flags[0] = this.zoneStroidBiome;
			writer.Write(flags);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003A4C File Offset: 0x00001C4C
		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			zoneStroidBiome = flags[0];
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003A74 File Offset: 0x00001C74
		public void Send(int toWho, int fromWho)
		{
			ModPacket packet = base.mod.GetPacket(256);
			if (Main.netMode == 2)
			{
				packet.Write(fromWho);
			}
			packet.Write(this.someVal);
			packet.Write(this.someInt);
			packet.Send(toWho, fromWho);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003AC4 File Offset: 0x00001CC4
		public void Receive(BinaryReader reader, int fromWho)
		{
			if (Main.netMode == 1)
			{
				fromWho = reader.ReadInt32();
			}
			this.someVal = reader.ReadSingle();
			this.someInt = reader.ReadInt32();
			if (Main.netMode == 2)
			{
				this.Send(-1, fromWho);
				return;
			}
			MyPlayer modPlayer = Main.player[fromWho].GetModPlayer<MyPlayer>();
			modPlayer.someVal = this.someVal;
			modPlayer.someInt = this.someInt;
		}

		private const int saveVersion = 0;

		public bool Pet;

		public static bool hasProjectile;

		public bool zoneStroidBiome;

		public bool customdebuff;
		
		public int dashMod;
		
		public int dashTimeMod;
		
		public bool dodgeDash;
		
		public bool dodgeDashDamage;

		public bool StroidMinion;

		public bool StroidWormer;
		
		public bool FireNado;
		
		public bool FrostNado;
		
		public bool AirNado;
		
		public bool EarthNado;
		
		public bool DarkMatterTornado;

		public bool PhantasmDragonMinion;
		
		public bool ShadoniumHelmet2;
		
		public bool VyssoniumHelmet1;
		
		public bool VyssoniumHelmet2;
		
		public bool DefenseOrbAccessory;
		
		public bool DefOrbAcc;
		
		public bool AttackOrbAccessory;
		
		public bool AttOrbAcc;
		
		public bool EmeraldCircleS;
		
		public bool RubyCircleS;
		
		public bool TopazCircleS;
		
		public bool ECS;
		
		public bool RCS;
		
		public bool TCS;
		
		private float someVal;

		private int someInt;
		
		public bool dodgeDashAcc;
	}
}
