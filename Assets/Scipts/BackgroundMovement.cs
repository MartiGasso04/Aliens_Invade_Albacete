using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Transform player; 
    public float speed = 5f; 

    private Camera mainCamera;
    private float cameraWidth;

    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.aspect * mainCamera.orthographicSize;
    }

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x + cameraWidth < mainCamera.transform.position.x - cameraWidth)
        {
            
            float newXPosition = mainCamera.transform.position.x + cameraWidth * 2f;
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
    }
}