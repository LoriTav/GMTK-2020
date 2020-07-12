using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource levelTheme;
    public AudioClip[] pinsHit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetRandomPinHit()
    {
        int rndIndex = Random.Range(0, pinsHit.Length);

        return pinsHit[rndIndex];
    }
}
