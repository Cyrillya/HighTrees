using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace HighTrees;

public class HigherTreeSystem : ModSystem
{
    public override void Load() {
        base.Load();
        _config = ModContent.GetInstance<HigherTreesConfig>();
        IL_WorldGen.GrowTree += WorldGen_GrowTree;
        IL_WorldGen.GrowPalmTree += ModifyPalmTrees;
        SetTreeHeights(_config.GemHeightMin, _config.GemHeightMax, _config.SakuraHeightMin, _config.SakuraHeightMax,
            _config.WillowHeightMin, _config.WillowHeightMax);
    }

    public override void Unload() {
        base.Unload();
        _config = null;
        SetTreeHeights(7, 12, 7, 12, 7, 12);
    }

    // 宝石树高度直接这么改就行了，很方便
    public static void SetTreeHeights(int gemMin, int gemMax, int sakuraMin, int sakuraMax, int willowMin, int willowMax) {
        WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Ruby.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Diamond.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Topaz.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Amethyst.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Sappphire.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Emerald.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMin = gemMin;
        WorldGen.GrowTreeSettings.Profiles.GemTree_Amber.TreeHeightMax = gemMax;
        WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMin = sakuraMin;
        WorldGen.GrowTreeSettings.Profiles.VanityTree_Sakura.TreeHeightMax = sakuraMax;
        WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMin = willowMin;
        WorldGen.GrowTreeSettings.Profiles.VanityTree_Willow.TreeHeightMax = willowMax;
    }

    // 通过简单的IL修改一般树木高度
    private void WorldGen_GrowTree(ILContext il) {
        var c = new ILCursor(il);
        c.GotoNext(MoveType.After, i => i.MatchLdcI4(5));
        c.EmitDelegate((int _) => _config.MostMin);
        c.GotoNext(MoveType.After, i => i.MatchLdcI4(17));
        c.EmitDelegate((int _) => _config.MostMax + 1);
    }

    private void ModifyPalmTrees(ILContext il) {
        ILCursor c = new(il);
        c.GotoNext(MoveType.After, i => i.MatchCall<WorldGen>("get_genRand"),
            i => i.Match(OpCodes.Ldc_I4_S, (sbyte) 10));
        c.EmitDelegate((int _) => _config.PalmMin);
        c.GotoNext(MoveType.After, i => i.Match(OpCodes.Ldc_I4_S, (sbyte) 21));
        c.EmitDelegate((int _) => _config.PalmMax + 1);
    }

    private static HigherTreesConfig _config;
}