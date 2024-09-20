using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public GameObject heartPrefab;
    public GameObject playerPrefab;
    public GameObject explosionPrefab;
    public float explosionDuration = 3f;
    public float sceneLoad = 6f;
    public Transform heartsParent;
    public float heartOffset = 1f;
    public GameObject impactPrefab;
    public delegate void PlayerDeathAction();
    public static event PlayerDeathAction OnPlayerDeath; 
    public AudioSource impactsound;
    public int currentHealth;
    public SceneLoader sceneLoader;
    public Text livesText; 
    private int livesCount = 5; 

    void Start()
    {
        currentHealth = maxHealth;

       
        impactsound.enabled = false;
        sceneLoader = FindObjectOfType<SceneLoader>();

        UpdateLivesText();
    }

    void Die()
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath(); 
        }
        Debug.Log("Reproduciendo sonido de explosión grande.");

        Destroy(playerPrefab);

        Vector3 playerPosition = playerPrefab.transform.position;
        GameObject explosionInstance = Instantiate(explosionPrefab, playerPosition, Quaternion.identity);
        explosionInstance.SetActive(true);
        Destroy(explosionInstance, explosionDuration);

        sceneLoader.LoadSceneAfterDelay(sceneLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            impactsound.enabled = true;
            impactsound.Play();

            float offsetZ = 1.0f;
            Vector3 playerPosition = playerPrefab.transform.position;
            playerPosition.z = playerPrefab.transform.position.z - offsetZ;
            GameObject impact = Instantiate(impactPrefab, playerPosition, Quaternion.identity);
            impact.SetActive(true);
            Destroy(impact, explosionDuration);
            Destroy(other.gameObject);
            currentHealth--;
            if (currentHealth == 0)
            {
                livesCount = 0;
                UpdateLivesText();
                Die();
            }
            else
            {
                livesCount--;
                UpdateLivesText();
            }
        }
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = ": " + livesCount;
        }
    }
}
