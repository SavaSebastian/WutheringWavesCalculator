using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.SpecificData.Echoes.ThreeCost;

public class ThreeCostElementalDamageEcho : Echo
{
    public ThreeCostElementalDamageEcho(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
        : base(critRoll, critDamageRoll, flatAttackRoll, attackPercentageRoll, basicAttackPercentageRoll)
    {
        ElementalDamagePercentage += EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.ElementalDamage);
        AttackFlat += EchoHelper.GetMainSubStatAttackValue(EchoCost.Three);
    }
}