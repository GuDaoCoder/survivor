using System;
using System.Collections.Generic;
using Godot;
using survivor.common.model;

namespace survivor.scenes.auto_load;

public partial class GameEvents : Node
{
    public static GameEvents Instance { get; private set; }

    [Signal]
    public delegate void ExperienceVialCollectedEventHandler(float experience);

    public event Action<AbilityUpgrade, Dictionary<string, AbilityUpgradeModel>> AbilityUpgradeAddEventHandler;


    public override void _Ready()
    {
        Instance = this;
    }

    public void EmitExperienceVialCollected(float experience)
    {
        EmitSignal(nameof(ExperienceVialCollected), experience);
    }

    public void EmitAbilityUpgradeAdd(AbilityUpgrade addAbilityUpgrade, Dictionary<string, AbilityUpgradeModel> currentAbilityUpgrades)
    {
        AbilityUpgradeAddEventHandler?.Invoke(addAbilityUpgrade, currentAbilityUpgrades);
    }
}