using Godot;
using System;

public partial class PlayerC : Sprite2D
{
    private int _speed = 400;
    private float _angularSpeed = Mathf.Pi;

    public PlayerC()
    {
        GD.Print("Hello, from Player C!");
    }

    public override void _Ready()
    {
        var timer = GetNode<Timer>("TimerC");
        timer.Timeout += OnTimerTimeout;
    }

    public override void _Process(double delta)
    {
        var direction = Input.IsActionPressed("wasd_right") ? 1 : 0;
        direction -= Input.IsActionPressed("wasd_left") ? 1 : 0;

        // Rotation += _angularSpeed * (float)delta;
        Rotation += _angularSpeed * direction * (float)delta;

        var velocity = Input.IsActionPressed("wasd_up") ? Vector2.Up.Rotated(Rotation) * _speed : Vector2.Zero;
        velocity += Input.IsActionPressed("wasd_down") ? Vector2.Down.Rotated(Rotation) * _speed : Vector2.Zero;

        Position += velocity * (float)delta;
    }

    private void OnTimerTimeout()
    {
        // Visible = !Visible;
        if (Modulate.A == 1.0)
            Modulate = new Color(1,1,1,0.5f);
        else
            Modulate = new Color(1,1,1,1);
    }

    private void OnButtonCPressed()
    {
        GD.Print("Toggle C");
        SetProcess(!IsProcessing());
    }
}
