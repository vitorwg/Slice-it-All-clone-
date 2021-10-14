using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static event UnityAction CheckPointEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out KnifeController knifeController))
        {
            Debug.Log("SpawnPoint: " + gameObject.name);
            CheckPointEvent?.Invoke();
        }
    }
}
