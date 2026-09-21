using UnityEngine;

public sealed class EnemyGridSpawner : MonoBehaviour
{
    private EnemyConfig _config;
    private EnemyArmyController _army;

    public void Initialize(EnemyConfig config, EnemyArmyController army)
    {
        _config = config;
        _army = army;
    }

    public void SpawnGrid()
    {
        float totalWidth = (_config.Columns - 1) * _config.SpacingX;
        float startX = -totalWidth * 0.5f;

        for (int row = 0; row < _config.Rows; row++)
        {
            for (int col = 0; col < _config.Columns; col++)
            {
                var localPos = new Vector3(
                    startX + col * _config.SpacingX,
                    -row * _config.SpacingY,
                    0f);

                var enemy = Instantiate(_config.EnemyPrefab, transform.position + localPos, Quaternion.identity, transform);
                enemy.Initialize(_config, _army);
                _army.Register(enemy);
            }
        }
    }
}