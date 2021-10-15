using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIStart : MonoBehaviour
{
    public event UnityAction StartButtonAction;

    public void StartButton()
    {
        StartButtonAction?.Invoke();
    }
}
