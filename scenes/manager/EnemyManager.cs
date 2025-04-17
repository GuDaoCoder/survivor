using System;
using Godot;

namespace survivor.scenes.manager;

public partial class EnemyManager : Node
{

    [Export]
    public float MaxRange = 350f;

    [Export]
    public Timer Timer;

    [Export]
    public PackedScene BasicEnemyPackedScene;
    
    public override void _Ready()
    {
        Timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout()
    {
        Player player = GetTree().GetFirstNodeInGroup("player") as Player;
        if (player == null)
        {
            return;
        }

        Vector2 randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0,Double.Tau));
        Vector2 spawnPosition= player.GlobalPosition - randomDirection * MaxRange;

        game_object.basic_enemy.BasicEnemy basicEnemy = BasicEnemyPackedScene.Instantiate<game_object.basic_enemy.BasicEnemy>();
        GetParent().AddChild(basicEnemy);
        basicEnemy.GlobalPosition = spawnPosition;

    }
}