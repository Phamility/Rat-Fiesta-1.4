using System;
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

namespace TenShadows.Items.Weapons
{
    public class RabbitEscape : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rabbit Silhouette");
            Tooltip.SetDefault("Conjure a swarm of bunnies!\nSome are shiny!");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Shadow>(4)
                .AddIngredient(ItemID.Bunny, 1)

                .AddTile(TileID.DemonAltar)
                .Register();
        }
        public override void SetDefaults()
        {

            //   Item.damage = 9;
            Item.width = 32;
            Item.mana = 60;
            Item.height = 28;

            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.
                                           //  Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
            Item.shoot = NPCID.Bunny;

        }
        public int positive;
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(2 * player.direction, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = NPCID.Bunny;
            position.X = player.position.X;
            position.Y = player.position.Y - 300;

            int numberProjectiles = Main.rand.Next(20,25);
            for (int i = 0; i < numberProjectiles; i++)
            {
                position.X = player.position.X + (Main.rand.Next(-350, 350));
                position.Y = player.position.Y - 100 + (Main.rand.Next(-80, 80));
                if (Main.rand.Next(1, 50) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.ExplosiveBunny);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyEmerald);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyAmethyst);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnySapphire);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyTopaz);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyRuby);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyAmber);
                }
                else if (Main.rand.Next(1, 200) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GemBunnyDiamond);
                }
                else if (Main.rand.Next(1, 500) == 2)
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.GoldBunny);
                }
                else
                {
                    NPC.NewNPC(source, (int)position.X, (int)position.Y, type);
                }
            }
                return false;

            }

        }
    }




