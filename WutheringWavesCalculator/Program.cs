using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;
using WutheringWavesCalculator.SpecificData.Buffs;

namespace WutheringWavesCalculator;

internal static class Program
{
    private static void Main()
    {
        var buffs = new List<Buff> { new Sanhua(), new Verina(), new MoonlitClouds(), new RejuvenatingGlow() };
        
        //DamageHelper.CompareCharacterWithWeapons(Characters.Camelia, [Weapons.RedSpring, Weapons.EmeraldOfGenesis], buffs);
        DamageHelper.CompareCharacterWithWeapons(Characters.Encore, [Weapons.StringMaster, Weapons.CosmicRipples], buffs);
    }
}