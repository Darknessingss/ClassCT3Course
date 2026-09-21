using TMPro;
using UnityEngine;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;

    public void SetScore(int score)
    {
        _label.text = $"Score: {score}";
    }
}