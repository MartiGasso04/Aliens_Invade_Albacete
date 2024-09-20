using UnityEngine;

public class ExtraEnemy : MonoBehaviour
{
    public GameObject extraEnemyPrefab;
    public Transform enemySpawnPoint;
    public Transform enemyTargetPoint;
    public float moveSpeed = 4f;
    private int maxEnemyCount = 14; 
    private int enemyCount = 0; 
    private GameObject spawnedExtraEnemy; 
    private Rigidbody2D enemyRb; 
    private bool shouldMove = true; 

    void Start()
    {

        Enemy.OnEnemyDeath += HandleEnemyDeath;
    }
    private bool AreEnemiesPresent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemyTargetPoint.position, 1f); 
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("ExtraEnemy"))
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

            SpawnExtraEnemy();

        }
    }

    private void SpawnExtraEnemy()
    {
        if (!AreEnemiesPresent()) {
            if (enemySpawnPoint != null && extraEnemyPrefab != null)
            {
                GameObject spawnedExtraEnemy = Instantiate(extraEnemyPrefab, enemySpawnPoint.position, Quaternion.identity);

                Rigidbody2D extraEnemyRb = spawnedExtraEnemy.GetComponent<Rigidbody2D>();

                spawnedExtraEnemy.SetActive(true);

                shouldMove = true;
                if (shouldMove && spawnedExtraEnemy != null && enemyTargetPoint != null)
                {
                    Vector3 direction = (enemyTargetPoint.position - spawnedExtraEnemy.transform.position).normalized;

                    extraEnemyRb.velocity = direction * moveSpeed;
                }
                else
                {
                    extraEnemyRb.velocity = Vector2.zero;
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
        if (other.CompareTag("ExtraEnemy"))
        {
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
            enemyRb.velocity = Vector2.zero;


        }

    }
}
