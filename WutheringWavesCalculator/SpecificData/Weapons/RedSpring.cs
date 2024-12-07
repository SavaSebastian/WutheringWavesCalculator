using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Weapons;

public class RedSpring : WeaponStats
{
    private int _numberOfBasicAttacks;
    public RedSpring(int refinementRank = 0)
    {
        RefinementRank = refinementRank;
        
        BaseAttack = 587;
        CritRate = 24.3m;
        CritDamage = 0m;
        
        AttackDamagePercentage = 12m + RefinementRank * 12m / 5m;
    }

    public override void OnBasicAttack()
    {
        if (_numberOfBasicAttacks >= 3) return;
        
        _numberOfBasicAttacks++;
        BasicAttackPercentage += 10m + RefinementRank * 10m / 5;
    }

    public override void OnConcertoConsumed()
    {
        BasicAttackPercentage += 40m + RefinementRank * 40m / 5;
    }

    public override void Reset()
    {
        AttackDamagePercentage = 12m + RefinementRank * 12m / 5m;
        BasicAttackPercentage = 0m;
        _numberOfBasicAttacks = 0;
    }
}