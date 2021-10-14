using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "EntityConfig/Game Config")]
public class GameConfigSO : ScriptableObject
{
    [SerializeField] private float _gravity;

    public float Gravity => -_gravity;
}