using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{

    public Label NameLabel => GetNode<Label>("VBoxContainer/NameLabel");

    public Label DescriptionLabel => GetNode<Label>("VBoxContainer/DescriptionLabel");

    public override void _Ready()
    {
    }

    public void SetUpgrade(AbilityUpgrade abilityUpgrade)
    {
        NameLabel.Text = abilityUpgrade.Name;
        DescriptionLabel.Text = abilityUpgrade.Description;
    }

}
