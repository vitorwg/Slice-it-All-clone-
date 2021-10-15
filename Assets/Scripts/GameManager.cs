using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameConfigSO _gameConfig;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private KnifeCuttable _knifeCuttable;

    private int _countScore;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, _gameConfig.Gravity, 0);
        _knifeCuttable.ObjectSlicedEvent += Score;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startPanel.SetActive(true);
        _countScore = 0;
        _scorePanel.SetActive(false);
    }

    private void Score()
    {
        _countScore += 10;
        _textScore.text = "Score: " + _countScore;
    }

    public int GetScore()
    {
        return _countScore;
    }
}
