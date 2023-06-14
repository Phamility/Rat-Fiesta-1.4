using System;

using Microsoft.Xna.Framework;
using TenShadows.Items.Materials;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using TenShadows.Misc;
using Terraria.ModLoader;


namespace TenShadows.Items.Shadows
{
    public class FlyingNue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bird Silhouette");
            Tooltip.SetDefault("Upon use, slightly increases flight time\n25 second duration\nEffects are amplified for Nue-type Wings!\nDoesn't consume on use");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;

            ItemID.Sets.StaffMinionSlotsRequired[Type] = 1; // The default value is 1, but other values are supported. See the docs for more guidance. 
        }

        public override void SetDefaults()
        {
            //  Item.damage = 8;
            //    Item.knockBack = 2f;
            Item.mana = 20; // mana cost
            Item.width = 24;
            Item.height = 32;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp; // how the player's arm moves when using the item
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item80; // What sound should play when using the item
            Item.autoReuse = true;
            // These below are needed for a minion weapon
            Item.noMelee = true; // this item doesn't do any melee damage
                                 // Item.DamageType = DamageClass.Summon; // Makes the damage register as summon. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type
            Item.buffType = ModContent.BuffType<FlightBuff>();
            // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
            //   Item.shoot = ModContent.ProjectileType<SummonedNue>(); // This item creates the minion projectile
        }
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation -= new Vector2(6 * player.direction, 0);
        }



       public override void OnConsumeMana(Player player, int manaConsumed)
        {

            player.AddBuff(Item.buffType, 60 * 25);

        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(6)

                .AddIngredient<NueFeather>(6)
                .AddTile<ShrineTile>()
                .Register();
        }
    }
}
