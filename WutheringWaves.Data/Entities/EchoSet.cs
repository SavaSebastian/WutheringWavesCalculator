namespace WutheringWaves.Data.Entities;

public abstract class EchoSet(List<Echo> echoes)
{
    private List<Echo> Echoes { get; set; } = echoes;
    protected decimal BonusElementalDamagePercentage { get; set; }
    protected decimal BonusCritRate { get; set; }
    protected decimal BonusCritDamage { get; set; }
    protected decimal BonusAttackPercentage { get; set; }
    protected decimal BonusAttackFlat { get; set; }
    protected decimal BonusBasicAttackPercentage { get; set; }

    public decimal ElementalDamagePercentage => Echoes.Sum(x => x.ElementalDamagePercentage) + BonusElementalDamagePercentage;
    public decimal CritRate => Echoes.Sum(x => x.CritRate) + BonusCritRate;
    public decimal CritDamage => Echoes.Sum(x => x.CritDamage) + BonusCritDamage;
    public decimal AttackPercentage => Echoes.Sum(x => x.AttackPercentage) + BonusAttackPercentage;
    public decimal AttackFlat => Echoes.Sum(x => x.AttackFlat) + BonusAttackFlat;
    public decimal BasicAttackPercentage => Echoes.Sum(x => x.BasicAttackPercentageRoll) + BonusBasicAttackPercentage;

    public virtual void OnResonanceSkillCast() {}
    public virtual void OnBasicAttack() {}
    public virtual void OnEchoCast() {}
    public virtual void Reset() {}

    public void DisplayValues()
    {
        Console.WriteLine("Stats gained from echoes: ");
        Console.WriteLine("ElementalDamagePercentage: " + ElementalDamagePercentage);
        Console.WriteLine("CritRate: " + CritRate);
        Console.WriteLine("CritDamage: " + CritDamage);
        Console.WriteLine("AttackPercentage: " + AttackPercentage);
        Console.WriteLine("AttackFlat: " + AttackFlat);
        Console.WriteLine("BasicAttackPercentage: " + BasicAttackPercentage);
    }
}