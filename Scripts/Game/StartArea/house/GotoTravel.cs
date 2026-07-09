using Godot;
using System;

public partial class GotoTravel : Area2D
{
	public override void _Ready()
	{
		this.BodyEntered += onBodyEntered;	
	}
	public void onBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			this.CallDeferred(nameof(changeScene));
		}
	}
	void changeScene()
	{
		GetTree().ChangeSceneToFile("res://Scenes/PreparationBeforeTravel.tscn");
	}
}
