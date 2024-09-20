using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyHitAction();
    public static event EnemyHitAction OnEnemyHit;

    public delegate void EnemyDeathAction();
    public static event EnemyDeathAction OnEnemyDeath;

    public int maxHealth = 2;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            if (OnEnemyHit != null)
            {
                OnEnemyHit();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Boss"))
        {
            GameManager.instance.AddScore(500);
        }
        else
        {
            GameManager.instance.AddScore(100);
        }
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath();
        }
    }
}
