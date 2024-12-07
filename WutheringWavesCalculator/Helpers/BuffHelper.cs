using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.Helpers;

public class BuffHelper
{
    public static decimal GetTotalDamageBuff(List<Buff> buffs) => 1 + buffs.Sum(x => x.TotalDamagePercentageBuff);
    public static decimal GetTotalBasicAttackPercentageBuff(List<Buff> buffs) => 1 + buffs.Sum(x => x.TotalBasicAttackPercentageBuff + x.TotalDamagePercentageBuff);

    public static decimal GetAttackDamagePercentageBuff(List<Buff> buffs) => 1 + buffs.Sum(x => x.AttackDamagePercentageBuff);
}