using WutheringWaves.Data.Entities;
using WutheringWavesCalculator.Builds.BaseBuild;

namespace WutheringWavesCalculator.Builds;

public class EncoreBuild(BaseCharacterStats character, WeaponStats weapon, EchoSet echoSet, List<Buff> buffs) : CharacterBuild(character, weapon, echoSet, buffs)
{
    protected override decimal CalculateRotationDamage()
    {
        var intro = AttackDamageElemental;
        
        var echo = (242.4m + 282.8m + 282.8m) * AttackDamageElemental / 100;
        EchoSet.OnEchoCast();
        
        var resonance1 = 76.61m * 8 * AttackDamageElemental / 100;
        Weapon.OnResonanceSkillCast();
        Character.OnResonanceSkillCast();
        EchoSet.OnResonanceSkillCast();
        
        Character.OnLiberationSkillCast();
        
        var rotation1 = BasicAttackRotation();
        var resonance2 = 63.32m * 4 * AttackDamageElemental / 100;
        Weapon.OnResonanceSkillCast();
        
        var rotation2 = BasicAttackRotation();
        var rotation3 = BasicAttackRotation();
        var resonance3 = 63.32m * 4 * AttackDamageElemental / 100;
        
        Weapon.OnCharacterLeaveField();

        var forte = (23.35m * 6 + 249.08m) * AttackDamageElemental / 100;
        
        var outro = 176.76m * 4 * AttackDamageElemental / 100;
        
        Weapon.Reset();
        Character.Reset();
        EchoSet.Reset();

        return intro
               + echo
               + resonance1
               + rotation1
               + resonance2
               + rotation2
               + rotation3
               + resonance3
               + forte
               + outro;
    }

    protected override decimal GetBasicAttackDamageTotal()
    {
        EchoSet.OnEchoCast();
        
        Weapon.OnResonanceSkillCast();
        EchoSet.OnResonanceSkillCast();
        Character.OnResonanceSkillCast();
        
        Character.OnLiberationSkillCast();
        
        var rotation1 = BasicAttackRotation();
        Weapon.OnResonanceSkillCast();
        
        var rotation2 = BasicAttackRotation();
        var rotation3 = BasicAttackRotation();
        Weapon.OnResonanceSkillCast();

        Weapon.Reset();
        Character.Reset();
        EchoSet.Reset();
        
        return rotation1 + rotation2 + rotation3;
    }
    
    private decimal BasicAttackRotation()
    {
        var attack1 = 90.18m * 2 * BasicAttackDamage / 100;
        Weapon.OnBasicAttack();
        
        var attack2 = 56.4m * 3 * BasicAttackDamage / 100;
        Weapon.OnBasicAttack();
        
        var attack3 = 65.99m * 4 * BasicAttackDamage / 100;
        Weapon.OnBasicAttack();
        
        var attack4 = 194.01m * 3 * BasicAttackDamage / 100;
        Weapon.OnBasicAttack();

        return attack1
               + attack2
               + attack3
               + attack4;
    }
}