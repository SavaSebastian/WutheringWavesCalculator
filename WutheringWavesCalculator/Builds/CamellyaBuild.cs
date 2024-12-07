using WutheringWaves.Data.Entities;
using WutheringWavesCalculator.Builds.BaseBuild;

namespace WutheringWavesCalculator.Builds;

public class CamellyaBuild(BaseCharacterStats character, WeaponStats weapon, EchoSet echoEchoSet, List<Buff> buffs) : CharacterBuild(character, weapon, echoEchoSet, buffs)
{
    protected override decimal CalculateRotationDamage()
    {
        var introSkill = AttackDamageElemental;
        
        var plungeAttack = BasicAttackDamage * 33m * 2 / 100;
        Weapon.OnBasicAttack();
        
        var resonanceSkillWhiteFirstPart = BasicAttackDamage * 113.62m / 100;
        Weapon.OnBasicAttack();
        
        var resonanceSkillWhiteSecondPart = BasicAttackDamage * 113.62m / 100;
        Weapon.OnBasicAttack();
        Weapon.OnResonanceSkillCast();

        var liberation = 1202.81m * AttackDamageElemental / 100;
        
        var rotation1 = BasicAttackRotation();

        var enhancedResonanceSkill = BasicAttackDamage * 1202.81m / 100;
        Weapon.OnConcertoConsumed();
        Weapon.OnResonanceSkillCast();

        var rotation2 = BasicAttackRotation(2);

        var resonanceSkillRed = BasicAttackDamage * 52.61m * 5 / 100;
        var echoDamage = (5 * 54.8m + 270.4m) * BasicAttackDamage / 100;
        
        var outroDamage = (329m + 459m) * AttackDamageElemental / 100;
        
        Weapon.Reset();

        return introSkill 
               + plungeAttack 
               + resonanceSkillWhiteFirstPart
               + resonanceSkillWhiteSecondPart
               + liberation
               + rotation1 
               + enhancedResonanceSkill 
               + rotation2 
               + resonanceSkillRed 
               + echoDamage
               + outroDamage;
    }
    
    protected override decimal GetBasicAttackDamageTotal()
    {
        var plungeAttack = BasicAttackDamage * 33m * 2 / 100;
        Weapon.OnBasicAttack();
        
        var resonanceSkillWhiteFirstPart = BasicAttackDamage * 113.62m / 100;
        Weapon.OnBasicAttack();
        
        var resonanceSkillWhiteSecondPart = BasicAttackDamage * 113.62m / 100;
        Weapon.OnBasicAttack();
        Weapon.OnResonanceSkillCast();
        
        var rotation1 = BasicAttackRotation();

        var enhancedResonanceSkill = BasicAttackDamage * 1202.81m / 100;
        Weapon.OnConcertoConsumed();
        Weapon.OnResonanceSkillCast();

        var rotation2 = BasicAttackRotation(2);

        var resonanceSkillRed = BasicAttackDamage * 52.61m * 5 / 100;
        
        Weapon.Reset();

        return plungeAttack 
               + resonanceSkillWhiteFirstPart 
               + resonanceSkillWhiteSecondPart 
               + rotation1 
               + enhancedResonanceSkill 
               + rotation2 
               + resonanceSkillRed;
    }
    
    private decimal BasicAttackRotation(decimal damageAmplifier = 1)
    {
        var attack1 = BasicAttackDamage * damageAmplifier * 96.33m / 100;
        var attack2 = BasicAttackDamage * damageAmplifier * 45.63m * 2 / 100;
        var attack3Hold = BasicAttackDamage * damageAmplifier * 21.95m * 19 / 100;
        var attack4 = BasicAttackDamage * damageAmplifier * 67.59m * 3 / 100;

        return attack1 + attack2 + attack3Hold + attack4;
    }
}