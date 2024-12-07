namespace WutheringWaves.Data.Entities;

public abstract class WeaponStats
{
    public decimal BaseAttack { get; protected set; }
    public decimal CritRate { get; protected set; }
    public decimal CritDamage { get; protected set; }
    public decimal AttackDamagePercentage { get; protected set; }
    public decimal ElementalDamagePercentage { get; protected set; }
    public decimal BasicAttackPercentage { get; protected set; }
    
    
    public int RefinementRank { get; set; }

    public virtual void OnBasicAttack() {}
    public virtual void OnConcertoConsumed() {}
    public virtual void OnResonanceSkillCast() {}
    public virtual void OnCharacterLeaveField() {}
    public virtual void Reset() {}
}