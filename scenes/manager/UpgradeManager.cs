using System;
using System.Collections.Generic;
using Godot;
using survivor.scenes.manager;

public partial class UpgradeManager : Node
{

    public List<AbilityUpgrade> UpgradePool;

    [Export]
    public ExperienceManager ExperienceManager;

    private Dictionary<string, AbilityUpgradeModel> _upgrades = new Dictionary<string, AbilityUpgradeModel>();

    public override void _Ready()
    {
        UpgradePool = new List<AbilityUpgrade>();
        UpgradePool.Add(ResourceLoader.Load<AbilityUpgrade>("res://resources/upgrades/sword_rate.tres"));

        ExperienceManager.LevelUp += OnLevelUp;
    }

    private void OnLevelUp(int newLevel)
    {
        AbilityUpgrade abilityUpgrade = UpgradePool[(int)GD.RandRange(0, UpgradePool.Count - 1)];
        if (abilityUpgrade != null)
        {
            UpgradeScene upgradeScene = GD.Load<PackedScene>("res://scenes/ui/upgrade_scene.tscn").Instantiate<UpgradeScene>();
            AddChild(upgradeScene);
            upgradeScene.SetUpgrades(new List<AbilityUpgrade> { abilityUpgrade });
            upgradeScene.CardSelectedUpgrade += OnCardSelectedAbilityUpgrade;
        }
    }

    private void OnCardSelectedAbilityUpgrade(AbilityUpgrade abilityUpgrade)
    {
        ApplyUpgrade(abilityUpgrade);
    }


    private void ApplyUpgrade(AbilityUpgrade abilityUpgrade)
    {
        if (!_upgrades.TryGetValue(abilityUpgrade.Id, out AbilityUpgradeModel value))
        {
            _upgrades.Add(abilityUpgrade.Id, new AbilityUpgradeModel(abilityUpgrade, 1));
        }
        else
        {
            value.Quantity++;
        }

        foreach (var kvp in _upgrades)
        {
            GD.Print(kvp.Value.ToString());
        }
    }

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

}

