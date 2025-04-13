using System.Globalization;
using Godot;
using survivor.scenes.manager;

namespace survivor.scenes.ui;

public partial class ArenaTimeUi : CanvasLayer
{

    [Export]
    public ArenaTimeManager ArenaTimeManager;

    [Export]
    public Label Label;

    public override void _Process(double delta)
    {
        if (ArenaTimeManager == null || Label == null)
        {
            return;
        }

        Label.Text = FormatSeconds(ArenaTimeManager.GetTimeElapsed());
    }

    private string FormatSeconds(float totalSeconds)
    {
        int minutes = (int)(totalSeconds / 60);
        int seconds = (int)(totalSeconds % 60);
        return $"{minutes}:{seconds:D2}";
    }
}