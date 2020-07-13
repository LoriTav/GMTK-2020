using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDestoyer : MonoBehaviour
{
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyHealth>())
        {
            DestoryALive();
            Destroy(collision.gameObject);
        }
    }

    private void DestoryALive()
    {
        if(ScoreManager.instance.isGameOver) { return; }
        ScoreManager.instance.ReduceALive();
        enemyManager.DelayEnemies();
    }
}
