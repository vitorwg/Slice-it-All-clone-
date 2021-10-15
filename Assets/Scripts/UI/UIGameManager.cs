using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private UIStart _startPanel;
    [SerializeField] private UIScore _scorePanel;
    [SerializeField] private UIWinner _winnerPanel;
    [SerializeField] private WinnerCollision _finishLine;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        UIInitialization();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _startPanel.gameObject.SetActive(false);
        _scorePanel.gameObject.SetActive(true);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void ShowWinnerPanel()
    {
        Time.timeScale = 0;


        _scorePanel.gameObject.SetActive(false);
        _winnerPanel.gameObject.SetActive(true);

        int finalScore = _gameManager.GetScore();
        _winnerPanel.SetFinalScore(finalScore);
    }

    private void UIInitialization()
    {
        _startPanel.gameObject.SetActive(true);
        _scorePanel.gameObject.SetActive(false);
        _winnerPanel.gameObject.SetActive(false);

        _finishLine.OnWinnerCollision += ShowWinnerPanel;
        _startPanel.StartButtonAction += StartGame;
        _winnerPanel.ContinueButtonAction += RestartGame;
    }


    private void OnDisable()
    {
        _finishLine.OnWinnerCollision -= ShowWinnerPanel;
        _startPanel.StartButtonAction -= StartGame;
        _winnerPanel.ContinueButtonAction -= RestartGame;
    }

}
