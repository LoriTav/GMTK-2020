using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<GameObject> enemiesOnField;
    public EnemySpawner enemySpawner;
    public int enemiesToSpawn;
    public int enemiesLeftToSpawn = 0;

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
        enemiesLeftToSpawn = enemiesToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesOnField.Count <= 0)
        {
            enemiesLeftToSpawn = enemiesToSpawn;
        }
    }
}
