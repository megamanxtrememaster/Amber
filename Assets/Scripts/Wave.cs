using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains the data required for a wave
/// A length, which is the duration of the wave(in seconds)
/// A difficulty, which indicates how difficult will the wave be
/// </summary
[System.Serializable]
public class WaveData
{
    public float length;
    [Range(1, 10)]
    public int difficulty;
}


/// <summary>
/// This class takes a WaveData object and generates a wave of enemies
/// Each wave is split in 5 time instants, in each of these instants we 
/// might spawn enemies, we get a random number between 0 and 9, and if that
/// number is less than the difficulty value, then we spawn a random enemy at that instant
/// so in a difficulty 10 wave, we spawn 5 enemies spaced evenly during the duration of the wave
/// </summary
public class Wave
{
    public WaveData data;

    private float timer = 0f;
    private float waveTime;
    private int waveAcc = 0;
    private Grid grid;

    public Wave(WaveData data, Grid grid)
    {
        this.data = data;        
        this.grid = grid;
        waveTime = data.length / 5f;
    }

    public bool Finished()
    {
        return waveAcc >= 5;
    }
    
    
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waveTime && waveAcc < 5)
        {
            int chance = Random.Range(0, 10);

            if(chance <= data.difficulty)
            {
                int enemy = Random.Range(0, 3);
                
                GameObject enemyO = ObjectPool.instance.GetObjectFromPool(enemy);
                if (enemyO != null)
                {
                    Vector3 positionInGrid = grid.GetRandomEnemyTile();
                    enemyO.transform.position = positionInGrid + Vector3.up * 5;
                    enemyO.GetComponent<Robot>().Spawn();
                    enemyO.SetActive(true);
                }
            }
            timer -= waveTime;
            waveAcc++;
        }
        
    }
}
