using UnityEngine;

public class EnemyDeathManager : MonoBehaviour
{
    public AudioSource impactSound; 

    void Start()
    {
       
        Enemy.OnEnemyHit += PlayImpactSound;
        Enemy.OnEnemyDeath += PlayImpactSound;
    }

    void PlayImpactSound()
    {
       
        impactSound.Play();
    }

    void OnDestroy()
    {
        
        Enemy.OnEnemyHit -= PlayImpactSound;
        Enemy.OnEnemyDeath -= PlayImpactSound;
    }
}
