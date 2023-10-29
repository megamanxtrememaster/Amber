using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{    
    public PlayerRobot player;
    public LevelManager levelManager;
    Grid grid;
    TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        grid = Grid.Instance.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Player:" + Mathf.FloorToInt(player.Health) + "\nHome:"+Mathf.FloorToInt(levelManager.homeHealth)+"\nWave:"+(levelManager.CurrentWave+1)+"/"+levelManager.waves.Count;

    }
}
