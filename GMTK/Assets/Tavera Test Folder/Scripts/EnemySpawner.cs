using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnTimer = 2;
    public float spawnerXAxisRange = 8;
    
    private Vector3 topScreenWall;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        topScreenWall = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 1));
        Physics2D.gravity = new Vector2(0, 0);
        transform.position = new Vector3(topScreenWall.x, topScreenWall.y, topScreenWall.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnerXAxisRange, spawnerXAxisRange), transform.position.y, 0);
            var newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(newEnemy, 3.0f);
            
            timer = enemySpawnTimer;
        }
        
        timer -= Time.deltaTime;
    }
}
