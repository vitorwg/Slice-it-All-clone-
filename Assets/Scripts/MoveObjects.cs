using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private VelocityObjectConfigSO _objectConfigSO;
    [SerializeField] private KnifeController _knifeController;

    private bool _onKnifeSurface;

    private void Start()
    {
        _knifeController.OnSurfaceEvent += KnifeOnSurface;
    }

    private void KnifeOnSurface(bool value)
    {
        _onKnifeSurface = value;
    }

    private void FixedUpdate()
    {
        if (!_onKnifeSurface)
        {
            transform.Translate(Vector3.back * _objectConfigSO.Velocity * Time.deltaTime);
        }

    }
}
