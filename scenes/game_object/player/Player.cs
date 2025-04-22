using System;
using Godot;
using survivor.scenes.component;

public partial class Player : CharacterBody2D
{
    [Export] public float MaxSpeed = 125f;

    [Export] public float AccelerationSmoothing = 15f;

    public Area2D CollisionAreaInstance => GetNode<Area2D>("CollisionArea2D");

    public Timer DamageIntervalTimerInstance => GetNode<Timer>("DamageIntervalTimer");

    public HealthComponent HealthComponentInstance => GetNode<HealthComponent>("HealthComponent");

    private int numberCollidingBodies = 0;

    public override void _Ready()
    {
        // todo:?
        CollisionAreaInstance.CollisionMask = 4;
        CollisionAreaInstance.AreaEntered += OnBodyEntered;
        CollisionAreaInstance.AreaExited += OnBodyExited;
        DamageIntervalTimerInstance.Timeout += OnDamageIntervalTimeout;
    }

    private void OnDamageIntervalTimeout()
    {
        CheckDealDamage();
    }


    private void OnBodyExited(Area2D area)
    {
        numberCollidingBodies--;
    }



    private void OnBodyEntered(Area2D area)
    {
        numberCollidingBodies++;
        CheckDealDamage();
    }


    private void CheckDealDamage()
    {
        if (numberCollidingBodies > 0 && DamageIntervalTimerInstance.IsStopped())
        {
            HealthComponentInstance.Damage(1);
            DamageIntervalTimerInstance.Start();
            GD.Print($"player health: {HealthComponentInstance.CurrentHealth}");
        }
    }

    public override void _Process(double delta)
    {
        Vector2 direction = GetMovementVector().Normalized();
        Vector2 targetVelocity = direction * MaxSpeed;
        Velocity = Velocity.Lerp(targetVelocity, 1 - float.Exp(-(float)delta * AccelerationSmoothing));
        MoveAndSlide();
    }

    private Vector2 GetMovementVector()
    {
        float xMovement = Input.GetActionStrength("MoveRight") - Input.GetActionStrength("MoveLeft");
        float yMovemment = Input.GetActionStrength("MoveDown") - Input.GetActionStrength("MoveUp");
        return new Vector2(xMovement, yMovemment);
    }
}