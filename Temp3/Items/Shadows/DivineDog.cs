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
    public class DivineDog : ModItem

    {

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Wolf Silhouette");
            Tooltip.SetDefault("Summons a pair of divine dogs to fight by your side\nOnly one pair of divine dogs can be summoned at a time\nOccupies zero minion slots\nDivine dogs' damage increases with each boss defeated!");
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.RemoveAt(2);
            tooltips.RemoveAt(2);

            tooltips.RemoveAt(2);


        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<CursedEnergy>(2)

                .AddTile(TileID.DemonAltar)
                .Register();
        }
        public static int MYDAMAGE;
        public override void SetDefaults()
        {

            Item.damage = MYDAMAGE;
            Item.width = 32;
            Item.mana = 20;
            Item.height = 28;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp; 
            Item.knockBack = 2;
            Item.rare = ItemRarityID.White;
            Item.DamageType = DamageClass.Default;
            Item.crit = 0;
            Item.UseSound = SoundID.NPCHit6;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<DogSummon>();
            Item.buffType = ModContent.BuffType<DivineDogBuff>();

        }
        public static int NewTimer;
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            Item.damage = MYDAMAGE;
        }
        public override void UpdateInventory(Player player)
        {
            if(DogSummon.KYS == true && DogSummon2.KYS == true)
            {
                NewTimer++;
                if(NewTimer > 20)
                {
                    NewTimer = 0;
                    DogSummon.KYS = false;
                    DogSummon2.KYS = false;

                }
            }
        }
        public static int positive;
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff<DivineDogBuff>())
            {

                return false;
            }
            else
            {
                return true;

            }
        }
        private int timer;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            DogSummon.KYS = false;
            DogSummon2.KYS = false;
            timer = 0;
            Vector2 position2 = player.position + new Vector2(0, 0);

            player.AddBuff(ModContent.BuffType<DivineDogBuff>(), 2);

          Projectile.NewProjectileDirect(source, position, velocity, type, MYDAMAGE, knockback, player.whoAmI);
            type = ModContent.ProjectileType<DogSummon2>();

            Projectile.NewProjectileDirect(source, position2, velocity, type, MYDAMAGE, knockback, player.whoAmI);

            //Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 800, 0f, 0f, ProjectileID.Bomb, damage, 4, player.whoAmI);


            return false;

        }

    }
}


