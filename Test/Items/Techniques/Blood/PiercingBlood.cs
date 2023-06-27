﻿using System;
using TenShadows.Buffs;
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
using TenShadows.Tiles;
using Terraria.Utilities;

namespace TenShadows.Items.Techniques.Blood
{
    public class PiercingBlood : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piercing Blood");
            Tooltip.SetDefault("Imbue your arrows with blood, increasing their power!");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PulseBow);

            Item.damage = 32;
            Item.width = 18;
            // Item.mana = 8;
            Item.height = 44;
            // Item.healLife = -4;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.knockBack = 2;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.DamageType = ModContent.GetInstance<CursedDamage>();
            Item.UseSound = SoundID.Item102;

            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            //    Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
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

            prefixchooser.Add(PrefixID.Rapid, 2);
            prefixchooser.Add(PrefixID.Unreal, 2);
            int choice = prefixchooser;
            if ((Item.damage > 0) && Item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int losslife;
            losslife = Main.rand.Next(3, 6);
            player.statLife -= losslife;
            if (player.statLife <= 0)
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " used up too much blood!"), losslife, 0);
            }
            return true;
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += ExampleDamagePlayer.ModPlayer(player).exampleDamageAdd;
            damage *= ExampleDamagePlayer.ModPlayer(player).exampleDamageMult;
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
            TooltipLine tooltip = new TooltipLine(Mod, "Ten Shadows: Cost", $"Costs 3-5 life per use") { OverrideColor = Color.Red };


            tooltips.Insert(1, tooltip);
            Player player = Main.LocalPlayer;
            TooltipLine COCK = tooltips.FirstOrDefault(x => x.Name == "CritChance" && x.Mod == "Terraria");
            tooltips.Remove(COCK);

            TooltipLine BLACKFLASHCHANCE = new TooltipLine(Mod, "Ten Shadows: Cost", $"{player.GetModPlayer<MP>().ZoneChance}% black flash chance") { OverrideColor = Color.White };
            if (Item.favorited == true)
            {
                tooltips.Insert(5, BLACKFLASHCHANCE);
            }
            else
            {
                tooltips.Insert(3, BLACKFLASHCHANCE);
            }
        }

    }
}


