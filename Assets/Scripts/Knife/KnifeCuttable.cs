using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCuttable : MonoBehaviour
{
    [SerializeField] private GameObject _cubeSlice;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            //PoolerObject.ReturnGameObject(objectBehaviour.gameObject);
            Destroy(objectBehaviour.gameObject);
            Instantiate(_cubeSlice, objectBehaviour.gameObject.transform.position, objectBehaviour.gameObject.transform.rotation);
            _cubeSlice.SetActive(true);
        }
    }
}
