using Godot;
using survivor.scenes.component;
using survivor.scenes.game_object.experience_vial;

namespace survivor;

public partial class VailDropComponent : Node
{
    [Export] public HealthComponent HealthComponent;

    [Export] public PackedScene ExperienceVailScene;

    public override void _Ready()
    {
        HealthComponent.Die += OnDie;
    }

    public void OnDie()
    {
        if (ExperienceVailScene == null)
        {
            return;
        }

        if (Owner is Node2D node)
        {
            ExperienceVial experienceVial = ExperienceVailScene.Instantiate<ExperienceVial>();
            experienceVial.GlobalPosition = node.GlobalPosition;
            GetTree().GetFirstNodeInGroup("entities_layer").AddChild(experienceVial);
        }
    }
}