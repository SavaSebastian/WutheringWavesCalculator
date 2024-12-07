using WutheringWaves.Data.Entities;
using WutheringWavesCalculator.Helpers;

namespace WutheringWavesCalculator.Builds.BaseBuild;

public abstract class CharacterBuild(BaseCharacterStats character, WeaponStats weapon, EchoSet echoSet, List<Buff> buffs)
{
    protected List<Buff> Buffs { get; set; } = buffs;
    protected EchoSet EchoSet { get; } = echoSet;
    protected WeaponStats Weapon { get; } = weapon;
    protected BaseCharacterStats Character { get; } = character;
    
    protected decimal AttackDamageElemental => DamageHelper.CalculateFinalAttackDamage(Character, Weapon, EchoSet, Buffs);
    protected decimal BasicAttackDamage => DamageHelper.CalculateFinalBasicAttackDamage(Character, Weapon, EchoSet, Buffs);

    public decimal AutoAttackDamageTotal => GetBasicAttackDamageTotal();
    public decimal RotationDamage => CalculateRotationDamage();
    
    // Method to calculate rotation damage
    protected abstract decimal CalculateRotationDamage();

    protected virtual decimal GetBasicAttackDamageTotal()
    {
        return 0;
    }
}