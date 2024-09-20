using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (sprites.Length > 0)
        {
            
            spriteRenderer.sprite = sprites[currentIndex];
        }
        else
        {
            Debug.LogError("No se han asignado sprites al array.");
        }
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeToNextSprite();
        }
    }

    void ChangeToNextSprite()
    {
        
        currentIndex++;

        
        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0;
        }

        
        spriteRenderer.sprite = sprites[currentIndex];
    }
}