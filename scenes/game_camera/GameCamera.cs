using Godot;
using Godot.Collections;

public partial class GameCamera : Camera2D
{
    private Vector2 _targetGlobalPosition = Vector2.Zero;

    public override void _Ready()
    {
        MakeCurrent();
    }


    public override void _Process(double delta)
    {
        AcquireTargetGlobalPosition();
        GlobalPosition = GlobalPosition.Lerp(_targetGlobalPosition, 1 - float.Exp(-(float)delta * 10));
    }
    
    
    private void AcquireTargetGlobalPosition()
    {
        Array<Node> nodes = GetTree().GetNodesInGroup("player");
        if (nodes.Count > 0 && nodes[0] is Player player)
        {
            _targetGlobalPosition = player.GlobalPosition;
        }
    }
}