using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Builds;
using WutheringWavesCalculator.Builds.BaseBuild;

namespace WutheringWavesCalculator.Helpers;

public static class DamageHelper
{
    public static decimal DisplayDamageStatistics(BaseCharacterStats character, WeaponStats weapon, EchoSet echoSet,
        List<Buff> buffs, CharacterBuild? build = null)
    {
        var critRate = CalculateCritRate(character, weapon, echoSet);
        var critDamage = CalculateCritDamage(character, weapon, echoSet);
        var attackDamage = CalculateFinalAttackDamage(character, weapon, echoSet, buffs);
        var basicAttackDamage = CalculateFinalBasicAttackDamage(character, weapon, echoSet, buffs);

        var finalDamage = CalculateFinalDamage(attackDamage, critRate, critDamage);
        var finalBasicAttackDamage = CalculateFinalDamage(basicAttackDamage, critRate, critDamage);

        Console.WriteLine($"Crit rate: {critRate}");
        Console.WriteLine($"Crit Damage: {critDamage}");
        Console.WriteLine($"Final attack damage (actual value used for multipliers): {attackDamage:N0}");
        Console.WriteLine($"Final basic attack damage (actual value used for multipliers): {basicAttackDamage:N0}");
        Console.WriteLine($"Damage multiplier from crit: {critRate * critDamage / 100 + 100 - critRate:F2}");
        Console.WriteLine($"Final damage (actual value used for multiplier including crit calculations): {finalDamage:N0}");
        Console.WriteLine($"Final basic attack damage (actual value used for multiplier including crit calculations): {finalBasicAttackDamage:N0}" + Environment.NewLine);

        if (build is null) return 0;

        Console.WriteLine($"Rotation damage: {CalculateFinalDamage(build.RotationDamage, critRate, critDamage):N0}");
        Console.WriteLine($"Auto attack damage total: {CalculateFinalDamage(build.AutoAttackDamageTotal, critRate, critDamage):N0}");
        Console.WriteLine($"Basic attack damage percentage: {build.AutoAttackDamageTotal / build.RotationDamage:F2}");

        return CalculateFinalDamage(build.RotationDamage, critRate, critDamage);
    }
    
    public static void CompareCharacterWithWeapons(Characters characterType, List<Weapons> weaponTypes, List<Buff> buffs)
    {
        Console.WriteLine($"Comparing stats for {characterType} with different weapons:" + Environment.NewLine);

        var rotationsDamage = new SortedDictionary<decimal, string>();

        foreach (var weaponType in weaponTypes)
        {
            Console.WriteLine($"Weapon : {weaponType.ToString()}" + Environment.NewLine);
            
            var (character, weapon, echoSet) = Builder.InitializeCharacterData(characterType, weaponType);
            
            CharacterBuild build = characterType switch
            {
                Characters.Camelia => new CamellyaBuild(character, weapon, echoSet, buffs),
                Characters.Encore => new EncoreBuild(character, weapon, echoSet, buffs),
                _ => throw new ArgumentOutOfRangeException(nameof(characterType), characterType, null)
            };

            var rotationDamage = DisplayDamageStatistics(character, weapon, echoSet, buffs, build);

            rotationsDamage.Add(rotationDamage, weaponType.ToString());
            
            Console.WriteLine(Environment.NewLine);
        }

        Console.WriteLine("Damage difference between rotations" + Environment.NewLine);

        foreach (var (damage, name) in rotationsDamage)
        {
            var percentage = damage / rotationsDamage.Keys.Min() * 100;
            
            Console.WriteLine($"{name}: {damage:N0} ({percentage:F2}%)");
        }

        Console.WriteLine(Environment.NewLine);
    }
    
    public static decimal CalculateCritRate(BaseCharacterStats character, WeaponStats weapon, EchoSet echoSet)
    {
        var critRate = character.CritRate
                       + echoSet.CritRate
                       + weapon.CritRate;
        
        return critRate > 100 ? 100 : critRate;
    }

    public static decimal CalculateCritDamage(BaseCharacterStats character, WeaponStats weapon, EchoSet echo)
    {
        return character.CritDamage 
               + echo.CritDamage 
               + weapon.CritDamage;
    }

    public static decimal CalculateFinalAttackDamage(BaseCharacterStats character, WeaponStats weapon, EchoSet echo, List<Buff> buffs)
    {
        var baseAttackDamage = character.BaseAttackDamage + weapon.BaseAttack;
        
        var attackMultiplier = 1 
                               + (weapon.AttackDamagePercentage 
                                  + character.AttackDamagePercentage 
                                  + echo.AttackPercentage
                                  + BuffHelper.GetAttackDamagePercentageBuff(buffs)) / 100;
        
        var elementalMultiplier = 1 + (echo.ElementalDamagePercentage + character.ElementalDamagePercentage) / 100;
        
        var finalAttackDamage = (baseAttackDamage * attackMultiplier + echo.AttackFlat) * elementalMultiplier * (1 + BuffHelper.GetTotalDamageBuff(buffs) / 100);

        return finalAttackDamage;
    }

    public static decimal CalculateFinalBasicAttackDamage(BaseCharacterStats baseCharacter, WeaponStats weapon, EchoSet echo, List<Buff> buffs)
    {
        var baseAttackDamage = baseCharacter.BaseAttackDamage + weapon.BaseAttack;
        
        var attackMultiplier = 1 + (weapon.AttackDamagePercentage 
                                    + baseCharacter.AttackDamagePercentage 
                                    + echo.AttackPercentage 
                                    + BuffHelper.GetAttackDamagePercentageBuff(buffs)) / 100;
        
        var elementalMultiplier = 1 
                                  + (baseCharacter.ElementalDamagePercentage 
                                     + baseCharacter.BasicAttackDamagePercentage 
                                     + weapon.ElementalDamagePercentage
                                     + weapon.BasicAttackPercentage 
                                     + echo.ElementalDamagePercentage
                                     + echo.BasicAttackPercentage) / 100;
        
        var finalAttackDamage = (baseAttackDamage * attackMultiplier + echo.AttackFlat) * elementalMultiplier * (1 + BuffHelper.GetTotalBasicAttackPercentageBuff(buffs) / 100);

        return finalAttackDamage;
    }

    public static decimal CalculateFinalDamage(decimal baseDamage, decimal critRate, decimal critDamage)
    {
        return baseDamage * (critRate * critDamage / 100 + (100 - critRate)) / 100;
    }
}