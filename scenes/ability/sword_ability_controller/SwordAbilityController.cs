using System.Linq;
using Godot;

namespace survivor.scenes.ability.sword_ability_controller;

public partial class SwordAbilityController : Node
{
    [Export] public PackedScene SwordAbility;

    [Export] public float MaxRange = 100f;


    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        if (player == null)
        {
            return;
        }

        BasicEnemy enemy = GetTree().GetNodesInGroup("enemy").ToList().OfType<BasicEnemy>()
            .Where(enemy => player.GlobalPosition.DistanceTo(enemy.GlobalPosition) <= MaxRange)
            .OrderBy(enemy => player.GlobalPosition.DistanceSquaredTo(enemy.GlobalPosition)).FirstOrDefault();
        if (enemy == null)
        {
            return;
        }

        Node2D swordAbilityInstance = SwordAbility.Instantiate<Node2D>();
        swordAbilityInstance.GlobalPosition = enemy.GlobalPosition;
        player.GetParent().AddChild(swordAbilityInstance);
    }
}