using UnityEngine;
using System.Collections;

public class BossShot : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float projectileSpeed = 5f;
    public int damage = 1; 
    private float minCooldown = 1f; 
    private float maxCooldown = 4f; 
    public float spreadAngle = 30f;
    public AudioSource shootSound;

    void Start()
    {
        shootSound.enabled = false;
        // Iniciar la rutina de disparo
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        while (true)
        {
            float cooldown = Random.Range(minCooldown, maxCooldown);

            yield return new WaitForSeconds(cooldown);

            Shoot();
        }
    }

    void Shoot()
    {
        shootSound.enabled = true;
        shootSound.Play();
        Vector2 initialDirection = -Vector2.right;

        float spreadAngleInRadians = spreadAngle * Mathf.Deg2Rad;

        Vector2[] directions = new Vector2[3];
        directions[0] = initialDirection;
        directions[1] = Quaternion.AngleAxis(spreadAngle, Vector3.forward) * initialDirection;
        directions[2] = Quaternion.AngleAxis(-spreadAngle, Vector3.forward) * initialDirection;

        foreach (Vector2 direction in directions)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            rb.velocity = direction.normalized * projectileSpeed;

            Destroy(projectile, 3f);
        }
    }
}
