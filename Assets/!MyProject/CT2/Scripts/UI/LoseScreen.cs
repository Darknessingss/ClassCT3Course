using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class LoseScreen : MonoBehaviour
{
    public event Action RestartRequested;

    [SerializeField] private GameObject _root;
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(() => RestartRequested?.Invoke());
        _root.SetActive(false);
    }

    public void Show(int score)
    {
        _scoreLabel.text = $"Score: {score}";
        _root.SetActive(true);
    }

    public void Hide()
    {
        _root.SetActive(false);
    }
}