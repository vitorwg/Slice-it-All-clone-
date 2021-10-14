using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeController : MonoBehaviour
{
    public static event UnityAction<bool> OnSurfaceEvent;

    [SerializeField] private KnifeConfigSO _knife;

    private InputReader _inputReader;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _inputReader.OnJumpEvent += OnJump;
    }

    private void OnJump()
    {
        _rigidbody.AddForce(Vector3.up * _knife.JumpForce, ForceMode.Impulse);

        _rigidbody.AddTorque(transform.right * _knife.TorqueForce, ForceMode.VelocityChange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Object enter " + collision.gameObject.name);

        if(collision.gameObject.name == "Surface")
        {
            //_rigidbody.isKinematic = true;
            OnSurfaceEvent?.Invoke(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Surface")
        {
            //_rigidbody.isKinematic = false;
            OnSurfaceEvent?.Invoke(false);
        }
    }

    private void OnDisable()
    {
        _inputReader.OnJumpEvent -= OnJump;
    }
}
