using UnityEngine;

[CreateAssetMenu(fileName = "VelocityObjectConfig", menuName = "EntityConfig/Velocity Object Config")]
public class VelocityObjectConfigSO : ScriptableObject
{
    [SerializeField] private float _velocity;

    public float Velocity => _velocity;
}