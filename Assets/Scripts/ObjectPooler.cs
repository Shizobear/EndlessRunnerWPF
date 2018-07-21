using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // Use this for initialization
    public GameObject pooledObject;
    public int poolSize;
    List<GameObject> pool;
    void Start()
    {

        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GenerateObject();
        }
    }

    private void GenerateObject()
    {
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pool.Add(obj);
    }


public GameObject GetObjectFromPool()
{

    for (int i = 0; i < pool.Count; i++)
    {
        if (pool[i].activeInHierarchy == false)
        {
            return pool[i];
        }
    }

	GenerateObject();
	return pool[pool.Count - 1];

}
}
