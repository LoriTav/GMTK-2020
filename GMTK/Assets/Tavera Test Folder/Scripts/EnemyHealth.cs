﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            ElementComp bulletElementComp = collision.gameObject.GetComponent<ElementComp>();
            ElementComp pinElementComp = GetComponent<ElementComp>();

            if(!bulletElementComp || !pinElementComp) { return; }

            if(bulletElementComp.elementObj != pinElementComp.elementObj)
            {
                health--;
                Debug.Log(name + " Received damage");
            }

            if((bulletElementComp.elementObj == pinElementComp.elementObj) || health <= 0)
            {
                Debug.Log(name + " is dead");
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Player")
        {
            health = 0;
            Debug.Log(name + " is dead");
            Destroy(gameObject);
        }
    }
}