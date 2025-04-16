using System;
using Godot;

namespace survivor.scenes.component;

public partial class HealthComponent : Node
{
    [Export] public float MaxHealth = 10f;

    [Signal]
    public delegate void DieEventHandler();

    private float _currentHealth;

    public override void _Ready()
    {
        _currentHealth = MaxHealth;
    }

    public void Damage(float damageAmount)
    {
        _currentHealth = Math.Max(_currentHealth - damageAmount, 0);
        GD.Print($"当前血量：{_currentHealth}");
        CallDeferred(nameof(CheckHealth));
    }

    private void CheckHealth()
    {
        if (_currentHealth == 0)
        {
            EmitSignal(nameof(Die));
            Owner.QueueFree();
        }
    }
}