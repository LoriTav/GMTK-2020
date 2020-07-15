using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool stop = false;
    public float slowDownSpeed = .45f;

    private float timer;
    private float originalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //canMove = timer <= 0;
        speed = timer <= 0 ? originalSpeed : slowDownSpeed;
        stop = ScoreManager.instance.isGameOver;

        if(!gameObject.GetComponent<EnemyHealth>().isDeath && !stop)
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        else if(gameObject.GetComponent<EnemyHealth>().isDeath && !stop)
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
