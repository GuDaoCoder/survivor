using Godot;
using survivor.scenes.auto_load;

namespace survivor.scenes.manager;

public partial class ExperienceManager : Node
{
    private float _currentExperience;

    public override void _Ready()
    {
        GameEvents.Instance.ExperienceVialCollected += OnExperienceVialCollected;
    }

    public void OnExperienceVialCollected(float experience)
    {
        IncrementExperience(experience);
    }

    public void IncrementExperience(float experience)
    {
        _currentExperience += experience;
        GD.Print(_currentExperience);
    }
}