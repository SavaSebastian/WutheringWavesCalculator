using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.SpecificData.Echoes.FourCost;

public class FourCostCritRateEcho : Echo
{
    public FourCostCritRateEcho(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
        : base(critRoll, critDamageRoll, flatAttackRoll, attackPercentageRoll, basicAttackPercentageRoll)
    {
        CritRate += EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritRate);
        AttackFlat += EchoHelper.GetMainSubStatAttackValue(EchoCost.Four);
    }
}