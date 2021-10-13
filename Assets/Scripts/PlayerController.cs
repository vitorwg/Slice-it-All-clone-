using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _torqueForce;
    [SerializeField] private float _lerpRotation;

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

    private void Update()
    {
        //HandleKnifeRotation();
    }

    private void OnJump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

        _rigidbody.AddTorque(transform.right * _torqueForce, ForceMode.VelocityChange);



        //Vector3 axis = Vector3.right;

        //transform.rotation.ToAngleAxis(out _angleRotate, out axis);

        //Debug.Log("AngleRotat Before: " + _angleRotate);

        //_angleRotate += +350;

        //if (_angleRotate >= 0 || _angleRotate < 180)
        //{
        //}
        //if (_angleRotate >= 180 || _angleRotate < 360)
        //{
        //    _angleRotate += +180;
        //}

        //Debug.Log("AngleRotate After: " + _angleRotate + axis);


        //_targetRotation = Quaternion.AngleAxis(_angleRotate, Vector3.right);


        //transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _lerpRotation * Time.deltaTime);

        //Debug.Log("My rotation: " + transform.rotation + ". Target rotation: " + _targetRotation);
        //Debug.Log("OnJumpTest");
    }

    private void HandleKnifeRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _lerpRotation * Time.deltaTime);
    }
    

    private void OnDisable()
    {
        _inputReader.OnJumpEvent -= OnJump;
    }
}
