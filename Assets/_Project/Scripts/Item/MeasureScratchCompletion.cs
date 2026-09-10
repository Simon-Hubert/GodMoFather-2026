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

        Vector3 startingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.min);
        Vector3 endingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.max);

        for (int i = Mathf.FloorToInt(startingPoint.x); i <= Mathf.FloorToInt(endingPoint.x); i += 2)
        {
            for (int j = Mathf.FloorToInt(startingPoint.y); j <= Mathf.FloorToInt(endingPoint.y); j += 2)
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
        //Debug.Log($"Clean Pixel : {_cleanPixelCount} | DirtyPixel : {_dirtyPixelCount} | Average : {Mathf.FloorToInt(averageCleanPixel * 100)}%");
    }
}
