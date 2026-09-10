using UnityEngine;
using UnityEngine.InputSystem;

public class ScratchingController : MonoBehaviour
{
    [Header("Scrath Radius")]
    [SerializeField] private float _circleScratchRadius;

    [Header("Brush Intensity")]
    [SerializeField] private AnimationCurve _brushIntensity;


    // TEMP
    Vector3 _cursorPosition;


    void Update()
    {
        // TEMP
        _cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(_cursorPosition, Vector2.down, 0f, LayerMask.GetMask("Item"));
        if (hit.collider != null)
        {
            //Calcul de la pixel position
            ItemTexture itemTex = hit.transform.gameObject.GetComponent<ItemTexture>();
            Vector2 collidePosition = hit.transform.worldToLocalMatrix.MultiplyVector(hit.point) * hit.transform.localScale.x - itemTex.SpriteRender.bounds.min;
            Vector2 percentagePosition = collidePosition / hit.transform.localScale.x;

            Vector2 pixelPosition = percentagePosition * new Vector2(itemTex.Texture.width, itemTex.Texture.height);

            for (int i = (int)(pixelPosition.x - _circleScratchRadius); i <= pixelPosition.x + _circleScratchRadius; i++)
            {
                for (int j = (int)(pixelPosition.y - _circleScratchRadius); j <= pixelPosition.y + _circleScratchRadius; j++)
                {
                    float pixelDistance = Vector2.Distance(pixelPosition, new Vector2(i, j));
                    if (pixelDistance <= _circleScratchRadius )
                    {
                        Color pixelColor = itemTex.Texture.GetPixel(i, j);
                        float intensity = _brushIntensity.Evaluate(pixelDistance / _circleScratchRadius);

                        Color newColor = pixelColor + new Color(intensity, intensity, intensity);
                        itemTex.Texture.SetPixel(i, j, newColor);
                    }
                }
            }
            itemTex.Texture.Apply();

        }
        
    }

}
