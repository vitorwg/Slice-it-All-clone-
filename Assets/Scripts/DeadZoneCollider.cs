using UnityEngine;
using UnityEngine.Events;

public class DeadZoneCollider : MonoBehaviour
{
    public static event UnityAction GameOverEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            //Debug.Log(gameObject.name + " Colider with: " + other.name);
            PoolerObject.ReturnGameObject(other.gameObject);
        }

        if (other.TryGetComponent(out KnifeController knife))
        {
            GameOverEvent?.Invoke();
        }

    }
}