using Godot;

namespace survivor.scenes.auto_load;

public partial class GameEvents : Node
{
    public static GameEvents Instance { get; private set; }

    [Signal]
    public delegate void ExperienceVialCollectedEventHandler(float experience);

    public override void _Ready()
    {
        Instance = this;
    }

    public void EmitExperienceVialCollected(float experience)
    {
        EmitSignal(nameof(ExperienceVialCollected), experience);
    }
}