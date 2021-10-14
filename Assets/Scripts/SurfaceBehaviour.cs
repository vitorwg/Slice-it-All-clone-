using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SurfaceBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private KnifeController _knifeController;

    private Rigidbody _rigidbody;
    private Vector3 _inicialPosition;
    private bool _onSurface = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _inicialPosition = gameObject.transform.position;
        _knifeController.OnSurfaceEvent += KnifeOnSurface;
    }

    private void KnifeOnSurface(bool value)
    {
        Debug.Log(value);
        _onSurface = value;
    }

    private void StopPlataform()
    {
        Debug.Log("StopMoving");

        _rigidbody.velocity = Vector3.zero;

        Debug.Log(_rigidbody.velocity);
    }

    private void FixedUpdate()
    {
        if (!_onSurface)
        {
            _rigidbody.velocity = Vector3.back * _velocity * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(TryGetComponent<SurfaceBehaviour>(out SurfaceBehaviour plataform))
        {
            gameObject.transform.position = _inicialPosition;
            Debug.Log(other.name);

        }
    }

}
