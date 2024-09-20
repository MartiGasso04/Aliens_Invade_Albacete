using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitPrefab;
    public float explosionDuration = 2f;
   
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")||other.CompareTag("ExtraEnemy")||other.CompareTag("Boss"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                
                // Llama al método TakeDamage y proporciona un valor de daño
                enemy.TakeDamage(1); // Cambia 1 por el valor de daño que desees
                                     // El valor de daño puede ser cualquier número entero que desees
                                     // y puede ser variable según tus necesidades de juego
            }

            
            
            // El resto del código permanece igual
            Vector3 enemyPosition = other.transform.position;
            GameObject explosionInstance = Instantiate(hitPrefab, enemyPosition, Quaternion.identity);
            explosionInstance.SetActive(true);
            Destroy(explosionInstance, explosionDuration);
            Destroy(gameObject);
        }
    }
}