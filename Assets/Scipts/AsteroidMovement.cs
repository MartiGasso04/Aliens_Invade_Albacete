using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f; 
    public GameObject asteroidPrefab; 
    public int minAsteroids = 1; 
    public int maxAsteroids = 3;

    private Camera mainCamera;
    private float cameraWidth;

    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.aspect * mainCamera.orthographicSize;

        
        GenerateAsteroids();
    }

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (transform.position.x + cameraWidth < mainCamera.transform.position.x - cameraWidth)
        {
            float newXPosition = mainCamera.transform.position.x + cameraWidth * 2f;
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

            GenerateAsteroids();
        }
    }

    void GenerateAsteroids()
    {
        int asteroidCount = Random.Range(minAsteroids, maxAsteroids + 1);

        for (int i = 0; i < asteroidCount; i++)
        {
            float randomYPosition = Random.Range(mainCamera.transform.position.y - cameraWidth, mainCamera.transform.position.y + cameraWidth);

            Instantiate(asteroidPrefab, new Vector3(transform.position.x, randomYPosition, transform.position.z), Quaternion.identity);
        }
    }
}
