using System; using TenShadows.Buffs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using TenShadows.Tiles;

using Terraria.ModLoader;
using IL.Terraria.GameContent.Personalities;
using On.Terraria.GameContent.Personalities;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;
using rail;
using ExampleMod.Content.DamageClasses;
using ExampleMod.Items.ExampleDamageClass;

namespace TenShadows.Items.Techniques
{
    public class WrappedCleaver : ModItem
    {
        public override void SetStaticDefaults()
        {
            // These wings use the same values as the solar wings
            // Fly time: 180 ticks = 3 seconds
            // Fly speed: 9
            // Acceleration multiplier: 2.5
            DisplayName.SetDefault("Wrapped Cleaver");
            Tooltip.SetDefault("When combined with Ratio, Wrapped Cleaver's crit chance is boosted to 70%, and gains 30 armor penetration.\nWrapped Cleaver's crit chance cannot be altered otherwise.");
        }

        public override void SetDefaults()
        {
            Item.width = 42; // The item texture's width.
            Item.height = 34; // The item texture's height.
            Item.scale = 1.04f;
            Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
            Item.useTime = 18; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            Item.useAnimation = 18; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

            Item.DamageType = ModContent.GetInstance<CursedDamage>();
            Item.damage = 29; // The damage your item deals.
            Item.knockBack = 5; // The force of knockback of the weapon. Maximum is 20
            Item.crit = 7; // The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
            Item.value = Item.buyPrice(gold: 3); // The value of the weapon in copper coins.
            Item.rare = ItemRarityID.Green; // Give this item our custom rarity.
            Item.UseSound = SoundID.Item1; // The sound when the weapon is being used.
        }

     
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            damage += ExampleDamagePlayer.ModPlayer(player).exampleDamageAdd;
            damage *= ExampleDamagePlayer.ModPlayer(player).exampleDamageMult;
        }
        public override void ModifyWeaponCrit(Player player, ref float crit)
        {
            if (player.HasBuff<CleaverBuff>() == true)
            {
                crit = 70;
                Item.ArmorPenetration = 30;
            }
            else
            {
                crit = 7;
                Item.ArmorPenetration = 0;

            }
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
 
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                // Emit dusts when the sword is swung
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood);
            }
        }

       

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    }
}