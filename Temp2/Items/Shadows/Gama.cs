using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ID;
using TenShadows.Projectiles;
using TenShadows.Items.Materials;
using TenShadows.Misc;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace TenShadows.Items.Shadows
{
    public class Gama : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toad Silhouette");
            Tooltip.SetDefault("Upon use, surround yourself with bubbles that inflict ichor and cursed inferno\nDoesn't consume on use");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Shadow>(20)
                .AddIngredient(ItemID.Ichor, 12)

                .AddTile(TileID.DemonAltar)
                .Register();
           CreateRecipe()
        .AddIngredient<Shadow>(20)
        .AddIngredient(ItemID.CursedFlame, 12)

        .AddTile(TileID.DemonAltar)
        .Register();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(4 * player.direction, 3);
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.NPCHit20; // What sound should play when using the item


            //   Item.damage = 9;
            Item.width = 30;
            Item.mana = 25;
            Item.height = 30;
            Item.crit = 0;
            Item.damage = 25;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
           // Item.buffType = ModContent.BuffType<SerpentBuff>();
            //  Item.knockBack = 3;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.
                                           //  Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CursedBubble>();


        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            int numberProjectiles = 8;
            for (int i = 0; i < numberProjectiles; i++)
            {
                if (Main.rand.Next(1, 3) == 2)
                {
                    type = ModContent.ProjectileType<IchorBubble    >();
                }
                else
                {
                    type = ModContent.ProjectileType<CursedBubble>();
                }
                position.X = player.position.X + Main.rand.Next(-200, 200);
                position.Y = player.position.Y + Main.rand.Next(-200, 200);

                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                //Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 800, 0f, 0f, ProjectileID.Bomb, damage, 4, player.whoAmI);

            }
            return false;

        }


    }
    }




