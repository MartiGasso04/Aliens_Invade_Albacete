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
                
                // Llama al m�todo TakeDamage y proporciona un valor de da�o
                enemy.TakeDamage(1); // Cambia 1 por el valor de da�o que desees
                                     // El valor de da�o puede ser cualquier n�mero entero que desees
                                     // y puede ser variable seg�n tus necesidades de juego
            }

            
            
            // El resto del c�digo permanece igual
            Vector3 enemyPosition = other.transform.position;
            GameObject explosionInstance = Instantiate(hitPrefab, enemyPosition, Quaternion.identity);
            explosionInstance.SetActive(true);
            Destroy(explosionInstance, explosionDuration);
            Destroy(gameObject);
        }
    }
}