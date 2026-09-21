using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public sealed class PlayerShooter : MonoBehaviour
{
    private PlayerConfig _config;
    private GameStateMachine _stateMachine;
    private float _nextFireTime;

    public void Initialize(PlayerConfig config, GameStateMachine stateMachine)
    {
        _config = config;
        _stateMachine = stateMachine;
    }

    private void Update()
    {
        if (!_stateMachine.IsPlaying())
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time >= _nextFireTime)
        {
            ProjectileSpawner.Spawn(
                _config.ProjectilePrefab,
                transform.position,
                Vector2.up,
                _config.ProjectileSpeed,
                1);

            _nextFireTime = Time.time + _config.FireCooldown;
        }
    }
}