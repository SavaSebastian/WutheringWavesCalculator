using WutheringWaves.Data.Entities;

namespace WutheringWavesCalculator.SpecificData.Echoes.Set;

public class MoltenRiftEchoSet : EchoSet
{
    private int _resonanceSkillCasts;
    private int _echoSkillCasts;
    public MoltenRiftEchoSet(List<Echo> echoes) : base(echoes)
    {
        BonusElementalDamagePercentage = 10;
    }

    public override void OnResonanceSkillCast()
    {
        if (_resonanceSkillCasts >= 1) return;

        _resonanceSkillCasts++;
        BonusElementalDamagePercentage += 30;
    }

    public override void OnEchoCast()
    {
        if (_echoSkillCasts >= 1) return;

        _echoSkillCasts++;
        BonusElementalDamagePercentage += 12;
        BonusBasicAttackPercentage += 12;
    }

    public override void Reset()
    {
        _echoSkillCasts = 0;
        _resonanceSkillCasts = 0;

        BonusElementalDamagePercentage = 10;
        BonusBasicAttackPercentage = 0;
    }
}