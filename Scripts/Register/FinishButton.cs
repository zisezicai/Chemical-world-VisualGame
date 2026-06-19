using Godot;
using System;

public partial class FinishButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += onPressed;
	}
	public void onPressed()
	{
		SaveManager.createSave(Item.playerNameItem.GetNode<LineEdit>("value").Text);
		GD.Print(SaveManager.Instance.playerName);
		GetTree().ChangeSceneToFile("res://Scenes/StartingArea.tscn");
	}
}
