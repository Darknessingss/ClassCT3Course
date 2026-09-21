using System.Collections.Generic;
using UnityEngine;

public sealed class HealthView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _iconPrefab;

    private readonly List<GameObject> _icons = new();

    public void SetHealth(int current)
    {
        while (_icons.Count < current)
        {
            var icon = Instantiate(_iconPrefab, _container);
            _icons.Add(icon);
        }

        for (int i = 0; i < _icons.Count; i++)
        {
            _icons[i].SetActive(i < current);
        }
    }
}