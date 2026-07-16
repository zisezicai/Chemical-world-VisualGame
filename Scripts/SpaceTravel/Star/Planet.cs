using Godot;
using System;
public partial class Planet : Star
{
    [Export]
    public float selfRotationSpeed=5;
    public override void _Process(double delta)
    {
        this.RotationDegrees += selfRotationSpeed * (float)delta;
    }
}
