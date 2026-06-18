using Godot;
using System;
using System.Reflection;
public partial class Item : Control
{
	[Export]
	public string itemName;
	public static Item playerNameItem;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (itemName == "playerName")
		{
			playerNameItem=this;
		}
		this.GetNode<Label>("key").Text=itemName+":";
		this.GetNode<LineEdit>("value").TextChanged+=onValueChanged;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	FieldInfo field;
	
	public void onValueChanged(string value)
	{
		if(field==null){
			field=typeof(SaveManager).GetField(itemName);
		}
		field.SetValue(SaveManager.Instance,value);
	}
}
