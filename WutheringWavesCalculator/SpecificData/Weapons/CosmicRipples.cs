using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Weapons;

public class CosmicRipples : WeaponStats
{
    private int _numberOfAttacks;
    public CosmicRipples(int refinementRank = 0)
    {
        RefinementRank = refinementRank;
        BaseAttack = 500;
        AttackDamagePercentage = 54;
    }

    public override void OnBasicAttack()
    {
        if (_numberOfAttacks >= 5) return;

        _numberOfAttacks++;
        BasicAttackPercentage = 3.2m * _numberOfAttacks + RefinementRank * 3.2m * _numberOfAttacks / 5m;
    }
    
    public override void Reset()
    {
        BasicAttackPercentage = 0;
        _numberOfAttacks = 0;
    }
}