using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Buffs;

public class Verina : Buff
{
    public int RefinementRank { get; set; }

    public Verina(int refinementRank = 0)
    {
        RefinementRank = refinementRank;

        AttackDamagePercentageBuff = 20m;

        TotalDamagePercentageBuff = 15;
    }
}