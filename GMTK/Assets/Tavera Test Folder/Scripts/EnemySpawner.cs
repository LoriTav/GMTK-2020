using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnTimer = 2;
    
    private Vector3 topWall;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        var cam = Camera.main;
        topWall = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight, 1));
        Physics2D.gravity = new Vector2(0, 0);
        transform.position = new Vector3(topWall.x, topWall.y, topWall.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(newEnemy, 3.0f);
            timer = enemySpawnTimer;
        }
        
        timer -= Time.deltaTime;
    }
}
