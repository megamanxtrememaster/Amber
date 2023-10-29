using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRobot : Robot
{
    public GameObject Grid;
    Grid gridScript;
       
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        gridScript = Grid.GetComponent<Grid>();
        this.transform.position = new Vector3(5, 4, 5 + gridScript.height / 2 * 10);
    }


    private void Move(Vector2 direction)
    {
        Vector2 currentPos = new Vector2((this.transform.position.x - 5) / 10, (this.transform.position.z -5) / 10);
        Vector3 toAdd = Vector3.zero;
        if (direction.x > 0)
        {            
            if(gridScript.width/2 > currentPos.x+1)
            {
                toAdd.x++;
            }
        }
        else if(direction.x < 0)
        {
            if (currentPos.x > 0)
                toAdd.x--;
        }
        if(direction.y > 0)
        {
            if(gridScript.height > currentPos.y+1)
            {
                toAdd.z++;
            }            
        }
        else if(direction.y < 0)
        {
            if (currentPos.y > 0)
                toAdd.z--;
        }
        
        this.transform.position +=  toAdd * 10;
    }

    void Update()
    {
        Vector2 dirToMove = Vector2.zero;
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            dirToMove.y = 1;
        }
       else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dirToMove.y = -1;
        }
       if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            dirToMove.x = 1;
        }
       else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dirToMove.x = -1;
        }     
       if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
       if(Input.GetKeyDown(KeyCode.A))
        {
            generateTower1();
        }
        Move(dirToMove);
    }

    private void generateTower1()
    {
        GameObject tower = ObjectPool.instance.GetObjectFromPool(6);
        if (tower != null)
        {
            tower.transform.position = this.gameObject.transform.position;
            tower.GetComponent<Robot>().Spawn();
            tower.SetActive(true);
            Health -= 3;
        }
    }

    private void Shoot()
    {
        GameObject proj = ObjectPool.instance.GetObjectFromPool(5);
        if (proj != null)
        {
            proj.transform.position = this.gameObject.transform.position + Vector3.back * 0.1f;
            proj.GetComponent<Projectile>().Spawn();
            proj.SetActive(true);
        }
    }
}
