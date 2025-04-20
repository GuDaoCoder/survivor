using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeScene : CanvasLayer
{

    public HBoxContainer CardContainer => GetNode<HBoxContainer>("MarginContainer/CardContainer");

    public override void _Ready()
    {
        GetTree().Paused = true;
    }

    public void SetUpgrades(List<AbilityUpgrade> abilityUpgrades)
    {
        foreach (AbilityUpgrade abilityUpgrade in abilityUpgrades)
        {
            AbilityUpgradeCard card = GD.Load<PackedScene>("res://scenes/ui/ability_upgrade_card.tscn").Instantiate<AbilityUpgradeCard>();
            CardContainer.AddChild(card);
            card.SetUpgrade(abilityUpgrade);
        }
    }
}
