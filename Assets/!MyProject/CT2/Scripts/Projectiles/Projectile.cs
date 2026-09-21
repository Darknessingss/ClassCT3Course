using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifetime = 3f;

    private float _speed;
    private Vector2 _direction;
    private int _damage;

    public void Launch(Vector2 direction, float speed, int damage)
    {
        _direction = direction.normalized;
        _speed = speed;
        _damage = damage;
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.position += (Vector3)(_direction * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}