using UnityEngine;
using UnityEngine.Events;

public class WinnerCollision : MonoBehaviour
{
    public event UnityAction OnWinnerCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out KnifeController knife))
        {
            Debug.Log(collision.gameObject.name);
            OnWinnerCollision?.Invoke();
        }
    }
}
