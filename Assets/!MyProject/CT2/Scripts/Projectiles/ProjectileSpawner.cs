using UnityEngine;

public static class ProjectileSpawner
{
    public static void Spawn(Projectile prefab, Vector3 position, Vector2 direction, float speed, int damage)
    {
        var instance = Object.Instantiate(prefab, position, Quaternion.identity);
        instance.Launch(direction, speed, damage);
    }
}