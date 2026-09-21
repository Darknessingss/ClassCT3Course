using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyArmyController : MonoBehaviour
{
    private readonly List<Enemy> _alive = new();

    private GameConfig _gameConfig;
    private ScoreService _scoreService;
    private GameStateMachine _stateMachine;
    private float _descentTimer;

    public void Initialize(GameConfig gameConfig, ScoreService scoreService, GameStateMachine stateMachine)
    {
        _gameConfig = gameConfig;
        _scoreService = scoreService;
        _stateMachine = stateMachine;
    }

    public void Register(Enemy enemy)
    {
        _alive.Add(enemy);
    }

    public void NotifyKilled(Enemy enemy, int score)
    {
        _alive.Remove(enemy);
        _scoreService.Add(score);

        if (_alive.Count == 0)
        {
            _stateMachine.SetState(GameState.Win);
        }
    }

    public int GetAliveCount()
    {
        return _alive.Count;
    }

    public Enemy GetAliveAt(int index)
    {
        return _alive[index];
    }

    private void Update()
    {
        if (!_stateMachine.IsPlaying())
        {
            return;
        }

        _descentTimer += Time.deltaTime;
        if (_descentTimer >= _gameConfig.DescentInterval)
        {
            _descentTimer = 0f;
            transform.position += new Vector3(0f, -_gameConfig.DescentStep, 0f);
        }

        for (int i = 0; i < _alive.Count; i++)
        {
            if (_alive[i].transform.position.y <= _gameConfig.LoseLineY)
            {
                _stateMachine.SetState(GameState.Lose);
                return;
            }
        }
    }
}