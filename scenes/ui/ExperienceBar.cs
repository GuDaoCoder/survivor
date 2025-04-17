using Godot;
using survivor.scenes.manager;

namespace survivor.scenes.ui;

public partial class ExperienceBar : CanvasLayer
{
    [Export]
    public ExperienceManager ExperienceManager;

    [Export]
    public ProgressBar ProgressBar;
    
    public override void _Ready()
    {
        ExperienceManager.ExperienceUpdate += OnExperienceUpdate;
    }

    private void OnExperienceUpdate(int currentlevel, float totalExperience, float currentLevelProgress)
    {
        ProgressBar.Value = currentLevelProgress;
    }
}