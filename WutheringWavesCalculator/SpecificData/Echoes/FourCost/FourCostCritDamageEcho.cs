using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.SpecificData.Echoes.FourCost;

public class FourCostCritDamageEcho : Echo
{
    public FourCostCritDamageEcho(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
        : base(critRoll, critDamageRoll, flatAttackRoll, attackPercentageRoll, basicAttackPercentageRoll)
    {
        CritDamage += EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritDamage);
        AttackFlat += EchoHelper.GetMainSubStatAttackValue(EchoCost.Four);
    }
}