using Godot;

namespace survivor.scenes.manager;

public partial class ArenaTimeManager : Node
{
    [Export] public Timer Timer;

    public float GetTimeElapsed()
    {
        return (float)(Timer.WaitTime - Timer.TimeLeft);
    }
}