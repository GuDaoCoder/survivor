using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
    [Export] public Area2D DamageArea;

    private const float MaxSpeed = 70f;

    public override void _Ready()
    {
        DamageArea.AreaEntered += OnDamageAreaEntered;
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

    private void OnDamageAreaEntered(Area2D area)
    {
        QueueFree();
    }
}