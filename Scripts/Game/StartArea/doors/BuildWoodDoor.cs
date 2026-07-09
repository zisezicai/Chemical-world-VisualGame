using Godot;
using System;

public partial class BuildWoodDoor : Node2D
{
	Area2D front;
	Area2D back;
	Node2D door;
	bool open;
	enum Direction{
		Front,
		Back
	}
	Direction frontOrBack;
	bool inFront;
	bool inBack;
	public override void _Ready()
	{
		open=false;
		frontOrBack=Direction.Front;
		
		/*
		总结，进入区域时，如果关着就开，离开区域时，如果开着就关
		从外往里->在进入front时开门，离开back时关门
		从里往外->在进入back时开门，离开front时关门
		刚想进又走了->进入front时开门，离开front时关门
		刚想出来又走了->进入back时开门，离开back时关门
		*/

		front=GetNode<Area2D>("front");
		front.BodyEntered += (area) =>
		{
			if(area.Name!="player") return;
			// GD.Print("front");
			inFront=true;
			if (!open)
			{
				open=true;
				frontOrBack=Direction.Front;
			}
		};
		front.BodyExited += (area) =>
		{
			if(area.Name!="player") return;
			inFront=false;
			if (open && !inBack)
			{
				open=false;
			}
		};

		back=GetNode<Area2D>("back");
		back.BodyEntered += (area) => 
		{
			if(area.Name!="player") return;
			// GD.Print("back");
			inBack=true;
			if (!open)
			{
				open=true;
				frontOrBack=Direction.Back;
			}
		};
		back.BodyExited += (area) =>
		{
			if(area.Name!="player") return;
			inBack=false;
			if (open && !inFront)
			{
				open=false;
			}
		};

		door=GetNode<Node2D>("door");
	}
	const float speed=5f;
	public override void _Process(double delta)
	{
		if (open)
		{
			if(frontOrBack==Direction.Front){
				if(door.RotationDegrees>-90){
					door.RotationDegrees-=speed;
				}
			}else{
				if(door.RotationDegrees<90){
					door.RotationDegrees+=speed;
				}
			}
		}
		else
		{
			if (Mathf.Abs(door.RotationDegrees - 0) < speed)//防止精度误差导致的抖动
			{
				door.RotationDegrees = 0;
			}
			if(door.RotationDegrees>0){
				door.RotationDegrees-=speed;
			}else if(door.RotationDegrees<0){
				door.RotationDegrees+=speed;
			}
		}
	}
}
