using Godot;

public partial class Player : CharacterBody2D
{
    private readonly float MaxSpeed = 200f;
    
    public override void _Process(double delta)
    {
        Vector2 direction = GetMovementVector().Normalized();
        Velocity = direction * MaxSpeed;
        MoveAndSlide();
    }

    private Vector2 GetMovementVector()
    {
        float xMovement = Input.GetActionStrength("MoveRight") - Input.GetActionStrength("MoveLeft");
        float yMovemment = Input.GetActionStrength("MoveDown") - Input.GetActionStrength("MoveUp");
        return new Vector2(xMovement, yMovemment);
    }
}