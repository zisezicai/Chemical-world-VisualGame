using Godot;
using System;

public partial class SpaceShip : CharacterBody2D
{
    [Export]
	public float speed = 300.0f;
	[Export]
	public float rotationSpeed = 3.0f;


    public override void _Ready()
    {
        this.Scale=new Vector2(0.05f,0.05f);
    }

    public override void _Process(double delta)
    {
        if (this.Scale.X < 1)
        {
            if(this.Scale.X>=0.95f) this.Scale=new Vector2(1,1);
            else this.Scale=new Vector2(this.Scale.X+(float)(0.3f*delta),this.Scale.Y+(float)(0.3f*delta));
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        if(this.Scale.X<1) return;
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
