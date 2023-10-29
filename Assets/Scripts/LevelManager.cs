using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
///Level Manager, this class handles the level logic, it contains the list of waves contained in the level and references to the grid and player, so it 
///can check when is the game over
/// </summary
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public PlayerRobot player;
    public List<WaveData> waves;

    private int currentWave = 0;
    private Grid grid;
    private Wave wave;
    [Range(1, 10)]
    public float homeHealth;
    public int CurrentWave
    {
        get { return currentWave; } 
    }
    

    void Awake()
    {
        instance = this;    
    }

    public void TakeDamageHome(float damage)
    {
        homeHealth -= damage;
    }


    private void LoadWave(int waveNumber)
    {
        if(waveNumber < waves.Count)
            wave = new Wave(waves[waveNumber], grid);
    }

    void Start()
    {
        grid = Grid.Instance.GetComponent<Grid>();
        LoadWave(currentWave);
    }

    private void UpdateWaves()
    {
        wave.Update();
        if (wave.Finished() && currentWave < waves.Count - 1)
        {
            currentWave++;
            LoadWave(currentWave);
        }
    }
    
    void Update()
    {
        if(homeHealth <= 0 || player.Health <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        if(ObjectPool.instance.AreThereEnemies() == false && currentWave >= waves.Count - 1)
        {
            SceneManager.LoadScene("GameOverScreen");
        }

        UpdateWaves();
    }
}
