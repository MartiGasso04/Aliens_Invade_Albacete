
using UnityEngine;

public class Hit : MonoBehaviour
{
    public AnimatedSprite animatedSprite;
    public SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        animatedSprite = GetComponent<AnimatedSprite>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayAnimationHit()
    {
        if (animatedSprite != null)
        {
            animatedSprite.enabled = true; 
            spriteRenderer.enabled = true;
        }
    }
}
