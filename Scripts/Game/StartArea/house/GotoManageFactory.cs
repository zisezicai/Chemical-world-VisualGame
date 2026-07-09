using Godot;
using System;

public partial class GotoManageFactory : Area2D
{	public override void _Ready()
	{
		this.BodyEntered += onBodyEntered;
	}
	public void onBodyEntered(Node2D body)
	{
		if(body.Name == "player")
		{
			this.CallDeferred("changeScene");
		}
	}
	public void changeScene()
	{
		GetTree().ChangeSceneToFile("res://Scenes/ManageFactory.tscn");
	}
}
