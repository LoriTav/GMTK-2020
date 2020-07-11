using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<GameObject> enemiesOnField;
    public int totalEnemiesToSpawn;
    public EnemySpawner[] spawners;
    public float activateSpawnersTimer = 2f;

    private float timer = 0;
    private int currentSpawnerIdx;
    private int indSpawnerToSpawn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        enemiesOnField = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
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
        if(enemiesOnField.Count <= 0 && timer <= 0)
        {
            foreach(var spawner in spawners)
            {
                spawner.enemiesToSpawn = indSpawnerToSpawn;
            }

            timer = activateSpawnersTimer;
            currentSpawnerIdx = 0;
        }

        timer -= Time.deltaTime;
        
        if(currentSpawnerIdx < spawners.Length && timer <= 0)
        {
            spawners[currentSpawnerIdx].isActivated = spawners[currentSpawnerIdx].enemiesToSpawn > 0;
        
            if(spawners[currentSpawnerIdx].enemiesToSpawn <= 0)
            {
                if(currentSpawnerIdx + 1 >= spawners.Length)
                {
                    return;
                }
                else
                {
                    currentSpawnerIdx++;
                }
            }
        }
    }
}
