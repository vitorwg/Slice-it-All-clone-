using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIWinner : MonoBehaviour
{
    public event UnityAction ContinueButtonAction;

    [SerializeField] private TextMeshProUGUI _finalScore;

    public void ContinueButton()
    {
        ContinueButtonAction?.Invoke();
    }

    public void SetFinalScore(int currentScore)
    {
        _finalScore.text = "Score: " + currentScore.ToString();
    }
}