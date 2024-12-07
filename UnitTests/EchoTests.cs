using FluentAssertions;
using WutheringWaves.Data.Enums;
using WutheringWavesCalculator.Helpers;
using WutheringWavesCalculator.SpecificData.Echoes.Blank;
using WutheringWavesCalculator.SpecificData.Echoes.FourCost;
using WutheringWavesCalculator.SpecificData.Echoes.OneCost;
using WutheringWavesCalculator.SpecificData.Echoes.Set;
using WutheringWavesCalculator.SpecificData.Echoes.ThreeCost;

namespace UnitTests;

[TestFixture]
public class EchoTests
{
    [Test]
    public void AllEchoClasses_ShouldInitializeCorrectly()
    {
        var oneCostAttackDamageEcho = new OneCostAttackDamageEcho(critRoll: 5m, flatAttackRoll: 20m);
        oneCostAttackDamageEcho.CritRate.Should().Be(5m);
        oneCostAttackDamageEcho.AttackFlat.Should().Be(20m + EchoHelper.GetMainSubStatAttackValue(EchoCost.One));
        oneCostAttackDamageEcho.AttackPercentage.Should().Be(EchoHelper.GetMainStatPercentage(EchoCost.One, EchoType.AttackPercentage));
        oneCostAttackDamageEcho.ElementalDamagePercentage.Should().Be(0m);
        oneCostAttackDamageEcho.CritDamage.Should().Be(0m);
        oneCostAttackDamageEcho.BasicAttackPercentageRoll.Should().Be(0m);
            
        var threeCostAttackDamageEcho = new ThreeCostAttackDamageEcho(attackPercentageRoll: 10m);
        threeCostAttackDamageEcho.AttackPercentage.Should().Be(EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.AttackPercentage) + 10m);
        threeCostAttackDamageEcho.AttackFlat.Should().Be(EchoHelper.GetMainSubStatAttackValue(EchoCost.Three));
        threeCostAttackDamageEcho.CritRate.Should().Be(0m);
        threeCostAttackDamageEcho.CritDamage.Should().Be(0m);
        threeCostAttackDamageEcho.ElementalDamagePercentage.Should().Be(0m);
        threeCostAttackDamageEcho.BasicAttackPercentageRoll.Should().Be(0m);
            
        var threeCostElementalDamageEcho = new ThreeCostElementalDamageEcho(basicAttackPercentageRoll: 10m);
        threeCostElementalDamageEcho.ElementalDamagePercentage.Should().Be(EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.ElementalDamage));
        threeCostElementalDamageEcho.BasicAttackPercentageRoll.Should().Be(10m);
        threeCostElementalDamageEcho.CritRate.Should().Be(0m);
        threeCostElementalDamageEcho.CritDamage.Should().Be(0m);
        threeCostElementalDamageEcho.AttackFlat.Should().Be(EchoHelper.GetMainSubStatAttackValue(EchoCost.Three));
        threeCostElementalDamageEcho.AttackPercentage.Should().Be(0m);
            
        var fourCostAttackDamageEcho = new FourCostAttackDamageEcho(attackPercentageRoll: 15m);
        fourCostAttackDamageEcho.AttackPercentage.Should().Be(EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.AttackPercentage) + 15m);
        fourCostAttackDamageEcho.AttackFlat.Should().Be(EchoHelper.GetMainSubStatAttackValue(EchoCost.Four));
        fourCostAttackDamageEcho.CritRate.Should().Be(0m);
        fourCostAttackDamageEcho.CritDamage.Should().Be(0m);
        fourCostAttackDamageEcho.ElementalDamagePercentage.Should().Be(0m);
        fourCostAttackDamageEcho.BasicAttackPercentageRoll.Should().Be(0m);
            
        var fourCostCritRateEcho = new FourCostCritRateEcho(critRoll: 5m);
        fourCostCritRateEcho.CritRate.Should().Be(EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritRate) + 5m);
        fourCostCritRateEcho.AttackFlat.Should().Be(EchoHelper.GetMainSubStatAttackValue(EchoCost.Four));
        fourCostCritRateEcho.AttackPercentage.Should().Be(0m);
        fourCostCritRateEcho.CritDamage.Should().Be(0m);
        fourCostCritRateEcho.ElementalDamagePercentage.Should().Be(0m);
        fourCostCritRateEcho.BasicAttackPercentageRoll.Should().Be(0m);
            
        var fourCostCritDamageEcho = new FourCostCritDamageEcho(critDamageRoll: 15m);
        fourCostCritDamageEcho.CritDamage.Should().Be(15m + EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritDamage));
        fourCostCritDamageEcho.CritRate.Should().Be(0m);
        fourCostCritDamageEcho.ElementalDamagePercentage.Should().Be(0m);
        fourCostCritDamageEcho.AttackFlat.Should().Be(EchoHelper.GetMainSubStatAttackValue(EchoCost.Four));
        fourCostCritDamageEcho.AttackPercentage.Should().Be(0m);
        fourCostCritDamageEcho.BasicAttackPercentageRoll.Should().Be(0m);
    }


    [Test]
    public void EchoSets_ShouldAddEchoesCorrectly()
    {
        // Create echoes with specific stats
        var echo1 = new OneCostAttackDamageEcho(critRoll: 5.9m, critDamageRoll: 12.1m, flatAttackRoll: 41m, attackPercentageRoll: 10.1m, basicAttackPercentageRoll: 10m);
        var echo2 = new ThreeCostElementalDamageEcho(critRoll: 6m, critDamageRoll: 12m, flatAttackRoll: 40m, attackPercentageRoll: 10.2m, basicAttackPercentageRoll: 10.1m);
        var echo3 = new FourCostCritRateEcho(critRoll: 10m, critDamageRoll: 8m, flatAttackRoll: 50m, attackPercentageRoll: 15m, basicAttackPercentageRoll: 12m);
        var echo4 = new ThreeCostAttackDamageEcho(critRoll: 7.5m, critDamageRoll: 10.5m, flatAttackRoll: 35m, attackPercentageRoll: 12.5m, basicAttackPercentageRoll: 5m);
        var echo5 = new FourCostCritDamageEcho(critRoll: 9m, critDamageRoll: 12m, flatAttackRoll: 60m, attackPercentageRoll: 20m, basicAttackPercentageRoll: 8m);

        // Create EchoSet
        var sunSet = EchoHelper.CreateEchoSet(echo1, echo2, echo3, echo4, echo5, EchoSetType.SunSinkingEclipse);

        // Calculate expected totals
        var expectedCritRate = echo1.CritRate + echo2.CritRate + echo3.CritRate + echo4.CritRate + echo5.CritRate;
        var expectedCritDamage = echo1.CritDamage + echo2.CritDamage + echo3.CritDamage + echo4.CritDamage + echo5.CritDamage;
        var expectedAttackFlat = echo1.AttackFlat + echo2.AttackFlat + echo3.AttackFlat + echo4.AttackFlat + echo5.AttackFlat;
        var expectedAttackPercentage = echo1.AttackPercentage + echo2.AttackPercentage + echo3.AttackPercentage + echo4.AttackPercentage + echo5.AttackPercentage;
        var expectedElementalDamagePercentage = echo1.ElementalDamagePercentage + echo2.ElementalDamagePercentage + echo3.ElementalDamagePercentage + echo4.ElementalDamagePercentage + echo5.ElementalDamagePercentage + 40m;
        var expectedBasicAttackPercentage = echo1.BasicAttackPercentageRoll + echo2.BasicAttackPercentageRoll + echo3.BasicAttackPercentageRoll + echo4.BasicAttackPercentageRoll + echo5.BasicAttackPercentageRoll;

        // Assertions
        sunSet.ElementalDamagePercentage.Should().Be(expectedElementalDamagePercentage);
        sunSet.CritRate.Should().Be(expectedCritRate);
        sunSet.CritDamage.Should().Be(expectedCritDamage);
        sunSet.AttackFlat.Should().Be(expectedAttackFlat);
        sunSet.AttackPercentage.Should().Be(expectedAttackPercentage);
        sunSet.BasicAttackPercentage.Should().Be(expectedBasicAttackPercentage);
    }


    [Test]
    public void BlankEcho_ShouldInitializeCorrectly()
    {
        var blankEcho = new BlankEcho(elementalDamagePercentage: 30m, basicAttackPercentage: 20m, attackPercentage: 15m);

        blankEcho.ElementalDamagePercentage.Should().Be(30m);
        blankEcho.BasicAttackPercentageRoll.Should().Be(20m);
        blankEcho.AttackPercentage.Should().Be(15m);
    }

    [Test]
    public void EchoHelper_ShouldReturnCorrectMainStats()
    {
        EchoHelper.GetMainStatPercentage(EchoCost.One, EchoType.AttackPercentage).Should().Be(18m);
        EchoHelper.GetMainStatPercentage(EchoCost.One, EchoType.HealthPercentage).Should().Be(22.8m);
            
        EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.AttackPercentage).Should().Be(30m);
        EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.ElementalDamage).Should().Be(30m);
        EchoHelper.GetMainStatPercentage(EchoCost.Three, EchoType.EnergyRegen).Should().Be(32m);
            
        EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.AttackPercentage).Should().Be(33m);
        EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritRate).Should().Be(22m);
        EchoHelper.GetMainStatPercentage(EchoCost.Four, EchoType.CritDamage).Should().Be(44m);
    }


    [Test]
    public void EchoHelper_ShouldReturnCorrectMainSubStatAttackValue()
    {
        EchoHelper.GetMainSubStatAttackValue(EchoCost.One).Should().Be(0);
        EchoHelper.GetMainSubStatAttackValue(EchoCost.Three).Should().Be(100);
        EchoHelper.GetMainSubStatAttackValue(EchoCost.Four).Should().Be(150);
    }

    [Test]
    public void EchoSetFactory_ShouldCreateCorrectSetType()
    {
        var echo1 = new OneCostAttackDamageEcho();
        var echo2 = new ThreeCostElementalDamageEcho();
        var echo3 = new FourCostCritRateEcho();
        var echo4 = new ThreeCostAttackDamageEcho();
        var echo5 = new FourCostCritDamageEcho();

        var moltenRiftSet = EchoHelper.CreateEchoSet(echo1, echo2, echo3, echo4, echo5, EchoSetType.MoltenRift);
        moltenRiftSet.Should().BeOfType<MoltenRiftEchoSet>();

        var lingeringTunesSet = EchoHelper.CreateEchoSet(echo1, echo2, echo3, echo4, echo5, EchoSetType.LingeringTunes);
        lingeringTunesSet.Should().BeOfType<LingeringTunesEchoSet>();

        var sunSinkingEclipseSet = EchoHelper.CreateEchoSet(echo1, echo2, echo3, echo4, echo5, EchoSetType.SunSinkingEclipse);
        sunSinkingEclipseSet.Should().BeOfType<SunSinkingEclipseEchoSet>();
    }
}