using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnTimer = 2f;
    public float spawnerXAxisRange = 8f;
    public float timeToDestroyPin = 5f;
    public bool isActivated = false;
    public int enemiesToSpawn = 0;

    private Vector3 topScreenWall;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        topScreenWall = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 1));
        transform.position = new Vector3(transform.position.x, topScreenWall.y, topScreenWall.z);
        Physics2D.gravity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0 && enemiesToSpawn > 0 && isActivated && EnemyManager.instance.isActivated)
        {
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x - spawnerXAxisRange, transform.position.x + spawnerXAxisRange), transform.position.y, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            
            int rndElementIdx = Random.Range(0, SlotMachineManager.instance.allElementsObjs.Length);
            
            newEnemy.GetComponent<ElementComp>().elementObj = SlotMachineManager.instance.allElementsObjs[rndElementIdx];
            newEnemy.GetComponent<ElementComp>().UpdateSelfElement();
            
            EnemyManager.instance.enemiesOnField.Add(newEnemy);
            enemiesToSpawn--;

            timer = enemySpawnTimer;
        }
        
        timer -= Time.deltaTime;
    }
}
