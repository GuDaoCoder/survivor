using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{

    [Signal]
    public delegate void SelectedUpgradeEventHandler(AbilityUpgrade abilityUpgrade);

    public Label NameLabel => GetNode<Label>("VBoxContainer/NameLabel");

    public Label DescriptionLabel => GetNode<Label>("VBoxContainer/DescriptionLabel");

    private AbilityUpgrade _abilityUpgrade;

    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    private void OnGuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("MouseLeftClick"))
        {
            EmitSignal(nameof(SelectedUpgrade), _abilityUpgrade);
        }
    }


    public void SetUpgrade(AbilityUpgrade abilityUpgrade)
    {
        _abilityUpgrade = abilityUpgrade;
        NameLabel.Text = abilityUpgrade.Name;
        DescriptionLabel.Text = abilityUpgrade.Description;
    }

}
