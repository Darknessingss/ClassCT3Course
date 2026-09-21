using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/Configs/Player Config")]
public sealed class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 6f;
    [field: SerializeField] public int MaxHealth { get; private set; } = 3;
    [field: SerializeField] public float FireCooldown { get; private set; } = 0.3f;
    [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }
    [field: SerializeField] public float ProjectileSpeed { get; private set; } = 12f;
    [field: SerializeField] public float HorizontalPadding { get; private set; } = 0.5f;
}