using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellObject : MonoBehaviour
{
    public Rigidbody2D spellRb;
    public float spellSpeed = 8;
    public float timeTilDestroy = 5;
    public Elements_SO elementObj;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spellRb = transform.GetComponent<Rigidbody2D>();
        spellRb.velocity = transform.up * spellSpeed;

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = gameObject.GetComponent<ElementComp>().elementObj.audioClip;
        audioSource.Play();
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
