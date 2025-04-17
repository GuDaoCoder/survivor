using Godot;

namespace survivor.scenes.component;

public partial class HurtboxComponent : Area2D
{

    [Export]
    public HealthComponent HealthComponent;

    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D otherArea)
    {
        if (otherArea is HitboxComponent hitboxComponent && HealthComponent != null)
        {
            HealthComponent.Damage(hitboxComponent.Damage);
        }
    }
}