using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnDelay = 2f; 
    public Transform targetPoint; 
    public float moveSpeed = 2f; 
    public float spawnOffset = 1f; 
    public Transform emptyObject; 

    private int enemyCount = 0; 

    void Start()
    {
        Enemy.OnEnemyDeath += HandleEnemyDeath;
    }

    private void EnableSpawning()
    {
        enemyCount = 0;
    }

    private bool AreEnemiesPresent()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(emptyObject.position, 1f); 
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("enemy"))
            {
                return true; 
            }
        }
        return false; 
    }

    private void SpawnEnemy()
    {
       
        if (!AreEnemiesPresent())
        {
            Vector3 spawnPosition = targetPoint.position + new Vector3(spawnOffset, 0f, 0f);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            MoveTowardsTarget(newEnemy);
        }
        else
        {
            Debug.Log("Hay enemigos presentes en el área del empty object. No se generará un nuevo enemigo.");
        }
    }

    private void MoveTowardsTarget(GameObject enemy)
    {
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

        Vector3 direction = (targetPoint.position - enemy.transform.position).normalized;

        if (Vector3.Distance(enemy.transform.position, targetPoint.position) <= 0.1f)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = direction * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
            enemyRb.velocity = Vector2.zero;

            HandleEnemyDeath();
        }
    }

    private void HandleEnemyDeath()
    {
        enemyCount++;

        if (enemyCount == 9)
        {
            enemyCount = 0;

            Invoke("SpawnEnemy", spawnDelay);
        }
    }
}
