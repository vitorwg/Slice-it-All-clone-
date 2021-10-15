using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager.GetCurrentScoreEvent += ShowCurrentScore;
        _currentScore.text = "Score: 0";
    }

    public void ShowCurrentScore(int currentScore)
    {
        _currentScore.text = "Score: " + currentScore.ToString();
    }

    private void OnDisable()
    {
        //_gameManager.GetCurrentScoreEvent -= ShowCurrentScore;
    }
}
