using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int speed=>500;

	private AnimatedSprite2D animSprite;
	private CollisionShape2D collisionShape;
	private Vector2 inputDirection;

	public override void _Ready()
	{
		animSprite=GetNode<AnimatedSprite2D>("appearance");
		collisionShape=GetNode<CollisionShape2D>("collision");
		this.GetNode<Label>("mainCamera/nameLabel").Text=SaveManager.Instance.playerName;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		inputDirection = Input.GetVector("left", "right", "up", "down");
		UpdateAnimation();
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = inputDirection * speed;
		MoveAndSlide();
	}
	float getDirection(){
		return inputDirection.Angle()+Mathf.Pi/2;
	}

	private void UpdateAnimation()
	{
		if (inputDirection == Vector2.Zero)
		{
			animSprite.Stop();
			return;
		}
		animSprite.Play();
		float direction=getDirection();
		animSprite.Rotation=direction;
		collisionShape.Rotation=direction;
	}
}
