using System;
using Godot;

namespace survivor.scenes.component;

public partial class HealthComponent : Node
{
    [Export] public float MaxHealth = 10f;

    [Signal]
    public delegate void DieEventHandler();

    public float CurrentHealth;

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth = Math.Max(CurrentHealth - damageAmount, 0);
        CallDeferred(nameof(CheckHealth));
    }

    private void CheckHealth()
    {
        if (CurrentHealth == 0)
        {
            EmitSignal(nameof(Die));
            Owner.QueueFree();
        }
    }
}