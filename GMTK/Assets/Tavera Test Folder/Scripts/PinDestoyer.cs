using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinDestoyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(ScoreManager.instance.currentLives <= 0) { return; }
        ScoreManager.instance.ReduceALive();
        EnemyManager.instance.DelayEnemies();
    }
}
