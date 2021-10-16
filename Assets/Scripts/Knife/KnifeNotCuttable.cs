using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeNotCuttable : MonoBehaviour
{
    [SerializeField] private float _rollBackForce;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            //Debug.Log(gameObject.name + "Colide with: " + other.gameObject.name);
            //_rigidbody.AddForce(Vector3.back * _rollBackForce, ForceMode.Impulse);
            _rigidbody.AddTorque(-transform.right * _rollBackForce, ForceMode.Impulse);
        }
    }
}
