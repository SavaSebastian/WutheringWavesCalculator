namespace WutheringWaves.Data.Entities;

public abstract class Buff
{
    public decimal AttackDamagePercentageBuff { get; set; }
    public decimal BasicAttackPercentageBuff { get; set; }
    public decimal ElementalPercentageBuff { get; set; }
    public decimal CritRatePercentageBuff { get; set; }
    public decimal CritDamagePercentageBuff { get; set; }
    public decimal TotalDamagePercentageBuff { get; set; }
    public decimal TotalBasicAttackPercentageBuff { get; set; }
}