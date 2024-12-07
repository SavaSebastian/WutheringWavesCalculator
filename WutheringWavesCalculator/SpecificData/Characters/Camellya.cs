using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Characters;

public class Camellya : BaseCharacterStats
{
    public Camellya(int refinementRank)
    {
        RefinementRank = refinementRank;
        
        BaseAttackDamage = 450;

        BonusCritDamage = (refinementRank >= 1 ? 28 : 0) + 16;
        ElementalDamagePercentage = 15;
        BasicAttackDamagePercentage = 15;
        AttackDamagePercentage = 12;
    }
}