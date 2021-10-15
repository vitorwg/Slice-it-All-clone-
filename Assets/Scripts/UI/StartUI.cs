using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject _scorePanel;

    public void OnClickStartButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        _scorePanel.SetActive(true);
    }
}
