using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = .7f;
    public float spawnerXAxisRange = 1.5f;
    public float timeToDestroyPin = 10f;
    public bool isActivated = false;
    public int enemiesToSpawn = 0;

    private EnemyManager enemyManager;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
        Physics2D.gravity = new Vector2(0, 0);
        
        // Positions spawner on top of screen view
        Camera cam = Camera.main;
        Vector3 topScreenWall = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 1));
        transform.position = new Vector3(transform.position.x, topScreenWall.y, topScreenWall.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0 && enemiesToSpawn > 0 && isActivated && enemyManager.isActivated)
        {
            // Gets a random position based on spawner to spawn the new enemy
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x - spawnerXAxisRange, transform.position.x + spawnerXAxisRange), transform.position.y, 0);
            
            // Spawn the actual enemy using the spawn position generated above
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(newEnemy, timeToDestroyPin);
            
            // Apply random element to pin
            int rndElementIdx = Random.Range(0, SlotMachineManager.instance.allElementsObjs.Length);
            newEnemy.GetComponent<ElementComp>().elementObj = SlotMachineManager.instance.allElementsObjs[rndElementIdx];
            
            // Add the enemy to the enemy manager to keep track of it
            enemyManager.enemiesOnField.Add(newEnemy);
            enemiesToSpawn--;

            timer = spawnDelay;
        }
        
        timer -= Time.deltaTime;
    }
}
