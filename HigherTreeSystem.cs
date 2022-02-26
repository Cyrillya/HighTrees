using System;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace HighTrees
{
    public class HigherTreeSystem : ModSystem
    {
        public override void Load() {
            base.Load();
            config = ModContent.GetInstance<HigherTreesConfig>();
            IL.Terraria.WorldGen.GrowTree += new ILContext.Manipulator(WorldGen_GrowTree);
            // 宝石树高度直接这么改就行了，很方便
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMin = config.GemHeightMin;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMax = config.GemHeightMax;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMin = config.SakuraHeightMin;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMax = config.SakuraHeightMax;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMin = config.WillowHeightMin;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMax = config.WillowHeightMax;
        }

        public override void Unload() {
            base.Unload();
            config = null;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMax = 12;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMin = 7;
            WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMax = 12;
        }

        // 通过简单的IL修改一般树木高度
        private void WorldGen_GrowTree(ILContext il) {
            ILCursor c = new ILCursor(il);
            c.GotoNext(MoveType.After, i => i.MatchLdcI4(5));
            c.EmitDelegate((int min) => config.MostMin);
            c.GotoNext(MoveType.After, i => i.MatchLdcI4(17));
            c.EmitDelegate((int max) => config.MostMax + 1);
        }

        internal static HigherTreesConfig config;
    }
}
