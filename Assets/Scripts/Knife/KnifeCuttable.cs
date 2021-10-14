using UnityEngine;
using UnityEngine.Events;

public class KnifeCuttable : MonoBehaviour
{
    public event UnityAction ObjectSlicedEvent;

    [SerializeField] private GameObject _cubeSlice;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            PoolerObject.ReturnGameObject(objectBehaviour.gameObject);
            ObjectSlicedEvent?.Invoke();

            GameObject newObj = PoolerObject.GetObject(_cubeSlice);
            newObj.transform.position = gameObject.transform.position;
            newObj.SetActive(true);

            //Instantiate(_cubeSlice, objectBehaviour.gameObject.transform.position, objectBehaviour.gameObject.transform.rotation);
            //_cubeSlice.SetActive(true);
        }
    }
}
