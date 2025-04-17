using Godot;
using survivor.scenes.component;

namespace survivor.scenes.game_object.basic_enemy;

public partial class BasicEnemy : CharacterBody2D
{
    [Export] public HealthComponent HealthComponent;

    private const float MaxSpeed = 70f;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
        Velocity = GetDirectionToPlayer() * MaxSpeed;
        MoveAndSlide();
    }

    private Vector2 GetDirectionToPlayer()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        if (player != null)
        {
            return (player.GlobalPosition - GlobalPosition).Normalized();
        }

        return Vector2.Zero;
    }
}