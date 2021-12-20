using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class KnifeController : MonoBehaviour
{
    public static event UnityAction<bool> OnSurfaceEvent;

    [SerializeField] private KnifeConfigSO _knife;
    [SerializeField] private AudioSource _collisionSurface;
    [SerializeField] private AudioSource _airKnife;

    public float zAngleTarget;
    public float secondsToLerp;
    private float t;


    private InputReader _inputReader;
    private Rigidbody _rigidbody;
    private bool _isOnSurface;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody>();
        t = 0f;
    }

    private void OnEnable()
    {
        _inputReader.OnJumpEvent += OnJump;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.AddForce(Vector3.up * _knife.JumpForce, ForceMode.Impulse);
            //_rigidbody.AddTorque(transform.right * _knife.TorqueForce, ForceMode.VelocityChange);
            //gameObject.transform.Rotate(Vector3.right);
        }

        if (!_isOnSurface)
        {
            float xCurrentAngle = TransformUtils.GetInspectorRotation(transform).x;


            if(xCurrentAngle > 0f && xCurrentAngle < 90)
                transform.Rotate(Vector3.right, 90f * Time.deltaTime);
            else
                transform.Rotate(Vector3.right, 270f * Time.deltaTime);
        }
    }

    private void OnJump()
    {
        //_rigidbody.AddForce(Vector3.up * _knife.JumpForce, ForceMode.Impulse);
        // gameObject.transform.Rotate(Vector3.right, 180f);
        //_rigidbody.AddTorque(transform.right * _knife.TorqueForce, ForceMode.VelocityChange);
        //_airKnife.Play();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Object enter " + collision.gameObject.name);

        if(collision.gameObject.name == "Surface")
        {
            //_rigidbody.isKinematic = true;
            OnSurfaceEvent?.Invoke(true);
            _collisionSurface.Play();
            _isOnSurface = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Surface")
        {
            //_rigidbody.isKinematic = false;
            OnSurfaceEvent?.Invoke(false);
            _isOnSurface = false;
        }
    }

    private void OnDestroy()
    {
        _inputReader.OnJumpEvent -= OnJump;
    }
}
