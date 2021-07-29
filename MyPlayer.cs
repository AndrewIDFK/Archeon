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
	public class MyPlayer : ModPlayer
	{
		public override void ResetEffects()
		{
			Pet = false;
			customdebuff = false;
			dashMod = 0;
			dodgeDash = false;
			dodgeDashDamage = false;
			
			StroidMinion = false;
			StroidWormer = false;
			
			DarkMatterTornado = false;
			
			PhantasmDragonMinion = false;
			
			//Armor
			ShadoniumHelmet2 = false;
			VyssoniumHelmet1 = false;
			VyssoniumHelmet2 = false;

			dodgeDashAcc = false;
			
			feralArmorDebuffs = false;
			feralSlimes = false;
			penumbraWard = false;
			rougeWard = false;
			MarkOfCain = false;
		}
		
		public override void UpdateDead()
		{
			dodgeDashDamage = false;
		}
		int MOCHurt = 500;
		public override void PostUpdateMiscEffects()
		{			
			if (dodgeDashDamage)
			{
				player.statDefense /= 2;
			}

			if(MarkOfCain)
			{
				MOCHurt++;
				if(MOCHurt < 500)
				{
					player.AddBuff(mod.BuffType("MarkOfCainBuff"), 1, true);
					player.meleeDamage = player.meleeDamage * 1.15f;
					player.meleeSpeed = player.meleeSpeed * 1.15f;
				}
				else
				{
					player.AddBuff(mod.BuffType("MarkOfCainDebuff"), 1, true);
					player.bleed = true;
					player.meleeDamage -= 0.051f;
					player.meleeSpeed -= 0.051f;
					player.statDefense -= 4;
					player.moveSpeed -= 0.1f;
					player.onFire2 = true;
					player.blackout = true;
				}
				if(MOCHurt >= 1000)
				{
					MOCHurt = 1000;
				}
				if(MOCHurt <= 0)
				{
					MOCHurt = 0;
				}
			}
		}
		
		public override void OnHitByNPC(NPC target, int damage, bool crit)
		{
			if (dodgeDashDamage = true)
			{
				damage = (int)((double)damage * 2);
			}
		}
		
		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				if (ShadoniumHelmet2 && damage > 30)
				{
					player.immuneTime += 15;
					player.AddBuff(mod.BuffType("ShadoniumArmorSpeed"), 115, true);
				}
				if (VyssoniumHelmet2 && damage > 0)
				{
					
					player.AddBuff(mod.BuffType("VyssoniumArmorMeleeSpeed"), 240, true);
				}
			}
		}
		
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (VyssoniumHelmet1)
			{
				if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
			if(MarkOfCain)
			{
				MOCHurt -= 100;
			}
		}
		
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (VyssoniumHelmet1)
			{
				if (Main.rand.Next(2) == 0)
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 165, false);
				}
				else
				{
					target.AddBuff(mod.BuffType("VyssoniumPoisoning"), 115, false);
				}
			}
			if(MarkOfCain)
			{
				MOCHurt -= 100;
			}
		}
		
		public override void PostUpdateRunSpeeds()
		{
			if (player.pulley && dashMod > 0)
			{
				ModDashMovement();
				return;
			}
			if (player.grappling[0] == -1 && !player.tongued)
			{
				ModHorizontalMovement();
				if (dashMod > 0)
				{
					ModDashMovement();
				}
			}
		}
		
		public void ModDashMovement()
		{
			if (player.dashDelay > 0)
			{
				return;
			}
			
			if (dashMod == 1 && player.dashDelay < 0 && player.whoAmI == Main.myPlayer)
			{
				Rectangle rectangle5 = new Rectangle((int)((double)player.position.X + (double)player.velocity.X * 0.5 - 4.0), (int)((double)player.position.Y + (double)player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
				for (int m = 0; m < 200; m++)
				{
					if (Main.npc[m].active && !Main.npc[m].dontTakeDamage && !Main.npc[m].friendly && !Main.npc[m].townNPC && Main.npc[m].immune[player.whoAmI] <= 0 && Main.npc[m].damage > 0)
					{
						NPC npc5 = Main.npc[m];
						Rectangle rect5 = npc5.getRect();
						if (rectangle5.Intersects(rect5) && (npc5.noTileCollide || player.CanHit(npc5)))
						{
							OnDodge();
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
							OnDodge();
							break;
						}
					}
				}
			}
			if (player.dashDelay < 0)
			{
				float num12 = 14f;
				float num13 = 0.985f;
				float num14 = Math.Max(player.accRunSpeed, player.maxRunSpeed);
				float num15 = 0.94f;
				int dashDelay = 28;
				
				if (dashMod == 1)
				{
					for (int num16 = 0; num16 < 2; num16++)
					{
						int dustz;
						if (player.velocity.Y == 0f)
						{
							dustz = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)player.height - 4f), player.width, 16, 235, 0f, 0f, 100, default(Color), 1.4f);
						}
						else
						{
							dustz = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)(player.height / 2) - 8f), player.width, 8, 235, 0f, 0f, 100, default(Color), 1.4f);
						}
						Main.dust[dustz].velocity *= 0.1f;
						Main.dust[dustz].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[dustz].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
					}
				}
				
				if (dashMod == 3)
				{
					for (int num34 = 0; num34 < 24; num34++)
					{
						int num68 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 4f), player.width, player.height - 8, mod.DustType("LunarDust2"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num68].velocity *= 0.1f;
						Main.dust[num68].scale *= 0.35f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num68].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
						Main.dust[num68].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num68].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}	
				
				if (dashMod == 4)
				{
					for (int num33 = 0; num33 < 24; num33++)
					{
						int num69 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 4f), player.width, player.height - 8, mod.DustType("EverGladesDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num69].velocity *= 0.1f;
						Main.dust[num69].scale *= 0.35f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num69].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
						Main.dust[num69].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num69].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (dashMod == 5)
				{
					for (int num24 = 0; num24 < 24; num24++)
					{
						int num25 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 4f), player.width, player.height - 8, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num25].velocity *= 0.1f;
						Main.dust[num25].scale *= 0.7f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num25].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
						Main.dust[num25].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num25].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (dashMod == 6)
				{
					for (int num24 = 0; num24 < 24; num24++)
					{
						int num25 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + 4f), player.width, player.height - 8, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 2.75f);
						Main.dust[num25].velocity *= 0.1f;
						Main.dust[num25].scale *= 0.6f + (float)Main.rand.Next(20) * 0.01f;
						Main.dust[num25].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
						Main.dust[num25].noGravity = true;
						if (Main.rand.Next(2) == 0)
						{
							Main.dust[num25].fadeIn = 0.5f;
						}
					}
					num12 = 18f;
				}
				
				if (dashMod > 0)
				{
					player.vortexStealthActive = false;
					if (player.velocity.X > num12 || player.velocity.X < -num12)
					{
						player.velocity.X = player.velocity.X * num13;
						return;
					}
					if (player.velocity.X > num14 || player.velocity.X < -num14)
					{
						player.velocity.X = player.velocity.X * num15;
						return;
					}
					player.dashDelay = dashDelay;
					if (player.velocity.X < 0f)
					{
						player.velocity.X = -num14;
						return;
					}
					if (player.velocity.X > 0f)
					{
						player.velocity.X = num14;
						return;
					}
				}
			}
			else if (dashMod > 0 && !player.mount.Active)
			{
				
				if (dashMod == 1)
				{
					int num28 = 0;
					bool flag = false;
					if (dashTimeMod > 0)
					{
						dashTimeMod--;
					}
					if (dashTimeMod < 0)
					{
						dashTimeMod++;
					}
					if (player.controlRight && player.releaseRight)
					{
						if (dashTimeMod > 0)
						{
							num28 = 1;
							flag = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = 15;
						}
					}
					else if (player.controlLeft && player.releaseLeft)
					{
						if (dashTimeMod < 0)
						{
							num28 = -1;
							flag = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = -15;
						}
					}
					if (flag)
					{
						player.velocity.X = 14.5f * (float)num28;
						Point point = (player.Center + new Vector2((float)(num28 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point2 = (player.Center + new Vector2((float)(num28 * player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						for (int num29 = 0; num29 < 20; num29++)
						{
							int num30 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 235, 0f, 0f, 100, default(Color), 2f);
							Dust dust = Main.dust[num30];
							dust.position.X = dust.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust2 = Main.dust[num30];
							dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-5, 6);
							Main.dust[num30].velocity *= 0.2f;
							Main.dust[num30].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num30].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
						}
						return;
					}
				}
				
				if (dashMod == 3)
				{
					int num20 = 0;
					bool flag3 = false;
					if (dashTimeMod > 0)
					{
						dashTimeMod--;
					}
					if (dashTimeMod < 0)
					{
						dashTimeMod++;
					}
					if (player.controlRight && player.releaseRight)
					{
						if (dashTimeMod > 0)
						{
							num20 = 1;
							flag3 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = 31;
						}
					}
					else if (player.controlLeft && player.releaseLeft)
					{
						if (dashTimeMod < 0)
						{
							num20 = -1;
							flag3 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = -31;
						}
					}
					if (flag3)
					{
						player.velocity.X = 26.9f * (float)num20;
						Point point14 = (player.Center + new Vector2((float)(num20 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point15 = (player.Center + new Vector2((float)(num20 * player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point14.X, point14.Y) || WorldGen.SolidOrSlopedTile(point15.X, point15.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						for (int num61 = 0; num61 < 70; num61++)
						{
							int num62 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, mod.DustType("LunarDust2"), 0f, 0f, 100, default(Color), 3f);
							Dust dust14 = Main.dust[num62];
							dust14.position.X = dust14.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust15 = Main.dust[num62];
							dust15.position.Y = dust15.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num62].velocity *= 0.2f;
							Main.dust[num62].scale *= 0.3f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num62].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
							Main.dust[num62].noGravity = true;
							Main.dust[num62].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (dashMod == 4)
				{
					int num30 = 0;
					bool flag4 = false;
					if (dashTimeMod > 0)
					{
						dashTimeMod--;
					}
					if (dashTimeMod < 0)
					{
						dashTimeMod++;
					}
					if (player.controlRight && player.releaseRight)
					{
						if (dashTimeMod > 0)
						{
							num30 = 1;
							flag4 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = 29;
						}
					}
					else if (player.controlLeft && player.releaseLeft)
					{
						if (dashTimeMod < 0)
						{
							num30 = -1;
							flag4 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = -29;
						}
					}
					if (flag4)
					{
						player.velocity.X = 26.9f * (float)num30;
						Point point19 = (player.Center + new Vector2((float)(num30 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point20 = (player.Center + new Vector2((float)(num30 * player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point19.X, point19.Y) || WorldGen.SolidOrSlopedTile(point20.X, point20.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						for (int num51 = 0; num51 < 70; num51++)
						{
							int num52 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, mod.DustType("EverGladesDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust19 = Main.dust[num52];
							dust19.position.X = dust19.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust20 = Main.dust[num52];
							dust20.position.Y = dust20.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num52].velocity *= 0.2f;
							Main.dust[num52].scale *= 0.3f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num52].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
							Main.dust[num52].noGravity = true;
							Main.dust[num52].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (dashMod == 5)
				{
					int num40 = 0;
					bool flag5 = false;
					if (dashTimeMod > 0)
					{
						dashTimeMod--;
					}
					if (dashTimeMod < 0)
					{
						dashTimeMod++;
					}
					if (player.controlRight && player.releaseRight)
					{
						if (dashTimeMod > 0)
						{
							num40 = 1;
							flag5 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = 25;
						}
					}
					else if (player.controlLeft && player.releaseLeft)
					{
						if (dashTimeMod < 0)
						{
							num40 = -1;
							flag5 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = -25;
						}
					}
					if (flag5)
					{
						player.velocity.X = 25.9f * (float)num40;
						Point point9 = (player.Center + new Vector2((float)(num40 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point10 = (player.Center + new Vector2((float)(num40 * player.width / 2 + 2), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point9.X, point9.Y) || WorldGen.SolidOrSlopedTile(point10.X, point10.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						for (int num41 = 0; num41 < 70; num41++)
						{
							int num42 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust9 = Main.dust[num42];
							dust9.position.X = dust9.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust10 = Main.dust[num42];
							dust10.position.Y = dust10.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num42].velocity *= 0.2f;
							Main.dust[num42].scale *= 0.8f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num42].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
							Main.dust[num42].noGravity = true;
							Main.dust[num42].fadeIn = 0.5f;
						}
						return;
					}
				}
				
				if (dashMod == 6)
				{
					int num50 = 0;
					bool flag6 = false;
					if (dashTimeMod > 0)
					{
						dashTimeMod--;
					}
					if (dashTimeMod < 0)
					{
						dashTimeMod++;
					}
					if (player.altFunctionUse == 1 && player.direction == 1)
					{
						if (dashTimeMod > 0)
						{
							num50 = 1;
							flag6 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = 25;
						}
					}
					else if (player.altFunctionUse == 1 && player.direction == -1)
					{
						if (dashTimeMod < 0)
						{
							num50 = -1;
							flag6 = true;
							dashTimeMod = 0;
						}
						else
						{
							dashTimeMod = -25;
						}
					}
					if (flag6)
					{
						player.velocity.X = 25.9f * (float)num50;
						Point point11 = (player.Center + new Vector2((float)(num50 * player.width / 2 + 3), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
						Point point12 = (player.Center + new Vector2((float)(num50 * player.width / 2 + 3), 0f)).ToTileCoordinates();
						if (WorldGen.SolidOrSlopedTile(point11.X, point11.Y) || WorldGen.SolidOrSlopedTile(point12.X, point12.Y))
						{
							player.velocity.X = player.velocity.X / 2f;
						}
						player.dashDelay = -1;
						for (int num41 = 0; num41 < 70; num41++)
						{
							int num43 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, mod.DustType("AllElementDust"), 0f, 0f, 100, default(Color), 3f);
							Dust dust11 = Main.dust[num43];
							dust11.position.X = dust11.position.X + (float)Main.rand.Next(-5, 6);
							Dust dust12 = Main.dust[num43];
							dust12.position.Y = dust12.position.Y + (float)Main.rand.Next(-2, 4);
							Main.dust[num43].velocity *= 0.2f;
							Main.dust[num43].scale *= 0.45f + (float)Main.rand.Next(20) * 0.01f;
							Main.dust[num43].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
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
			float num = (player.accRunSpeed + player.maxRunSpeed) / 2f;
			if (player.controlLeft && player.velocity.X > -player.accRunSpeed && player.dashDelay >= 0)
			{
				if (player.velocity.X < -num && player.velocity.Y == 0f && !player.mount.Active)
				{
					int num2 = 0;
					if (player.gravDir == -1f)
					{
						num2 -= player.height;
					}
					if (dashMod == 1)
					{
						int num3 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num2), player.width + 8, 4, 16, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
						Main.dust[num3].velocity.X = Main.dust[num3].velocity.X * 0.2f;
						Main.dust[num3].velocity.Y = Main.dust[num3].velocity.Y * 0.2f;
						Main.dust[num3].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
						Main.dust[num3].scale *= 0.5f + (float)Main.rand.Next(10) * 0.01f;
					}
					if (dashMod == 3)
					{
						int num5 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num2), player.width + 2, 2, mod.DustType("LunarDust2"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num5].velocity.X = Main.dust[num5].velocity.X * 0.2f;
						Main.dust[num5].velocity.Y = Main.dust[num5].velocity.Y * 0.2f;
						Main.dust[num5].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
						Main.dust[num5].scale *= 0.45f + (float)Main.rand.Next(10) * 0.01f;
					}	
					if (dashMod == 4)
					{
						int num6 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num2), player.width + 2, 2, mod.DustType("EverGladesDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num6].velocity.X = Main.dust[num6].velocity.X * 0.2f;
						Main.dust[num6].velocity.Y = Main.dust[num6].velocity.Y * 0.2f;
						Main.dust[num6].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
						Main.dust[num6].scale *= 0.45f + (float)Main.rand.Next(10) * 0.01f;
					}			
					if (dashMod == 5)
					{
						int num7 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num2), player.width + 6, 4, mod.DustType("AllElementDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num7].velocity.X = Main.dust[num7].velocity.X * 0.2f;
						Main.dust[num7].velocity.Y = Main.dust[num7].velocity.Y * 0.2f;
						Main.dust[num7].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
					}
					if (dashMod == 6)
					{
						int num8 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num2), player.width + 6, 4, mod.DustType("AllElementDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
						Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.2f;
						Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.2f;
						Main.dust[num8].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
					}
				}
			}
			
			else if (player.controlRight && player.velocity.X < player.accRunSpeed && player.dashDelay >= 0 && player.velocity.X > num && player.velocity.Y == 0f && !player.mount.Active)
			{
				int num9 = 0;
				if (player.gravDir == -1f)
				{
					num9 -= player.height;
				}
				if (dashMod == 1)
				{
					int num10 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num9), player.width + 8, 4, 16, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 1.5f);
					Main.dust[num10].velocity.X = Main.dust[num10].velocity.X * 0.2f;
					Main.dust[num10].velocity.Y = Main.dust[num10].velocity.Y * 0.2f;
					Main.dust[num10].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
					Main.dust[num10].scale *= 0.5f + (float)Main.rand.Next(10) * 0.01f;
				}
				if (dashMod == 3)
				{
					int num23 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num9), player.width + 2, 4, mod.DustType("LunarDust2"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num23].velocity.X = Main.dust[num23].velocity.X * 0.2f;
					Main.dust[num23].velocity.Y = Main.dust[num23].velocity.Y * 0.2f;
					Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
				}
				if (dashMod == 4)
				{
					int num24 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num9), player.width + 2, 4, mod.DustType("EverGladesDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num24].velocity.X = Main.dust[num24].velocity.X * 0.2f;
					Main.dust[num24].velocity.Y = Main.dust[num24].velocity.Y * 0.2f;
					Main.dust[num24].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
				}
				if (dashMod == 5)
				{
					int num14 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num9), player.width + 6, 4, mod.DustType("AllElementDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num14].velocity.X = Main.dust[num14].velocity.X * 0.2f;
					Main.dust[num14].velocity.Y = Main.dust[num14].velocity.Y * 0.2f;
					Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
				}
			}
			
			else if (player.altFunctionUse == 1 && player.velocity.X < player.accRunSpeed && player.dashDelay >= 0 && player.velocity.X > num && player.velocity.Y == 0f && !player.mount.Active)
			{
				int num10 = 0;
				if (player.gravDir == -1f)
				{
					num10 -= player.height;
				}
				if (dashMod == 6)
				{
					int num15 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + (float)player.height + (float)num10), player.width + 6, 4, mod.DustType("AllElementDust"), -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 50, default(Color), 3f);
					Main.dust[num15].velocity.X = Main.dust[num15].velocity.X * 0.2f;
					Main.dust[num15].velocity.Y = Main.dust[num15].velocity.Y * 0.2f;
					Main.dust[num15].shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
				}
			}
		}
		
		private void OnDodge()
		{
			if (player.whoAmI == Main.myPlayer && dodgeDashAcc && !dodgeDashDamage)
			{
				player.AddBuff(mod.BuffType("DodgeDashDamage"), 300, true);
				player.immune = true;
				player.immuneTime = 110;
				if (player.longInvince)
				{
					player.immuneTime += 80;
				}
				for (int i = 0; i < player.hurtCooldowns.Length; i++)
				{
					player.hurtCooldowns[i] = player.immuneTime;
				}
				for (int j = 0; j < 100; j++)
				{
					int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, mod.DustType("StroidDust2"), 0f, 0f, 100, default(Color), 2f);
					Dust dust = Main.dust[num];
					dust.position.X = dust.position.X + (float)Main.rand.Next(-20, 21);
					Dust dust2 = Main.dust[num];
					dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-20, 21);
					Main.dust[num].velocity *= 0.4f;
					Main.dust[num].scale *= 0.6f + (float)Main.rand.Next(40) * 0.01f;
					Main.dust[num].shader = GameShaders.Armor.GetSecondaryShader(player.cWaist, player);
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
						Main.dust[num].noGravity = true;
					}
				}
				if (player.whoAmI == Main.myPlayer)
				{
					NetMessage.SendData(62, -1, -1, null, player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
				}
			}
		}
		
		public override void UpdateBiomes()
		{
			zoneStroidBiome = (ArcheonWorld.StroidBiome > 20);
		}
		
		public override bool CustomBiomesMatch(Player other)
		{
			MyPlayer modPlayer = other.GetModPlayer<MyPlayer>();
			return zoneStroidBiome == modPlayer.zoneStroidBiome;
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			MyPlayer modPlayer = other.GetModPlayer<MyPlayer>();
			modPlayer.zoneStroidBiome = zoneStroidBiome;
		}

		public override void SendCustomBiomes(BinaryWriter writer)
		{
			BitsByte flags = default(BitsByte);
			flags[0] = zoneStroidBiome;
			writer.Write(flags);
		}

		public override void ReceiveCustomBiomes(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			zoneStroidBiome = flags[0];
		}

		public void Send(int toWho, int fromWho)
		{
			ModPacket packet = mod.GetPacket(256);
			if (Main.netMode == 2)
			{
				packet.Write(fromWho);
			}
			packet.Write(someVal);
			packet.Write(someInt);
			packet.Send(toWho, fromWho);
		}

		public void Receive(BinaryReader reader, int fromWho)
		{
			if (Main.netMode == 1)
			{
				fromWho = reader.ReadInt32();
			}
			someVal = reader.ReadSingle();
			someInt = reader.ReadInt32();
			if (Main.netMode == 2)
			{
				Send(-1, fromWho);
				return;
			}
			MyPlayer modPlayer = Main.player[fromWho].GetModPlayer<MyPlayer>();
			modPlayer.someVal = someVal;
			modPlayer.someInt = someInt;
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
		
		public bool DarkMatterTornado;

		public bool PhantasmDragonMinion;
		
		public bool ShadoniumHelmet2;
		
		public bool VyssoniumHelmet1;
		
		public bool VyssoniumHelmet2;
		
		private float someVal;

		private int someInt;
		
		public bool dodgeDashAcc;
		
		public bool feralArmorDebuffs;
		
		public bool feralSlimes;
		
		public bool penumbraWard;
		public bool rougeWard;
		public bool MarkOfCain;
		
		public int attackCount = 0;
	}
}
