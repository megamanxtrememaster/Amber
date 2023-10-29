using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProj: MonoBehaviour
{
    public void PlantMine()
    {
        GameObject mine = ObjectPool.instance.GetObjectFromPool(4);
        if (mine != null)
        {
            mine.transform.position = this.gameObject.transform.parent.position + Vector3.back*0.1f;
            mine.GetComponent<Projectile>().Spawn();
            mine.SetActive(true);
        }
    }

    public void TeleportAroundStage()
    {
        gameObject.transform.parent.position = Grid.Instance.GetRandomPlayerTile() +Vector3.up * 5;
    }
}
