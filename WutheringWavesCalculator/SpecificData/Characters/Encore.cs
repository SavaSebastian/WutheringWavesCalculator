using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Characters;

public class Encore : BaseCharacterStats
{
    private int _resonanceSkillCasts;
    public Encore(int refinementRank)
    {
        RefinementRank = refinementRank;
        
        BaseAttackDamage = 425;
        
        ElementalDamagePercentage = 12;
        AttackDamagePercentage = 12;
    }

    public override void OnResonanceSkillCast()
    {
        if (_resonanceSkillCasts >= 1) return;
        
        _resonanceSkillCasts++;
        ElementalDamagePercentage += 10;
    }

    public override void OnLiberationSkillCast()
    {
        // figure out wtf does damage dealt mean
    }

    public override void Reset()
    {
        ElementalDamagePercentage = 12;
        _resonanceSkillCasts = 0;
    }
}