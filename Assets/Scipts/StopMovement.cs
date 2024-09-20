using UnityEngine;

public class StopMovement : MonoBehaviour
{
    // Método que se llama cuando el collider del objeto vacío entra en contacto con otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el collider con el que choca tiene la etiqueta "Boss"
        if (other.CompareTag("BossTarget"))
        {
            // Obtener el Rigidbody2D del objeto que ha colisionado
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            // Detener el movimiento del objeto que ha colisionado
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}