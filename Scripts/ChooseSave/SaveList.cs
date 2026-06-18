using Godot;
using System;

public partial class SaveList : ItemList
{
	// Called when the node enters the scene tree for the first time.
	static string[] saveList;
	public override void _Ready()
	{
		saveList=SaveManager.getSaveList();
		foreach (string save in saveList)
		{
			AddItem(save,null);
		}
		this.ItemSelected+=onItemSelected;
	}
	public void onItemSelected(long index)
	{
		SaveManager.loadSave(saveList[index]);
		// 延迟到下一帧再切换场景
		CallDeferred(nameof(switchToStartingArea));
	}

	private void switchToStartingArea()
	{
		GetTree().ChangeSceneToFile("res://Scenes/StartingArea.tscn");
	}
}
