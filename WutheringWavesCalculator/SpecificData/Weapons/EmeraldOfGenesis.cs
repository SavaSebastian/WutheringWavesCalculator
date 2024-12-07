using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Weapons;

public class EmeraldOfGenesis : WeaponStats
{
    private int _resonanceSkillCasts;
    public EmeraldOfGenesis(int refinementRank = 0)
    {
        RefinementRank = refinementRank;
        
        BaseAttack = 587;
        CritRate = 24.3m;
        CritDamage = 0m;
    }
    
    public override void OnResonanceSkillCast()
    {
        if (_resonanceSkillCasts >= 2) return;
        
        _resonanceSkillCasts++;
        AttackDamagePercentage += 6m + RefinementRank * 6m / 5;
    }

    public override void Reset()
    {
        _resonanceSkillCasts = 0;
        AttackDamagePercentage = 0m;
    }
}