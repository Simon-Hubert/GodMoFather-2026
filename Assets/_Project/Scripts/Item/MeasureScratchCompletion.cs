using UnityEngine;

public class MeasureScratchCompletion : MonoBehaviour
{
    private ItemTexture _itemTexture;

    private float _cleanPixelCount;
    private float _dirtyPixelCount;

    private float _scratchCompletion;
    public float ScratchCompletion => _scratchCompletion;

    void Awake()
    {
        _itemTexture = GetComponent<ItemTexture>();


        InvokeRepeating(nameof(CalculateCleanPercentage), 0, 1f);
    }


    public void ResetCompletion()
    {
        _scratchCompletion = 0;
    }

    private void CalculateCleanPercentage()
    {
        if (_scratchCompletion == 1) return;

        _cleanPixelCount = 0;
        _dirtyPixelCount = 0;

        for (int i = 0; i <= _itemTexture.Texture.width; i += 2)
        {
            for (int j = 0; j <= _itemTexture.Texture.height; j += 2)
            {
                Color pixelColor = _itemTexture.Texture.GetPixel(i, j);
                if (pixelColor.r >= .75f)
                {
                    _cleanPixelCount++;
                }
                else
                {
                    _dirtyPixelCount++;
                }
            }
        }

        _scratchCompletion = (_cleanPixelCount / (_cleanPixelCount + _dirtyPixelCount));
    }
}
