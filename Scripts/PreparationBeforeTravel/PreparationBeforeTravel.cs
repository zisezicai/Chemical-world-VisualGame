using Godot;
using System;

public partial class PreparationBeforeTravel : Control
{
	public override void _Ready()
	{
		GetTree().ChangeSceneToFile("res://Scenes/SpaceTravel.tscn");
	}
}
