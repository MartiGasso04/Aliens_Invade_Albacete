using UnityEngine;

public class PowerfulProjectile : MonoBehaviour
{
    public GameObject hitPrefab; // Prefab de la animación de la explosión grande
    public float explosionDuration = 1.5f; // Duración de la explosión grande
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")||other.CompareTag("ExtraEnemy")||other.CompareTag("Boss"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Aplicar daño al enemigo
                enemy.TakeDamage(2);
            }

            // Obtener la posición del impacto
            Vector3 impactPosition = transform.position;

            // Instanciar la animación de la explosión grande en la posición del impacto
            GameObject explosionInstance = Instantiate(hitPrefab, impactPosition, Quaternion.identity);

            // Activar la instancia de la explosión
            explosionInstance.SetActive(true);

            // Destruir la instancia de la explosión después de la duración especificada
            Destroy(explosionInstance, explosionDuration);

            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}
