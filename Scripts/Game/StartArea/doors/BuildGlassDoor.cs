using Godot;
using System;

public partial class BuildGlassDoor : Node2D
{
	Area2D area;
	Sprite2D left;
	Sprite2D right;
	bool open=false;
	public override void _Ready()
	{
		area=GetNode<Area2D>("openArea");

		area.BodyEntered += (area) =>
		{
			if(area.Name!="player") return;
			open=true;
		};
		area.BodyExited += (area) =>
		{
			if(area.Name!="player") return;
			open=false;
		};

		left=GetNode<Sprite2D>("left");
		right=GetNode<Sprite2D>("right");
	}

	const float speed=5;
	public override void _Process(double delta)
	{
		if (open)
		{
			if (left.Position.Y > -247)
			{
				left.Position = new Vector2(left.Position.X, left.Position.Y - speed);
				right.Position = new Vector2(right.Position.X, right.Position.Y + speed);
			}
		}
		else
		{
			if (Mathf.Abs(left.Position.Y + 84) < speed)
			{
				left.Position = new Vector2(left.Position.X, -84);
				right.Position = new Vector2(right.Position.X, 84);
			}
			if(left.Position.Y < -84)
			{
				left.Position = new Vector2(left.Position.X, left.Position.Y + speed);
				right.Position = new Vector2(right.Position.X, right.Position.Y - speed);
			}
		}
	}
}
