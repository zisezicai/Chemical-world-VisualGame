using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public int speed=>500;

	private AnimatedSprite2D animSprite;
	private Vector2 inputDirection;

	public override void _Ready()
	{
		animSprite=GetNode<AnimatedSprite2D>("appearance");
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

	private void UpdateAnimation()
	{
		if (inputDirection == Vector2.Zero)
		{
			animSprite.Pause();
			return;
		}
		//播放动画
		if (Mathf.Abs(inputDirection.X) > Mathf.Abs(inputDirection.Y))
		{
			animSprite.Play(inputDirection.X > 0 ? "right" : "left");
		}
		else
		{
			animSprite.Play(inputDirection.Y > 0 ? "down" : "up");
		}
	}
}
