using System.Diagnostics;
using WutheringWaves.Data.Entities;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.SpecificData.Echoes.Set;

namespace WutheringWavesCalculator.Helpers;

public static class EchoHelper
{
    public static decimal GetMainStatPercentage(EchoCost echoCost, EchoType echoType)
    {
        return echoCost switch
        {
            EchoCost.One => echoType switch
            {
                EchoType.AttackPercentage => 18m,
                EchoType.HealthPercentage => 22.8m,
                _ => throw new UnreachableException($"{echoCost} cannot have main stat {echoType}")
            },
            EchoCost.Three => echoType switch
            {
                EchoType.AttackPercentage => 30m,
                EchoType.ElementalDamage => 30m,
                EchoType.EnergyRegen => 32m,
                _ => throw new UnreachableException($"{echoCost} cannot have main stat {echoType}")
            },
            EchoCost.Four => echoType switch
            {
                EchoType.AttackPercentage => 33m,
                EchoType.CritRate => 22m,
                EchoType.CritDamage => 44m,
                _ => throw new UnreachableException($"{echoCost} cannot have main stat {echoType}")
            },
            _ => throw new UnreachableException($"{echoCost} cannot have main stat {echoType}")
        };
    }

    public static decimal GetMainSubStatAttackValue(EchoCost echoCost)
    {
        return echoCost switch
        {
            EchoCost.One => 0,
            EchoCost.Three => 100,
            EchoCost.Four => 150,
            _ => throw new UnreachableException($"{echoCost}, something went terribly wrong")
        };
    }
    
    public static EchoSet CreateEchoSet(Echo echo1, Echo echo2, Echo echo3, Echo echo4, Echo echo5, EchoSetType echoSetType)
    {
        return echoSetType switch
        {
            EchoSetType.SunSinkingEclipse => new SunSinkingEclipseEchoSet([echo1, echo2, echo3, echo4, echo5 ]),
            EchoSetType.MoltenRift => new MoltenRiftEchoSet([echo1, echo2, echo3, echo4, echo5]),
            EchoSetType.LingeringTunes => new LingeringTunesEchoSet([echo1, echo2, echo3, echo4, echo5]),
            _ => throw new ArgumentException("Invalid echo set type")
        };
    }
}