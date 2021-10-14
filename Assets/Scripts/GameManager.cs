using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameConfigSO _gameConfig;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, _gameConfig.Gravity, 0);
    }

}
