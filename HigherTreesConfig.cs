using System;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace HighTrees;

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
    [LabelKey("$Mods.HighTrees.Configs.Label.MinMost")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MinMost")]
    public int MostMin;

    [Range(1, 1000)]
    [DefaultValue(16)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MaxMost")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MaxMost")]
    public int MostMax;

    [Range(1, 100)]
    [DefaultValue(10)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MinPalm")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MinPalm")]
    public int PalmMin;

    [Range(1, 100)]
    [DefaultValue(20)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MaxPalm")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MaxPalm")]
    public int PalmMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MinGem")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MinGem")]
    public int GemHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MaxGem")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MaxGem")]
    public int GemHeightMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MinSakura")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MinSakura")]
    public int SakuraHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MaxSakura")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MaxSakura")]
    public int SakuraHeightMax;

    [Range(1, 1000)]
    [DefaultValue(7)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MinWillow")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MinWillow")]
    public int WillowHeightMin;

    [Range(1, 1000)]
    [DefaultValue(12)]
    [LabelKey("$Mods.HighTrees.Configs.Label.MaxWillow")]
    [TooltipKey("$Mods.HighTrees.Configs.Tooltip.MaxWillow")]
    public int WillowHeightMax;
}