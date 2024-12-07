namespace WutheringWaves.Data.Entities;

public abstract class Echo
{
    protected Echo(decimal critRoll = 0, decimal critDamageRoll = 0, decimal flatAttackRoll = 0, decimal attackPercentageRoll = 0, decimal basicAttackPercentageRoll = 0)
    {
        CritRate += critRoll;
        CritDamage += critDamageRoll;
        AttackFlat += flatAttackRoll;
        AttackPercentage += attackPercentageRoll;
        BasicAttackPercentageRoll += basicAttackPercentageRoll;
    }

    protected Echo()
    {
    }

    public decimal CritRate { get; protected init; }
    public decimal CritDamage { get; protected init; }
    public decimal AttackFlat { get; protected init; }
    public decimal AttackPercentage { get; protected init; }
    public decimal ElementalDamagePercentage { get; protected init; }
    public decimal BasicAttackPercentageRoll { get; set; }
}