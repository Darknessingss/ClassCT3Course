using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Configs/Game Config")]
public sealed class GameConfig : ScriptableObject
{
    [field: SerializeField] public float DescentInterval { get; private set; } = 5f;
    [field: SerializeField] public float DescentStep { get; private set; } = 0.25f;
    [field: SerializeField] public float LoseLineY { get; private set; } = -4f;
}