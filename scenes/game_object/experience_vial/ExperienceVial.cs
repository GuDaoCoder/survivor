using Godot;
using survivor.scenes.auto_load;

namespace survivor.scenes.game_object.experience_vial;

public partial class ExperienceVial : Node2D
{
    [Export] public Area2D Area2D;

    public override void _Ready()
    {
        Area2D.AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Node2D node2D)
    {
        GameEvents.Instance.EmitExperienceVialCollected(2f);
        // QueueFree();
    }
}