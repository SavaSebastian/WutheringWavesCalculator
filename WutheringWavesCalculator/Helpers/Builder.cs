using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.SpecificData.Characters;
using WutheringWavesCalculator.SpecificData.Echoes.FourCost;
using WutheringWavesCalculator.SpecificData.Echoes.OneCost;
using WutheringWavesCalculator.SpecificData.Echoes.ThreeCost;
using WutheringWavesCalculator.SpecificData.Weapons;

namespace WutheringWavesCalculator.Helpers;

public static class Builder
{
    public static (BaseCharacterStats, WeaponStats, EchoSet) InitializeCharacterData(Characters characterType, Weapons weaponType)
    {
        var character = CreateCharacter(characterType);
        var weapon = CreateWeapon(weaponType);
        var echoSet = CreateEchoSetForCharacter(characterType); // EchoSet logic tied to the character (can be adjusted as needed)

        return (character, weapon, echoSet);
    }
    
    private static BaseCharacterStats CreateCharacter(Characters characterType)
    {
        return characterType switch
        {
            Characters.Camelia => new Camellya(0),
            Characters.Encore => new Encore(0),
            _ => throw new ArgumentException("Invalid character type")
        };
    }

    private static WeaponStats CreateWeapon(Weapons weaponType, int refinementRank = 0)
    {
        return weaponType switch
        {
            Weapons.RedSpring => new RedSpring(refinementRank),
            Weapons.CosmicRipples => new CosmicRipples(refinementRank),
            Weapons.StringMaster => new Stringmaster(refinementRank),
            Weapons.EmeraldOfGenesis => new EmeraldOfGenesis(refinementRank),
            _ => throw new ArgumentException("Invalid weapon type")
        };
    }

    private static EchoSet CreateEchoSetForCharacter(Characters characterType)
    {
        return characterType switch
        {
            Characters.Camelia => EchoHelper.CreateEchoSet(
                new FourCostCritRateEcho(6.3m, 12.6m, flatAttackRoll: 40),
                new ThreeCostAttackDamageEcho(7.5m, 13.8m, basicAttackPercentageRoll: 7.1m),
                new ThreeCostElementalDamageEcho(6.9m, 12.6m),
                new OneCostAttackDamageEcho(6.3m, 12.6m, 50),
                new OneCostAttackDamageEcho(6.9m, 13.8m, basicAttackPercentageRoll: 9.4m),
                EchoSetType.SunSinkingEclipse),
            
            Characters.Encore => EchoHelper.CreateEchoSet(
                new FourCostCritDamageEcho(6.3m, 17.4m, basicAttackPercentageRoll: 10.9m),
                new ThreeCostElementalDamageEcho(9.3m, 17.4m, basicAttackPercentageRoll: 8.6m, attackPercentageRoll: 7.9m),
                new ThreeCostElementalDamageEcho(7.5m, 12.6m, basicAttackPercentageRoll: 8.6m),
                new OneCostAttackDamageEcho(6.3m, 15m, basicAttackPercentageRoll: 7.1m),
                new OneCostAttackDamageEcho(6.3m, 18.6m),
                EchoSetType.MoltenRift),
            
            _ => throw new ArgumentException("Invalid character type for echo set")
        };
    }
}