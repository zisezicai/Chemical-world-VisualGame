using Godot;
using System;

public partial class RoofHide : Area2D
{
	TileMapLayer layer;
	bool playerIn=false;
	public override void _Ready()
	{
		layer = GetNode<TileMapLayer>("../roofLayer");
		this.BodyEntered += (area) =>
		{
			if(area.Name!="player") return;
			playerIn=true;	
		};
		this.BodyExited += (area) =>
		{
			if(area.Name!="player") return;
			playerIn=false;
		};
	}
    public override void _Process(double delta)
	{
		if(playerIn)
		{
			if (layer.Modulate.A > 0f)
			{
				layer.Modulate = new Color(1,1,1,layer.Modulate.A-0.02f);
			}
		}
		else
		{
			if (layer.Modulate.A < 1f)
			{
				layer.Modulate = new Color(1,1,1,layer.Modulate.A+0.02f);
			}
		}
	}

}
