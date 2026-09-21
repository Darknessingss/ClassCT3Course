using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/Configs/Enemy Config")]
public sealed class EnemyConfig : ScriptableObject
{
    [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
    [field: SerializeField] public Projectile EnemyProjectilePrefab { get; private set; }

    [field: SerializeField] public int Columns { get; private set; } = 8;
    [field: SerializeField] public int Rows { get; private set; } = 4;
    [field: SerializeField] public float SpacingX { get; private set; } = 1.2f;
    [field: SerializeField] public float SpacingY { get; private set; } = 1.2f;
        
    [field: SerializeField] public int Health { get; private set; } = 2;
    [field: SerializeField] public int ScorePerKill { get; private set; } = 10;

    [field: SerializeField] public float ShootIntervalMin { get; private set; } = 1.5f;
    [field: SerializeField] public float ShootIntervalMax { get; private set; } = 4f;
    [field: SerializeField] public float ProjectileSpeed { get; private set; } = 6f;
}