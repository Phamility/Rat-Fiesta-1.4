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
using TenShadows.Items.Shadows;

namespace TenShadows.Misc
{
    public class RabbitBombs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Honored One's Rabbit Silhouette");
            Tooltip.SetDefault("Conjure a swarm of explosive bunnies!\nWhat a twist!");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<RabbitEscape>(1)
                                .AddIngredient<CursedEnergy>(30)

                .AddIngredient(ItemID.ExplosiveBunny, 10)
                .AddIngredient(ItemID.Ectoplasm, 10)

                .AddTile(TileID.DemonAltar)
                .Register();
        }
        public override void SetDefaults()
        {

            //   Item.damage = 9;
            Item.width = 36;
            Item.mana = 50;
            Item.height = 32;

            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
                                             //  Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = true;
            Item.shoot = NPCID.ExplosiveBunny;

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
            position.Y = player.position.Y - 100;

            int numberProjectiles = Main.rand.Next(22, 30);
            for (int i = 0; i < numberProjectiles; i++)
            {
                position.X = player.position.X + Main.rand.Next(-350, 350);
                position.Y = player.position.Y - 100 + Main.rand.Next(-80, 80);

                NPC.NewNPC(source, (int)position.X, (int)position.Y, NPCID.ExplosiveBunny);

            }
            return false;

        }

    }
}
