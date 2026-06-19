using Godot;
using System;

public partial class GotoButton : TextureButton//一个简单的按钮，用于逻辑简单的场景跳转，如，前往设置，返回主页
{
	[Export]
	string targetScene="";
	bool isHover=false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += onPressed;
		this.MouseEntered+=()=>{
			isHover=true;
			// this.OffsetRight=45;
			// this.OffsetBottom=45;
			// this.OffsetLeft=-5;
			// this.OffsetTop=-5;
		};
		this.MouseExited+=()=>{
			isHover=false;
			// this.OffsetRight=40;
			// this.OffsetBottom=40;
			// this.OffsetLeft=0;
			// this.OffsetTop=0;
		};
	}
	const float speed=1;
	public override void _Process(double delta)
	{
		if(isHover && this.OffsetRight<45)
		{
			this.OffsetRight+=speed;
			this.OffsetBottom+=speed;
			this.OffsetLeft-=speed;
			this.OffsetTop-=speed;
		}
		else if(!isHover && this.OffsetRight>40)
		{
			this.OffsetRight-=speed;
			this.OffsetBottom-=speed;
			this.OffsetLeft+=speed;
			this.OffsetTop+=speed;
		}
	}
	public void onPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes//"+targetScene+".tscn");
	}
}
