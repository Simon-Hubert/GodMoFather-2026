using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScratchingController : MonoBehaviour
{
    [Header("Scrath Radius")]
    [SerializeField] private float _circleScratchRadius;

    [Header("Brush Intensity")]
    [SerializeField] private AnimationCurve _brushIntensity;

    [SerializeField] private Transform _hook;

    Vector3 _cursorPosition;

    public static event Action _onExitShape;
    private bool _onShape = false;
    
    void Update()
    {
        _cursorPosition = _hook.position;

        RaycastHit2D hit = Physics2D.Raycast(_cursorPosition, Vector2.down, 0f, LayerMask.GetMask("Item"));
        if (hit.collider != null) {
            IsHovered hovered = hit.transform.GetComponent<IsHovered>();
            if (hovered && !_onShape) {
                _onShape = true;
                hovered.OnEnterShape();
            }
            //Calcul de la pixel position
            ItemTexture itemTex = hit.transform.gameObject.GetComponent<ItemTexture>();
            Vector2 collidePosition = hit.point - (Vector2)itemTex.SpriteRender.bounds.min;
            float sizeX = itemTex.SpriteRender.bounds.max.x - itemTex.SpriteRender.bounds.min.x;
            float sizeY = itemTex.SpriteRender.bounds.max.y - itemTex.SpriteRender.bounds.min.y;
            Vector2 percentagePosition = new Vector2(collidePosition.x / sizeX, collidePosition.y / sizeY);
            Vector2 pixelPosition = percentagePosition * new Vector2(itemTex.Texture.width, itemTex.Texture.height);

            for (int i = (int)(pixelPosition.x - _circleScratchRadius); i <= pixelPosition.x + _circleScratchRadius; i++)
            {
                for (int j = (int)(pixelPosition.y - _circleScratchRadius); j <= pixelPosition.y + _circleScratchRadius; j++)
                {
                    float pixelDistance = Vector2.Distance(pixelPosition, new Vector2(i, j));
                    if (pixelDistance <= _circleScratchRadius)
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
        else {
            if (_onShape) {
                _onShape = false;
                _onExitShape?.Invoke();
            }
        }
        
    }

}
