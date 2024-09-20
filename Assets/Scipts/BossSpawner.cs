using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossEnemyPrefab;
    public Transform BossSpawnPoint;
    public Transform BossTargetPoint;
    public float moveSpeed = 4f;
    private int maxEnemyCount = 30; 
    private int enemyCount = 0; 
    private GameObject spawnedBoss; 
    private Rigidbody2D BossRb; 
    private bool shouldMove = true; 

    void Start()
    {

        Enemy.OnEnemyDeath += HandleEnemyDeath; 
    }
    private bool AreEnemiesPresent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(BossTargetPoint.position, 1f); 
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Boss"))
            {
                return true; 
            }
        }
        return false; 
    }
    private void HandleEnemyDeath()
    {
        
        enemyCount++;

        
        if (enemyCount >= maxEnemyCount)
        {
            
            enemyCount = 0;

            
            SpawnBoss();

        }
    }

    private void SpawnBoss()
    {
        if (!AreEnemiesPresent())
        {
            if (BossSpawnPoint != null && BossEnemyPrefab != null)
            {
                
                GameObject spawnedBoss = Instantiate(BossEnemyPrefab, BossSpawnPoint.position, Quaternion.identity);

                
                Rigidbody2D BossEnemyRb = spawnedBoss.GetComponent<Rigidbody2D>();

                
                spawnedBoss.SetActive(true);

               
                shouldMove = true;
                if (shouldMove && spawnedBoss != null && BossTargetPoint != null)
                {
                    
                    Vector3 direction = (BossTargetPoint.position - spawnedBoss.transform.position).normalized;

                   
                    BossEnemyRb.velocity = direction * moveSpeed;
                }
                else
                {
                    
                    BossEnemyRb.velocity = Vector2.zero;
                }

            }
            else
            {
                Debug.LogWarning("El punto de generación o el prefab del enemigo extra no están asignados.");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
           
            Rigidbody2D BossRb = other.GetComponent<Rigidbody2D>();
            BossRb.velocity = Vector2.zero;


        }

    }
}
