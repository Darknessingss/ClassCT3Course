using UnityEngine;

public sealed class EnemyShooter : MonoBehaviour
{
    private EnemyArmyController _army;
    private EnemyConfig _config;
    private GameStateMachine _stateMachine;
    private float _timer;

    public void Initialize(EnemyArmyController army, EnemyConfig config, GameStateMachine stateMachine)
    {
        _army = army;
        _config = config;
        _stateMachine = stateMachine;
        _timer = Random.Range(_config.ShootIntervalMin, _config.ShootIntervalMax);
    }

    private void Update()
    {
        if (!_stateMachine.IsPlaying() || _army.GetAliveCount() == 0)
        {
            return;
        }

        _timer -= Time.deltaTime;
        if (_timer > 0f)
        {
            return;
        }

        var shooter = _army.GetAliveAt(Random.Range(0, _army.GetAliveCount()));

        ProjectileSpawner.Spawn(
            _config.EnemyProjectilePrefab,
            shooter.transform.position,
            Vector2.down,
            _config.ProjectileSpeed,
            1);

        _timer = Random.Range(_config.ShootIntervalMin, _config.ShootIntervalMax);
    }
}