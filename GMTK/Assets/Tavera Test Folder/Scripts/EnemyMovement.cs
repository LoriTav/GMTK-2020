using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameObject.GetComponent<EnemyHealth>().isDeath)
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        else
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
