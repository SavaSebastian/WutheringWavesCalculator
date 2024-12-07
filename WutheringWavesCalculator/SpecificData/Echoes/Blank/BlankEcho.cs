using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Echoes.Blank;

public class BlankEcho : Echo
{
    public BlankEcho(decimal elementalDamagePercentage = 0, decimal basicAttackPercentage = 0, decimal attackPercentage = 0)
    {
        ElementalDamagePercentage = elementalDamagePercentage;
        BasicAttackPercentageRoll = basicAttackPercentage;
        AttackPercentage = attackPercentage;
    }
}