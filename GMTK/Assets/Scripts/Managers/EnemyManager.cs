using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemiesOnField;
    public int totalEnemiesToSpawn;
    public EnemySpawner[] spawners;
    public float activateSpawnersTimer = 2f;
    public bool isActivated = false;

    private float timer = 0;
    private int currentSpawnerIdx;
    private int indSpawnerToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance.enemyManager = this;
        Physics2D.gravity = new Vector2(0, 0);
        RestartEnemyManager();
    }

    public void RestartEnemyManager()
    {
        enemiesOnField = new List<GameObject>();
        indSpawnerToSpawn = (int)totalEnemiesToSpawn / spawners.Length;
        currentSpawnerIdx = 0;
        timer = activateSpawnersTimer;

        foreach (var spawner in spawners)
        {
            spawner.enemiesToSpawn = indSpawnerToSpawn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        // Complete the frame if the the manager is activated, all spawners finished spawning enemies, and no enemies on the field 
        if(isActivated && enemiesOnField.Count == 0 && areSpawnersDone())
        {
            ScoreManager.instance.CompleteFrame();
        }
        
        // Only start spawning after the delay and if the spawners haven't spawn a certain number of enemies
        if(currentSpawnerIdx < spawners.Length && timer <= 0)
        {
            spawners[currentSpawnerIdx].isActivated = spawners[currentSpawnerIdx].enemiesToSpawn > 0;
        
            if(spawners[currentSpawnerIdx].enemiesToSpawn <= 0 && currentSpawnerIdx + 1 < spawners.Length)
            {
                currentSpawnerIdx++;
            }
        }
    }

    // Used when an enemy reaches the bottom gutter
    public void DelayEnemies()
    {
        foreach(var enemy in enemiesOnField)
        {
            enemy.GetComponent<EnemyMovement>().AddDelay();
        }
    }

    // Checks if the spawners are activated. Used to signal if spawners are done spawning enemies 
    private bool areSpawnersDone()
    {
        foreach(var spawner in spawners)
        {
            if (spawner.isActivated == true)
            {
                return false;
            }
        }

        return true;
    }
}
