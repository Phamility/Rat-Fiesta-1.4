﻿using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;
using TenShadows.Ancients;
using Terraria.Utilities;
using Terraria.Audio;
using TenShadows.Tiles;


namespace TenShadows.Items.Techniques
{
    public class BlazingCourage : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Courage");
            Tooltip.SetDefault("A quick blade that has a chance to inflict 'On fire' and 'Oiled'\nInflicted effects last 6 seconds");
        }
   
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Cutlass);

            Item.damage = 10;
            Item.width = 52;
           // Item.mana = 8;
            Item.height = 56;
           // Item.healLife = -4;
           Item.useTime = 15;
           Item.useAnimation = 15;
           // Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.knockBack = 4;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.
            Item.DamageType = ModContent.GetInstance<CursedDamage>();
          //  Item.UseSound = SoundID.Item102;

          //  Item.noMelee = true;
            //      item.shootSpeed = 4f;
        //    Item.shoot = ProjectileID.WoodenArrowFriendly;
      //     Item.useAmmo = AmmoID.Arrow;
            Item.autoReuse = true;
          //  Item.shoot = ModContent.ProjectileType<NueFriendlyFeather>();

        }
        public int positive;

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            var prefixchooser = new WeightedRandom<int>();
            prefixchooser.Add(PrefixID.Broken, 2);
            prefixchooser.Add(PrefixID.Damaged, 2);
            prefixchooser.Add(PrefixID.Slow, 2);
            prefixchooser.Add(PrefixID.Annoying, 2);
            prefixchooser.Add(PrefixID.Quick, 2);
            prefixchooser.Add(PrefixID.Deadly, 2);
            prefixchooser.Add(PrefixID.Demonic, 2);
            prefixchooser.Add(PrefixID.Godly, 2);
            prefixchooser.Add(PrefixID.Ruthless, 2);
            prefixchooser.Add(PrefixID.Unpleasant, 2);
            prefixchooser.Add(PrefixID.Hurtful, 2);

            prefixchooser.Add(PrefixID.Sharp, 2);
            prefixchooser.Add(PrefixID.Legendary, 2);
            int choice = prefixchooser;
            if ((Item.damage > 0) && Item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (Main.rand.Next(1, 5) == 2)
            {
                target.AddBuff(BuffID.OnFire, 60 * 6);
                target.AddBuff(BuffID.Oiled, 60 * 6);

            }
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += ExampleDamagePlayer.ModPlayer(player).exampleDamageAdd;
            damage *= ExampleDamagePlayer.ModPlayer(player).exampleDamageMult;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (crit == true)
            {
                SoundEngine.PlaySound(SoundID.NPCHit53, target.position);
                int pos;
                int dustType;
                damage *= player.GetModPlayer<MP>().ZoneDamage;

                CombatText.clearAll();

                for (int i = 0; i < 30; i++)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        pos = 1;
                    }
                    else
                    {
                        pos = -1;
                    }
                    if (Main.rand.Next(1, 4) == 2)
                    {
                        dustType = ModContent.DustType<CustomDust>();
                    }
                    else
                    {
                        if (Main.rand.Next(1, 3) == 2)
                        {
                            dustType = ModContent.DustType<CustomDust2>();
                        }
                        else
                        {
                            dustType = ModContent.DustType<CustomDust3>();

                        }
                    }
                    var dust = Dust.NewDustDirect(target.position, target.width, target.height, dustType);

                    dust.velocity.X += Main.rand.NextFloat(.5f, 1f) * pos;
                    dust.velocity.Y += Main.rand.NextFloat(.5f, 1f) * pos;

                    dust.scale *= 1f + Main.rand.NextFloat(-0.05f, 0.05f);
                }
                player.AddBuff(ModContent.BuffType<ZoneBuff>(), 60 * player.GetModPlayer<MP>().ZoneDuration);

                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, target.width, target.height), Color.DarkRed, damage, true, false);
            }
        }

        public override void ModifyWeaponCrit(Player player, ref float crit)
        {

            crit = player.GetModPlayer<MP>().ZoneChance;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.Text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.Text = damageValue + " cursed damage";
            }
            TooltipLine COCK = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.Mod == "Terraria");
            tooltips.Remove(COCK);
            Player player = Main.LocalPlayer;
            TooltipLine BLACKFLASHCHANCE = new TooltipLine(Mod, "Ten Shadows: Cost", $"{player.GetModPlayer<MP>().ZoneChance}% black flash chance") { OverrideColor = Color.White };
            if (Item.favorited == true)
            {
                tooltips.Insert(4, BLACKFLASHCHANCE);
            }
            else
            {
                tooltips.Insert(2, BLACKFLASHCHANCE);
            }


        }

    }
}


