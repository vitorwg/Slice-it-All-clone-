using System.Collections.Generic;
using UnityEngine;

public class PoolerObject : MonoBehaviour
{
    private static Dictionary<string, Queue<GameObject>> _objectPool;

    [SerializeField] private List<GameObject> _initialPrefabsList = new List<GameObject>(); 

    private void Awake()
    {
        _objectPool = new Dictionary<string, Queue<GameObject>>();
        for (int i = 0; i < _initialPrefabsList.Count; i++)
        {
            PoolerStartSize(_initialPrefabsList[i], 3);
        }
    }

    public static GameObject GetObject(GameObject objectPooler)
    {
        GameObject obj;
        if (_objectPool.TryGetValue(objectPooler.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                obj = CreateNewObject(objectPooler);
                //Debug.Log("objectList " + objectPooler.name + " size is zero");
            }
            else
            {
                obj = objectList.Dequeue();
                //Debug.Log("objectList " + objectPooler.name + " size = " + objectList.Count);
            }
        }
        else
        {
            obj = CreateNewObject(objectPooler);
            //Debug.Log("Not found list " + objectPooler.name);
        }

        return obj;
    }
    public static void ReturnGameObject(GameObject gameObject)
    {
        if (_objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            _objectPool.Add(gameObject.name, newObjectQueue);
        }

        gameObject.SetActive(false);
    }

    public void PoolerStartSize(GameObject gameObject, int size)
    {
        Queue<GameObject> newObjectQueue = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject newObject = CreateNewObject(gameObject);
            newObject.name = newObject.name;
            newObject.SetActive(false);
            newObjectQueue.Enqueue(newObject);
        }

        _objectPool.Add(gameObject.name, newObjectQueue);
    }

    private static GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newObject = Instantiate(gameObject);
        newObject.name = gameObject.name;
        return newObject;
    }
}
