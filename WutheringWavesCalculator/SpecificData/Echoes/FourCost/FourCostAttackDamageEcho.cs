using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.SpecificData.Echoes.FourCost;

public class FourCostAttackDamageEcho : Echo
{
    public FourCostAttackDamageEcho(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
        : base(critRoll, critDamageRoll, flatAttackRoll, attackPercentageRoll, basicAttackPercentageRoll)
    {
        AttackPercentage += EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.AttackPercentage);
        AttackFlat += EchoHelper.GetMainSubStatAttackValue(EchoCost.Four);
    }
}