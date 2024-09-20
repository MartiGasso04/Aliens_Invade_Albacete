using UnityEngine;

public class PowerfulProjectile : MonoBehaviour
{
    public GameObject hitPrefab; // Prefab de la animaci�n de la explosi�n grande
    public float explosionDuration = 1.5f; // Duraci�n de la explosi�n grande
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")||other.CompareTag("ExtraEnemy")||other.CompareTag("Boss"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Aplicar da�o al enemigo
                enemy.TakeDamage(2);
            }

            // Obtener la posici�n del impacto
            Vector3 impactPosition = transform.position;

            // Instanciar la animaci�n de la explosi�n grande en la posici�n del impacto
            GameObject explosionInstance = Instantiate(hitPrefab, impactPosition, Quaternion.identity);

            // Activar la instancia de la explosi�n
            explosionInstance.SetActive(true);

            // Destruir la instancia de la explosi�n despu�s de la duraci�n especificada
            Destroy(explosionInstance, explosionDuration);

            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}
