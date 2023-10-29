using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool, this class has a dictionary with all the objects that should be pooled
/// </summary
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> objectsToPool;    
    public int amountToPool;

    private Dictionary<int, List<GameObject>> pool = new Dictionary<int, List<GameObject>>();

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {        
        GameObject temp;
        for(int i =0; i < objectsToPool.Count; i++)
        {
            pool[i] = new List<GameObject>();
            for (int j = 0; j < amountToPool; ++j)
            {                
                temp = Instantiate(objectsToPool[i]);
                temp.SetActive(false);
                pool[i].Add(temp);
            }
        }
    }

   
    public GameObject GetObjectFromPool(int idx)
    {
        for(int i = 0;i < pool[idx].Count;++i)
        {
            if (!pool[idx][i].activeInHierarchy)
            {
                return pool[idx][i];
            }
        }
        return null;
    }

    public bool AreThereEnemies()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (GameObject robot in pool[i])
            {
                if (robot.activeInHierarchy)
                    return true;
            }
        }
        return false;

    }

}
