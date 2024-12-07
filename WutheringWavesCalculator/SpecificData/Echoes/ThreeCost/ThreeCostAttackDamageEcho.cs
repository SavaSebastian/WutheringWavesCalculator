using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.SpecificData.Echoes.ThreeCost;

public class ThreeCostAttackDamageEcho : Echo
{
    public ThreeCostAttackDamageEcho(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
        : base(critRoll, critDamageRoll, flatAttackRoll, attackPercentageRoll, basicAttackPercentageRoll)
    {
        AttackPercentage += EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.AttackPercentage);
        AttackFlat += EchoHelper.GetMainSubStatAttackValue(EchoCost.Three);
    }
}