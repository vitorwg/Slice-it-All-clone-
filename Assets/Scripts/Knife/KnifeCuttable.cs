using UnityEngine;
using UnityEngine.Events;

public class KnifeCuttable : MonoBehaviour
{
    public event UnityAction ObjectSlicedEvent;

    [SerializeField] private GameObject _cubeSlice;

    private AudioSource _sliceSound;

    private void Awake()
    {
        _sliceSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ObjectBehaviour objectBehaviour))
        {
            _sliceSound.Play();
            //objectBehaviour.OnPlaySliceSound();
            PoolerObject.ReturnGameObject(objectBehaviour.gameObject);
            ObjectSlicedEvent?.Invoke();

            GameObject newObj = PoolerObject.GetObject(_cubeSlice);
            newObj.transform.position = gameObject.transform.position;
            newObj.SetActive(true);
        }
    }
}
