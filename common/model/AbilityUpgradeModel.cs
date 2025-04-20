namespace survivor.common.model;

public class AbilityUpgradeModel
{
    public AbilityUpgradeModel(AbilityUpgrade abilityUpgrade, int quantity)
    {
        _abilityUpgrade = abilityUpgrade;
        Quantity = quantity;
    }


    public AbilityUpgrade _abilityUpgrade { set; get; }

    public int Quantity { set; get; }

    public override string ToString()
    {
        return $"{_abilityUpgrade.Name}：{Quantity}";
    }

}
