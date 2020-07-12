using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    private AudioSource audioSource;
    public float deathDelay = 2;

    private float deathTimer = 0;
    private Animator animator;
    
    [HideInInspector]
    public bool isDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = GetComponent<ElementComp>().elementObj.pinAliveController;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeath && deathTimer <= 0)
        {
            Destroy(gameObject);
        }

        deathTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && !isDeath)
        {
            ElementComp bulletElementComp = collision.gameObject.GetComponent<ElementComp>();
            ElementComp pinElementComp = GetComponent<ElementComp>();

            if (!bulletElementComp || !pinElementComp) { return; }

            int damageTaken = bulletElementComp.elementObj == pinElementComp.elementObj ? 2 : 1;
            health -= damageTaken;

            animator.runtimeAnimatorController = GetComponent<ElementComp>().elementObj.crackPinAliveController;

            if (bulletElementComp.elementObj != pinElementComp.elementObj)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Player" && !isDeath)
        {
            health = 0;
        }

        if (health <= 0 && !isDeath)
        {
            ScoreManager.instance.IncreaseEnemyKillInCurrentFrame();
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        if(health > 0) { return; }
        
        deathTimer = deathDelay;
        isDeath = true;

        AudioClip rndPinDownClip = SoundManager.instance.GetRandomPinHit();
        audioSource.clip = rndPinDownClip;
        audioSource.loop = false;
        audioSource.volume = SoundManager.instance.enableSoundEfx ? SoundManager.instance.soundEfxVolume : 0;
        audioSource.Play();

        animator.runtimeAnimatorController = GetComponent<ElementComp>().elementObj.crackPinDeathController[Random.Range(0, 2)];
    }

    private void OnDestroy()
    {
        EnemyManager.instance.enemiesOnField.Remove(this.gameObject);
    }
}