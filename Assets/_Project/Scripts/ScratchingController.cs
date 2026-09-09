using UnityEngine;
using UnityEngine.InputSystem;

public class ScratchingController : MonoBehaviour
{

    private Texture2D _texture;
    public Texture2D Tex => _texture ??= new Texture2D(1920, 1080);

    [Header("Scrath Radius")]
    [SerializeField] private float _circleScratchRadius;

    [Header("Brush Intensity")]
    [SerializeField] private AnimationCurve _brushIntensity;

    void Awake()
    {
        _texture ??= new Texture2D(1920,1080);
        
        for (int i = 0; i <= _texture.width; i++)
        {
            for (int j = 0; j <= _texture.height; j++)
            {
                _texture.SetPixel(i, j, Color.black);
            }
        }
        _texture.Apply();
    }


    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        for (int i = (int)(mousePosition.x - _circleScratchRadius); i <= (int)(mousePosition.x + _circleScratchRadius); i++)
        {
            for (int j = (int)(mousePosition.y - _circleScratchRadius); j <= (int)(mousePosition.y + _circleScratchRadius); j++)
            {
                float pixelDistance = Vector2.Distance(mousePosition, new Vector2(i, j));
                if (pixelDistance <= _circleScratchRadius)
                {
                    Color pixelColor = _texture.GetPixel(Mathf.Clamp(i, 0, 1920), Mathf.Clamp(j, 0, 1080));
                    float intensity = _brushIntensity.Evaluate(pixelDistance / _circleScratchRadius);
                    _texture.SetPixel(Mathf.Clamp(i, 0, 1920), Mathf.Clamp(j, 0, 1080), pixelColor + new Color(intensity,  intensity, intensity));


                }
            }
        }
        
        _texture.Apply();
    }
}
