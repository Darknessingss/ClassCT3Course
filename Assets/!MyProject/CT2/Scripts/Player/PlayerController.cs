using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public sealed class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private Camera _camera;

    private PlayerConfig _config;
    private HealthService _healthService;
    private GameStateMachine _stateMachine;
    private float _minX;
    private float _maxX;
    private float _halfWidth;

    private void Awake()
    {
        _halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    public void Initialize(PlayerConfig config, HealthService healthService, GameStateMachine stateMachine)
    {
        _config = config;
        _healthService = healthService;
        _stateMachine = stateMachine;

        float halfHeight = _camera.orthographicSize;
        float halfWidthCam = halfHeight * _camera.aspect;
        _minX = -halfWidthCam + _halfWidth + _config.HorizontalPadding;
        _maxX = halfWidthCam - _halfWidth - _config.HorizontalPadding;
    }

    private void Update()
    {
        if (!_stateMachine.IsPlaying())
        {
            return;
        }

        float input = Input.GetAxisRaw("Horizontal");
        if (input == 0f)
        {
            return;
        }

        var position = transform.position;
        position.x += input * _config.MoveSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        transform.position = position;
    }

    public void TakeDamage(int amount)
    {
        _healthService.TakeDamage(amount);
    }
}