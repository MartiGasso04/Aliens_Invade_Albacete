using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    public AudioSource bigExplosionSound; 
    void Start()
    {
        bigExplosionSound.enabled = false;
       
        PlayerHealth.OnPlayerDeath += PlayBigExplosionSound;
    }

    void PlayBigExplosionSound()
    {
       
        bigExplosionSound.enabled = true;
        bigExplosionSound.Play();
    }

    void OnDestroy()
    {
       
        PlayerHealth.OnPlayerDeath -= PlayBigExplosionSound;
    }
}
