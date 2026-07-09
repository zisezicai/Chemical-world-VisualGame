using Godot;
using System;
using System.Collections.Generic;
public partial class Stars : Node2D
{
	public List<Star> stars = new List<Star>();

	public override void _Ready()
	{
		instance = this;
	}




	public static Stars Instance
	{
		get
		{
			return instance;
		}
	}

	static Stars instance;
}
