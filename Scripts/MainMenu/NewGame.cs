using Godot;
using System;

public partial class NewGame : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += onPressed;
	}
	public void onPressed()
	{
		GD.Print("pressed");
		GetTree().ChangeSceneToFile("res://Scenes/RegisterNewPlayer.tscn");
	}
}
