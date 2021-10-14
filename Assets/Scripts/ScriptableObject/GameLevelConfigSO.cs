using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameLevelConfig", menuName = "EntityConfig/Game Leve Config")]
public class GameLevelConfigSO : ScriptableObject
{
    [SerializeField] private List<CheckPoint> _checkPoints;
    [SerializeField] private CheckPoint[] _testCheckPoints;
    [SerializeField] private Transform[] _spawnPoints;

    //public CheckPoint CheckPoint => _checkPoints[index];
    public Transform[] SpawnPoint => _spawnPoints;
}
