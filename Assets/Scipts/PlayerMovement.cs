using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public AnimatedSprite animatedSpriteScript;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isMovingHorizontal = Mathf.Abs(horizontalInput) > 0;
        bool isMovingVertical = Mathf.Abs(verticalInput) > 0;

        if (animatedSpriteScript != null)
        {
            animatedSpriteScript.enabled = isMovingHorizontal || isMovingVertical;
            if (!isMovingHorizontal && !isMovingVertical)
            {
                animatedSpriteScript.ResetToFirstSprite();
            }
        }

        // Movimiento horizontal
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(horizontalMovement * speed * Time.deltaTime);

        // Movimiento vertical
        Vector3 verticalMovement = new Vector3(0f, verticalInput, 0f);
        transform.Translate(verticalMovement * speed * Time.deltaTime);
    }
}
