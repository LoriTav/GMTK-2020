using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    public Rigidbody2D spellRb;
    public float spellSpeed = 8;
    public float timeTilDestroy = 5;

    // Start is called before the first frame update
    void Start()
    {
        spellRb = transform.GetComponent<Rigidbody2D>();
        spellRb.velocity = transform.up * spellSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timeTilDestroy -= Time.deltaTime;

        if (timeTilDestroy <= 0)
        {
            DestroySpell();
        }
    }

    public void DestroySpell()
    {
        Destroy(gameObject);
    }
}
