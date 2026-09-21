using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class Enemy : MonoBehaviour, IDamageable
{
    private int _currentHealth;
    private int _scorePerKill;
    private EnemyArmyController _army;

    public void Initialize(EnemyConfig config, EnemyArmyController army)
    {
        _currentHealth = config.Health;
        _scorePerKill = config.ScorePerKill;
        _army = army;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth > 0)
        {
            return;
        }

        _army.NotifyKilled(this, _scorePerKill);
        Destroy(gameObject);
    }
}