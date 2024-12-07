namespace WutheringWaves.Data.Entities;

public abstract class BaseCharacterStats
{
    private decimal BaseCritRate { get; init; } = 5;
    private decimal BaseCritDamage { get; init; } = 150;
    public decimal BaseAttackDamage { get; protected init; }
    
    // Character-specific
    public int RefinementRank { get; set; }
    protected decimal BonusCritDamage { get; set; }
    protected decimal BonusCritRate { get; set; }
    
    // Final stats
    public decimal CritRate => BaseCritRate + BonusCritRate;
    public decimal CritDamage => BaseCritDamage + BonusCritDamage;
    public decimal ElementalDamagePercentage { get; protected set; }
    public decimal AttackDamagePercentage { get; protected init; }
    public decimal BasicAttackDamagePercentage { get; protected init; }
    
    
    // Events
    public virtual void OnResonanceSkillCast() {}
    public virtual void OnLiberationSkillCast() {}
    public virtual void Reset() {}
}