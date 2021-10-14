using UnityEngine;

[CreateAssetMenu(fileName = "KnifeConfig", menuName = "EntityConfig/Knife Config")]
public class KnifeConfigSO : ScriptableObject
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _torqueForce;

    public float JumpForce => _jumpForce;
    public float TorqueForce => _torqueForce;
}