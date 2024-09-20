using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 5f; 
    public int damage = 1;
    private float minCooldown = 1f; 
    private float maxCooldown = 4f;
    public AudioSource ShootSound;

    void Start()
    {
        ShootSound.enabled = false;
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
        ShootSound.enabled = true;
        ShootSound.Play();
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * projectileSpeed;
        Destroy(projectile, 6f);
    }
}
