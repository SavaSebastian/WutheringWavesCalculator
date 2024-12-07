using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Buffs;

public class Sanhua : Buff
{
    public int RefinementRank { get; set; }
    public Sanhua(int refinementRank = 0)
    {
        RefinementRank = refinementRank;
        
        AttackDamagePercentageBuff = refinementRank == 6 ? 20m : 0m;
        TotalBasicAttackPercentageBuff = 38;
    }
}