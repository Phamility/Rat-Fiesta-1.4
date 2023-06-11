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

namespace TenShadows.Items.Techniques
{
    public class Construction : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Construction");
            Tooltip.SetDefault("20 second cooldown\nConjure a lead bar");
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(12)
        .AddIngredient(ItemID.LeadBar, 12)

                .AddTile(TileID.DemonAltar)
                .Register();
            CreateRecipe()
           .AddIngredient<CursedEnergy>(12)
   .AddIngredient(ItemID.IronBar, 12)

           .AddTile(TileID.DemonAltar)
           .Register();
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(3 * player.direction, 3);
        }
        public override void OnConsumeMana(Player player, int manaConsumed)
        {
            Vector2 position = player.position + new Vector2(0, -13);

            Item.NewItem(Main.LocalPlayer.GetSource_FromThis(), position, ItemID.LeadBar, 1); player.AddBuff(Item.buffType, 20 * 60);
            //player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.LeadBar,1);


        }
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item4; // What sound should play when using the item
          //  Item.healLife = 25; // While we change the actual healing value in GetHealLife, Item.healLife still needs to be higher than 0 for the item to be considered a healing item
          //  Item.potion = false; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            //   Item.damage = 9;
            Item.width = 32;
            Item.mana = 80;
            Item.height = 32;

            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
                                                   //  Item.knockBack = 3;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.
            Item.buffType = ModContent.BuffType<ConDebuff>();
            Item.noMelee = true;
            //      item.shootSpeed = 4f;
            Item.autoReuse = false;
           // Item.shoot = NPCID.Bunny;

        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff<ConDebuff>())
            {

                return false;
            }
            else
            {
                return true;

            }
        }
   
    }
    }




