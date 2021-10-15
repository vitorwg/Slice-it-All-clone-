using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public event UnityAction<int> GetCurrentScoreEvent;

    [SerializeField] private GameConfigSO _gameConfig;
    [SerializeField] private KnifeCuttable _knifeCuttable;

    private int _countScore;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, _gameConfig.Gravity, 0);
        //DeadZoneCollider.GameOverEvent += ShowGameOver;
        _knifeCuttable.ObjectSlicedEvent += Score;
    }

    private void Start()
    {
        Time.timeScale = 0;

        _countScore = 0;
    }

    public int GetScore()
    {
        return _countScore;
    }
    private void Score()
    {
        _countScore += 10;
        GetCurrentScoreEvent?.Invoke(_countScore);
    }
    private void OnDisable()
    {
        _knifeCuttable.ObjectSlicedEvent -= Score;
    }

}
