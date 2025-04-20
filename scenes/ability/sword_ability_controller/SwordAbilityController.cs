using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using survivor.common.model;
using survivor.scenes.auto_load;

namespace survivor.scenes.ability.sword_ability_controller;

public partial class SwordAbilityController : Node
{

    public Timer Timer => GetNode<Timer>("Timer");

    [Export] public PackedScene SwordAbility;

    [Export] public float MaxRange = 100f;

    [Export] public float Damage = 10f;

    private float _baseWaitTime = 1.5f;

    public override void _Ready()
    {
        Timer.WaitTime = _baseWaitTime;
        Timer.Timeout += OnTimerTimeout;

        GameEvents.Instance.AbilityUpgradeAddEventHandler += OnAbilityUpgradeAdd;
    }

    private void OnAbilityUpgradeAdd(AbilityUpgrade upgrade, Dictionary<string, AbilityUpgradeModel> dictionary)
    {
        if (upgrade.Id == "sword_rate")
        {
            if (dictionary.TryGetValue(upgrade.Id, out AbilityUpgradeModel value))
            {
                Timer.WaitTime = _baseWaitTime * (1 - value.Quantity * 0.1f);
                Timer.Start();
            }
        }
    }


    private void OnTimerTimeout()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        if (player == null)
        {
            return;
        }

        game_object.basic_enemy.BasicEnemy enemy = GetTree().GetNodesInGroup("enemy").ToList().OfType<game_object.basic_enemy.BasicEnemy>()
            .Where(enemy => player.GlobalPosition.DistanceTo(enemy.GlobalPosition) <= MaxRange)
            .OrderBy(enemy => player.GlobalPosition.DistanceSquaredTo(enemy.GlobalPosition)).FirstOrDefault();
        if (enemy == null)
        {
            return;
        }

        sword_ability.SwordAbility swordAbilityInstance = SwordAbility.Instantiate<sword_ability.SwordAbility>();
        swordAbilityInstance.GlobalPosition = enemy.GlobalPosition;
        swordAbilityInstance.GlobalPosition += Vector2.Right.Rotated((float)GD.RandRange(0, float.Tau)) * 4;
        swordAbilityInstance.Rotation = (enemy.GlobalPosition - swordAbilityInstance.GlobalPosition).Angle();
        swordAbilityInstance.HitboxComponent.Damage = Damage;
        player.GetParent().AddChild(swordAbilityInstance);
    }
}