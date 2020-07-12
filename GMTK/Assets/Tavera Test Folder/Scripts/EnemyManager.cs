using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<GameObject> enemiesOnField;
    public int totalEnemiesToSpawn;
    public EnemySpawner[] spawners;
    public float activateSpawnersTimer = 2f;
    public bool isActivated = false;

    private float timer = 0;
    private int currentSpawnerIdx;
    private int indSpawnerToSpawn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //DontDestroyOnLoad(gameObject);
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
        RestartEnemyManager();
    }

    public void RestartEnemyManager()
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
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2) { return; }
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

    public void DelayEnemies()
    {
        foreach(var enemy in enemiesOnField)
        {
            enemy.GetComponent<EnemyMovement>().AddDelay();
        }
    }
}
