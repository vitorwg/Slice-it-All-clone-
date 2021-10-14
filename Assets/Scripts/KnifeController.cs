using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _torqueForce;
    [SerializeField] private float _lerpRotation;

    public event UnityAction<bool> OnSurfaceEvent;

    private InputReader _inputReader;
    private Rigidbody _rigidbody;

    private Quaternion _targetRotation;
    private float _angleRotate = 45f;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rot;

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
        _rigidbody.isKinematic = false;

        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        _rigidbody.AddTorque(transform.right * _torqueForce, ForceMode.VelocityChange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Object enter " + collision.gameObject.name);


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
