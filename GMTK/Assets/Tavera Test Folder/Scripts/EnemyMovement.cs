using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool canMove = true;
    public float playerLoseLiveDelayTimer = .5f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove = timer <= 0;

        if(!gameObject.GetComponent<EnemyHealth>().isDeath && canMove)
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        else if(gameObject.GetComponent<EnemyHealth>().isDeath && canMove)
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        timer -= Time.deltaTime;
    }

    public void AddDelay()
    {
        timer = playerLoseLiveDelayTimer;
    }
}
