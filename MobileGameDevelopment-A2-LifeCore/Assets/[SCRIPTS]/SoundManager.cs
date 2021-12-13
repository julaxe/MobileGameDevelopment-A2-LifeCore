using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;
    private AudioSource audioSourceEffects;

    private AudioClip backgroundMusic, playerShoot, enemyShoot, playerGettingHit, enemyDie;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            Instance = this;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        backgroundMusic = Resources.Load<AudioClip>("Sounds/Music/InGame");
        playerShoot = Resources.Load<AudioClip>("Sounds/Effects/PlayerShoot");
        playerGettingHit = Resources.Load<AudioClip>("Sounds/Effects/PlayerHit");
        enemyShoot = Resources.Load<AudioClip>("Sounds/Effects/EnemyShoot");
        enemyDie = Resources.Load<AudioClip>("Sounds/Effects/EnemyDie");
        
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(backgroundMusic);
        
        audioSourceEffects = transform.Find("Effects").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Play(string key)
    {
        switch (key)
        {
            case "PlayerShoot":
                audioSourceEffects.PlayOneShot(playerShoot);
                break;
            case "PlayerHit":
                audioSourceEffects.PlayOneShot(playerGettingHit);
                break;
            case "EnemyShoot":
                audioSourceEffects.PlayOneShot(enemyShoot);
                break;
            case "EnemyDie":
                audioSourceEffects.PlayOneShot(enemyDie);
                break;
            default:
                break;
        }
    }

    public void Stop()
    {
        audioSource.Stop();
    }
    
}
