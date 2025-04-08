using Godot;

namespace survivor.scenes.ability.sword_ability_controller;

public partial class SwordAbilityController : Node
{
    [Export] public PackedScene SwordAbility;


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

        Node2D swordAbilityInstance = SwordAbility.Instantiate<Node2D>();
        swordAbilityInstance.GlobalPosition = player.GlobalPosition;
        player.GetParent().AddChild(swordAbilityInstance);
    }
}