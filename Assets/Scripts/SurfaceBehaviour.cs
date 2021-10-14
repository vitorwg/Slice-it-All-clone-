using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SurfaceBehaviour : MonoBehaviour
{
    [SerializeField] private VelocityObjectConfigSO _objectConfigSO;
    [SerializeField] private KnifeController _knifeController;

    private Rigidbody _rigidbody;
    private Vector3 _inicialPosition;
    private bool _onKnifeSurface;

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
        _onKnifeSurface = value;
        _rigidbody.velocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (!_onKnifeSurface)
        {
            //_rigidbody.velocity = Vector3.back * _velocity * Time.deltaTime;
            transform.Translate(Vector3.back * _objectConfigSO.Velocity * Time.deltaTime);

        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (TryGetComponent<SurfaceBehaviour>(out SurfaceBehaviour plataform))
    //    {
    //        gameObject.transform.position = _inicialPosition;
    //        Debug.Log(other.name);

    //    }
    //}

}
