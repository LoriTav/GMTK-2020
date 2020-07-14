using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool canMove = true;
    public bool stop = false;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove = timer <= 0;
        stop = ScoreManager.instance.isGameOver;

        if(!gameObject.GetComponent<EnemyHealth>().isDeath && canMove && !stop)
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        else if(gameObject.GetComponent<EnemyHealth>().isDeath && canMove && !stop)
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        timer -= Time.deltaTime;
    }

    public void AddDelay(float delayTimer)
    {
        timer = delayTimer;
    }

    public void Move()
    {

    }
}
