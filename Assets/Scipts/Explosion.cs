
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AnimatedSprite animatedSprite;

    private void Start()
    {
        animatedSprite = GetComponent<AnimatedSprite>();
    }

    public void Play()
    {
        if (animatedSprite != null)
        {
            animatedSprite.enabled = true; 
            
        }
    }
}
