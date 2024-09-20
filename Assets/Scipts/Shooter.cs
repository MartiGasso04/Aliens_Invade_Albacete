using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject powerfulShotPrefab;
    public float projectileSpeed = 10f;
    public float destroyDelay = 4f;
    public int maxHits = 2;
    public float initialShootCooldown = 0.5f;
    public float minShootCooldown = 0.25f;
    public int cooldownReductionThreshold = 14;
    public float cooldownReductionAmount = 0.25f;
    public Text countdownText; // Texto para mostrar el contador de enemigos restantes
    public AudioSource shootSound; // AudioSource para el sonido de disparo
    private Transform player;
    private int enemyCount = 7; // Contador de enemigos restantes
    private bool canShoot = true;
    private float currentShootCooldown;
    private bool specialShotReady = true; // Variable para controlar si el proyectil especial está listo para disparar

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentShootCooldown = initialShootCooldown;
        Enemy.OnEnemyDeath += HandleEnemyDeath;

        // Desactivar el sonido de disparo al inicio
        shootSound.Stop();

        // Actualizar el texto del contador de enemigos
        UpdateCountdownText();
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position;
        }

        if (canShoot && Input.GetMouseButtonDown(0))
        {
            Shoot();
            StartCoroutine(ShootCooldown());
        }

        if (canShoot && Input.GetKeyDown(KeyCode.Space) && specialShotReady)
        {
            ShootPowerful();
            StartCoroutine(ShootCooldown());

            specialShotReady = false; // Desactivar la capacidad de disparar el proyectil especial
        }
    }

    void Shoot()
    {
        // Activar y reproducir el sonido de disparo
        shootSound.Play();

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = transform.right;
        rb.velocity = direction * projectileSpeed;
        Destroy(projectile, destroyDelay);
    }

    void ShootPowerful()
    {
        // Activar y reproducir el sonido de disparo
        shootSound.Play();

        GameObject powerfulShot = Instantiate(powerfulShotPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = powerfulShot.GetComponent<Rigidbody2D>();
        Vector2 direction = transform.right;
        rb.velocity = direction * projectileSpeed * 2;
        Destroy(powerfulShot, destroyDelay);

        // Reiniciar el contador de enemigos
        enemyCount = 7;
        UpdateCountdownText();
    }

    private void HandleEnemyDeath()
    {
        if (enemyCount > 0)
        {
            enemyCount--;

            // Actualizar el texto del contador de enemigos
            UpdateCountdownText();
        }

        if (enemyCount <= 0)
        {
            // Mostrar un mensaje indicando que el disparo especial está cargado
            Debug.Log("¡Disparo especial cargado!");
            specialShotReady = true; // Activar la capacidad de disparar el proyectil especial
        }
    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(currentShootCooldown);
        canShoot = true;
    }

    // Método para actualizar el texto del contador de enemigos
    void UpdateCountdownText()
    {
        countdownText.text = "PowerfulshotCoundown: " + Mathf.Max(enemyCount, 0); // Asegurarse de que el contador no sea negativo
    }
}
