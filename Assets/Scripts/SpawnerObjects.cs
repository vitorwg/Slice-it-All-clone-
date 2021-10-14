using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    [SerializeField] private float _timerToSpawn;
    [SerializeField] private CheckPoint _checkPoint;

    [Header("Pooler Settings")]
    [SerializeField] private List<GameObject> _objectsPrefabsList = new List<GameObject>();

    private void Start()
    {
        _checkPoint.CheckPointEvent += SpawnObject;
    }

    private void SpawnObject()
    {
        int randomObjSpawn = Random.Range(0, _objectsPrefabsList.Count);
        GameObject newObj = PoolerObject.GetObject(_objectsPrefabsList[randomObjSpawn]);
        newObj.transform.position = gameObject.transform.position;
        newObj.SetActive(true);
    }






    //private IEnumerator coroutine;
    //private void Start()
    //{
    //    coroutine = WaitAndPrint(_timerToSpawn);
    //    StartCoroutine(coroutine);

    //    print("Before WaitAndPrint Finishes " + Time.time);
    //}

    //private IEnumerator WaitAndPrint(float waitTime)
    //{
    //    while (true)
    //    {
    //        int randomObjSpawn = Random.Range(0, _objectsPrefabsList.Count);
    //        GameObject newObj = PoolerObject.GetObject(_objectsPrefabsList[randomObjSpawn]);
    //        newObj.transform.position = gameObject.transform.position;
    //        newObj.SetActive(true);

    //        yield return new WaitForSeconds(waitTime);
    //    }
    //}
}