using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles the Grid where the game takes place, the grid is split between enemy and player tiles
/// the idea is that some attacks can capture or destroy tiles
/// </summary
public class Grid : MonoBehaviour
{
    public static Grid Instance;
    public int width;
    public int height;

    public GameObject tileUser;
    public GameObject tileEnemy;
    public GameObject home;

    private int tileWidth;
    public int TileWidth { get { return tileWidth; } }

    GameObject[,] tiles;

    void Awake()
    {
        Instance = this;    
    }

    public Vector3 GetRandomPlayerTile()
    {
        int randW = Random.Range(0, width / 2);
        int randH = Random.Range(0, height);

        return new Vector3(tileWidth/2 + randW * tileWidth, 0, tileWidth/2 +randH * tileWidth);
    }

    public Vector3 GetRandomEnemyTile()
    {
        int randW = Random.Range(width/2, width);
        int randH = Random.Range(0, height);

        return new Vector3(tileWidth / 2 + randW * tileWidth, 0, tileWidth/2 + randH * tileWidth);
    }

    void Start()
    {
        tileWidth = 10;
        tiles = new GameObject[width,height];

        for(int i = 0;i<width;++i)
        {
            for(int j = 0;j<height;++j)
            {
                if(i >= width/2)
                    tiles[i,j] = Instantiate(tileEnemy, this.transform);                
                else
                    tiles[i, j] = Instantiate(tileUser, this.transform);
                tiles[i, j].transform.position = new Vector3(tileWidth/2 + i*tileWidth, 0, tileWidth/2 + j*tileWidth);
            }
        }
        home.transform.localScale = new Vector3(1, 20 ,10 * height);
        home.transform.position = new Vector3(home.transform.position.x, home.transform.position.y, height * 5);
    }

}
