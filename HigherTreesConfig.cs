using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace HighTrees;

[Label("$Mods.HighTrees.Configs.Label.Title")]
public class HigherTreesConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    public override void OnChanged() {
        base.OnChanged();
        if (MostMin > MostMax) {
            MostMin = MostMax;
        }

        if (PalmMin > PalmMax) {
            PalmMin = PalmMax;
        }

        if (GemHeightMin > GemHeightMax) {
            GemHeightMin = GemHeightMax;
        }

        if (SakuraHeightMin > SakuraHeightMax) {
            SakuraHeightMin = SakuraHeightMax;
        }

        if (WillowHeightMin > WillowHeightMax) {
            WillowHeightMin = WillowHeightMax;
        }

        HigherTreeSystem.SetTreeHeights(GemHeightMin, GemHeightMax, SakuraHeightMin, SakuraHeightMax,
            WillowHeightMin, WillowHeightMax);
    }

    [Range(1, 1000)]
    [DefaultValue(5)]
    [Label("$Mods.HighTrees.Configs.Label.MinMost")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MinMost")]
    public int MostMin;

    [Range(1, 1000)]
    [DefaultValue(16)]
    [Label("$Mods.HighTrees.Configs.Label.MaxMost")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MaxMost")]
    public int MostMax;

    [Range(1, 100)]
    [DefaultValue(10)]
    [Label("$Mods.HighTrees.Configs.Label.MinPalm")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MinPalm")]
    public int PalmMin;

    [Range(1, 100)]
    [DefaultValue(20)]
    [Label("$Mods.HighTrees.Configs.Label.MaxPalm")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MaxPalm")]
    public int PalmMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [Label("$Mods.HighTrees.Configs.Label.MinGem")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MinGem")]
    public int GemHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [Label("$Mods.HighTrees.Configs.Label.MaxGem")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MaxGem")]
    public int GemHeightMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [Label("$Mods.HighTrees.Configs.Label.MinSakura")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MinSakura")]
    public int SakuraHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [Label("$Mods.HighTrees.Configs.Label.MaxSakura")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MaxSakura")]
    public int SakuraHeightMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [Label("$Mods.HighTrees.Configs.Label.MinWillow")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MinWillow")]
    public int WillowHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [Label("$Mods.HighTrees.Configs.Label.MaxWillow")]
    [Tooltip("$Mods.HighTrees.Configs.Tooltip.MaxWillow")]
    public int WillowHeightMax;
}