using Godot;
using System;

public partial class GotoButton : TextureButton//一个简单的按钮，用于逻辑简单的场景跳转，如，前往设置，返回主页
{
	[Export]
	string targetScene="";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += onPressed;
		this.MouseEntered+=()=>{
			this.OffsetRight=45;
			this.OffsetBottom=45;
			this.OffsetLeft=-5;
			this.OffsetTop=-5;};
		this.MouseExited+=()=>{
			this.OffsetRight=40;
			this.OffsetBottom=40;
			this.OffsetLeft=0;
			this.OffsetTop=0;};
	}
	public void onPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes//"+targetScene+".tscn");
	}
}
