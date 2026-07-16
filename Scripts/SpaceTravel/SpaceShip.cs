using Godot;
using System;

public partial class SpaceShip : CharacterBody2D
{
    [Export]
	public float speed = 300.0f;
	[Export]
	public float rotationSpeed = 3.0f;

    public override void _PhysicsProcess(double delta)
    {
        float moveVertical = Input.GetAxis("up", "down");
        float rotateHorizontal = Input.GetAxis("left", "right");
        if (rotateHorizontal != 0)
        {
            Rotation += rotateHorizontal * rotationSpeed * (float)delta;
        }
        if (moveVertical != 0)
        {
            Vector2 direction = Transform.Y; 
            Vector2 velocity = direction * moveVertical * speed;
            Velocity = velocity;
            MoveAndSlide();
        }
        else
        {
            Velocity = Velocity.Lerp(Vector2.Zero, 10.0f * (float)delta);
        }
    }
}
