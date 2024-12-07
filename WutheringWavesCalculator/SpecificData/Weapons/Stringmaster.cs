using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Weapons;

public class Stringmaster : WeaponStats
{
    private int _characterLeftFieldTimes;
    private int _resonanceSkillCasts;
    public Stringmaster(int refinementRank = 0)
    {
        BaseAttack = 500;
        CritRate = 36;
        ElementalDamagePercentage = 12m + refinementRank * 12m / 5m;
    }

    public override void OnResonanceSkillCast()
    {
        if (_resonanceSkillCasts >= 2) return;

        AttackDamagePercentage = _resonanceSkillCasts * 12m + _resonanceSkillCasts * RefinementRank * 2.4m / 5;
    }

    public override void OnCharacterLeaveField()
    {
        if (_characterLeftFieldTimes >= 1) return;

        _characterLeftFieldTimes++;
        AttackDamagePercentage += 12m;
    }

    public override void Reset()
    {
        _characterLeftFieldTimes = 0;
        _resonanceSkillCasts = 0;
        AttackDamagePercentage = 0;
    }
}