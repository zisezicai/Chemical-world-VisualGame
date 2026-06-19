using Godot;
using System;

public partial class LeaveButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Pressed += onPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void onPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
		if (SaveManager.Instance != null)
		{
			SaveManager.Instance.writeIntoFile();
		}
	}
}
