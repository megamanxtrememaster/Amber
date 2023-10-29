using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetProj : MonoBehaviour
{
    Mettaur parent;

    void Awake()
    {
        parent = transform.parent.GetComponent<Mettaur>();    
    }

    public void Shoot()
    {
        GameObject proj = ObjectPool.instance.GetObjectFromPool(3);
        if (proj != null)
        {
            proj.transform.position = this.gameObject.transform.position + Vector3.back * 0.1f;
            proj.GetComponent<Projectile>().Spawn();
            proj.SetActive(true);
        }
    }

}
