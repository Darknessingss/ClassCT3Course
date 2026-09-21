using System;

public sealed class HealthService
{
    public event Action<int> HealthChanged;
    public event Action Died;

    private int _max;
    private int _current;

    public HealthService(int max)
    {
        _max = max;
        _current = max;
    }

    public void TakeDamage(int amount)
    {
        _current -= amount;

        if (_current <= 0)
        {
            _current = 0;
            HealthChanged?.Invoke(_current);
            Died?.Invoke();
            return;
        }

        HealthChanged?.Invoke(_current);
    }

    public int GetCurrent()
    {
        return _current;
    }

    public int GetMax()
    {
        return _max;
    }
}