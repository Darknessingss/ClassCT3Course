using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1000)]
public sealed class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private GameConfig _gameConfig;

    [SerializeField] private PlayerController _player;
    [SerializeField] private PlayerShooter _playerShooter;
    [SerializeField] private EnemyGridSpawner _enemySpawner;
    [SerializeField] private EnemyArmyController _enemyArmy;
    [SerializeField] private EnemyShooter _enemyShooter;

    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private WinScreen _winScreen;
    [SerializeField] private LoseScreen _loseScreen;

    private GameStateMachine _stateMachine;
    private ScoreService _scoreService;
    private HealthService _healthService;

    private void Awake()
    {
        _stateMachine = new GameStateMachine();
        _scoreService = new ScoreService();
        _healthService = new HealthService(_playerConfig.MaxHealth);
    }

    private void Start()
    {
        _stateMachine.StateChanged += OnStateChanged;

        _scoreService.ScoreChanged += _scoreView.SetScore;
        _healthService.HealthChanged += _healthView.SetHealth;
        _healthService.Died += () => _stateMachine.SetState(GameState.Lose);

        _scoreView.SetScore(_scoreService.GetScore());
        _healthView.SetHealth(_healthService.GetCurrent());

        _winScreen.Hide();
        _loseScreen.Hide();
        _winScreen.RestartRequested += RestartGame;
        _loseScreen.RestartRequested += RestartGame;

        _player.Initialize(_playerConfig, _healthService, _stateMachine);
        _playerShooter.Initialize(_playerConfig, _stateMachine);

        _enemyArmy.Initialize(_gameConfig, _scoreService, _stateMachine);
        _enemySpawner.Initialize(_enemyConfig, _enemyArmy);
        _enemySpawner.SpawnGrid();

        _enemyShooter.Initialize(_enemyArmy, _enemyConfig, _stateMachine);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void OnStateChanged(GameState state)
    {
        if (state == GameState.Win)
        {
            _winScreen.Show(_scoreService.GetScore());
        }
        else if (state == GameState.Lose)
        {
            _loseScreen.Show(_scoreService.GetScore());
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}