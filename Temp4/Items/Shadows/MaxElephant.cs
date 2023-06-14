using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.Audio;

using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;
using TenShadows.Misc;
using Terraria.Localization;

using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;
using System.Threading;
using System.Reflection;

namespace TenShadows.Items.Shadows
{
    public class MaxElephant : ModItem

    {

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Elephant Silhouette");
            Tooltip.SetDefault("Summons a sentry\nSummons a max elephant to shoot water at your enemies!\nOnly one max elephant can be summoned at a time");
        }
    
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(40)
                                .AddIngredient(ItemID.LihzahrdBrick, 40)

                .AddTile<ShrineTile>()
                .Register();
        }
        public override void SetDefaults()
        {

            Item.width = 38;
            Item.mana = 100;
            Item.height = 30;
            Item.damage = 75;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp; 
          //  Item.knockBack = 2;
            Item.rare = ItemRarityID.Yellow;
            Item.DamageType = DamageClass.Summon;
            Item.crit = 0;
            Item.UseSound = SoundID.Zombie42;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ElephantSummon>();
            Item.buffType = ModContent.BuffType<ElephantBuff>();

        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(4 * player.direction, 0);
        }

        public static int positive;
        public static int DeleteAMF;
        private int timer;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.direction == 1)
            {
                positive = 1;
            }
            else
            {
                positive = -1;

            }

            DeleteAMF = 0;
             Vector2 position2 = player.position + new Vector2(0, -130);
      velocity = new Vector2(0, 7.5f);
            player.AddBuff(ModContent.BuffType<ElephantBuff>(), 2);
            Projectile.NewProjectileDirect(source, position2, velocity, type, damage, knockback, player.whoAmI);
            player.UpdateMaxTurrets();



            return false;

        }

    }
}


