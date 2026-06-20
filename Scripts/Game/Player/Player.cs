using Godot;
using System;

public partial class Player : AnimatedSprite2D
{
	public int speed=>10;
	public override void _Ready()
	{
		this.GetNode<Label>("mainCamera/nameLabel").Text=SaveManager.Instance.playerName;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		move();
	}

	public void move()//移动的逻辑
	{
		if (Input.IsActionPressed("up"))
		{
			// if(Input.IsActionJustPressed("up")){//只在第一帧开始播
				this.Play("up");
			// }
			this.Position += new Vector2(0, -speed);
		}
		else if (Input.IsActionPressed("down"))
		{
			// if(Input.IsActionJustPressed("down")){
				this.Play("down");
			// }
			this.Position += new Vector2(0, speed);
		}
		else if (Input.IsActionPressed("left"))
		{
			// if(Input.IsActionJustPressed("left")){
				this.Play("left");
			// }
			this.Position += new Vector2(-speed, 0);
		}
		else if (Input.IsActionPressed("right"))
		{
			// if(Input.IsActionJustPressed("right")){
				this.Play("right");
			// }
			this.Position += new Vector2(speed, 0);
		}
		else
		{
			this.Pause();
		}
	}
}
