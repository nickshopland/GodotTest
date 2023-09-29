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
        var direction = 0;
        if (Input.IsActionPressed("wasd_left"))
        {
            direction = -1;
        }
        if (Input.IsActionPressed("wasd_right"))
        {
            direction = 1;
        }

        // Rotation += _angularSpeed * (float)delta;
        Rotation += _angularSpeed * direction * (float)delta;

        // var velocity = Vector2.Up.Rotated(Rotation) * _speed;
        var velocity = Vector2.Zero;
        if (Input.IsActionPressed("wasd_up"))
        {
            velocity = Vector2.Up.Rotated(Rotation) * _speed;
        }

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
