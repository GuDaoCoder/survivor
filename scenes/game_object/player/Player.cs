using Godot;

public partial class Player : CharacterBody2D
{
    [Export] public float MaxSpeed = 125f;

    [Export] public float AccelerationSmoothing = 15f;

    public override void _Process(double delta)
    {
        Vector2 direction = GetMovementVector().Normalized();
        Vector2 targetVelocity = direction * MaxSpeed;
        Velocity = Velocity.Lerp(targetVelocity, 1 - float.Exp(-(float)delta * AccelerationSmoothing));
        MoveAndSlide();
    }

    private Vector2 GetMovementVector()
    {
        float xMovement = Input.GetActionStrength("MoveRight") - Input.GetActionStrength("MoveLeft");
        float yMovemment = Input.GetActionStrength("MoveDown") - Input.GetActionStrength("MoveUp");
        return new Vector2(xMovement, yMovemment);
    }
}