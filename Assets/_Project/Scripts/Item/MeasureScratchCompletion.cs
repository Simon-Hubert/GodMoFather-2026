using UnityEngine;

public class MeasureScratchCompletion : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ItemTexture _itemTexture;

    private float _cleanPixelCount;
    private float _dirtyPixelCount;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _itemTexture = GetComponent<ItemTexture>();


        InvokeRepeating(nameof(CalculateCleanPercentage), 0, 1f);
    }

    private void CalculateCleanPercentage()
    {
        _cleanPixelCount = 0;
        _dirtyPixelCount = 0;

        

        for (int i = 0; i <= _itemTexture.Texture.width; i += 1)
        {
            for (int j = 0; j <= _itemTexture.Texture.height; j += 1)
            {

                // C'est ici que ça freeze
                if (_itemTexture.Texture.GetPixel(i, j).r >= .75f)
                {
                    _cleanPixelCount++;
                }
                else
                {
                    _dirtyPixelCount++;
                }
            }
        }


        float averageCleanPixel = _cleanPixelCount / (_cleanPixelCount + _dirtyPixelCount);
        Debug.Log($"Clean Pixel : {_cleanPixelCount} | DirtyPixel : {_dirtyPixelCount} | Average : {Mathf.FloorToInt(averageCleanPixel * 100)}%");
    }
}
