using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ElementComp bulletElementComp = collision.gameObject.GetComponent<ElementComp>();
            ElementComp pinElementComp = GetComponent<ElementComp>();

            if (!bulletElementComp || !pinElementComp) { return; }

            int damageTaken = bulletElementComp.elementObj == pinElementComp.elementObj ? 2 : 1;
            health -= damageTaken;
            
            if(bulletElementComp.elementObj != pinElementComp.elementObj)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            health = 0;
        }

        if(health <= 0)
        {
            ScoreManager.instance.IncreaseEnemyKillInCurrentFrame();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EnemyManager.instance.enemiesOnField.Remove(this.gameObject);
    }
}