using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeNotCuttable : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            Debug.Log(gameObject.name + "Colide with: " + other.gameObject.name);
            _rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }
}
