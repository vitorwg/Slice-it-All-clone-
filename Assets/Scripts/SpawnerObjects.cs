using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjects : MonoBehaviour
{
    [SerializeField] private CheckPoint _checkPoint;
    [SerializeField] private Transform[] _spawnPoint;

    [Header("Pooler Settings")]
    [SerializeField] private List<GameObject> _objectsPrefabsList = new List<GameObject>();

    private void Start()
    {
        CheckPoint.CheckPointEvent += SpawnObject;

        //_checkPoint.CheckPointEvent += SpawnObject;
    }

    private void SpawnObject()
    {
        Debug.Log("Object " + " will spawn: " + _spawnPoint[0].position);
        for (int i = 0; i < _spawnPoint.Length; i++)
        {
            int randomObjSpawn = Random.Range(0, _objectsPrefabsList.Count);
            GameObject newObj = PoolerObject.GetObject(_objectsPrefabsList[randomObjSpawn]);
            newObj.transform.position = _spawnPoint[i].position;
            newObj.SetActive(true);
            Debug.Log("Object " + i + " will spawn: " + _spawnPoint[i].position);
        } 
    }

    private void OnDisable()
    {
        //_checkPoint.CheckPointEvent -= SpawnObject;
    }
}