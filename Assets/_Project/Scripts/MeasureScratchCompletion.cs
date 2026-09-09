using System.Runtime.CompilerServices;
using UnityEngine;

public class MeasureScratchCompletion : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private ScratchingController _scratchController;

    private int _cleanPixelCount;
    private int _dirtyPixelCount;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _scratchController = GetComponent<ScratchingController>();

        _cleanPixelCount = 0;
        _dirtyPixelCount = 0;

        Vector3 startingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.min);
        Vector3 endingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.max);

        for (int i = Mathf.FloorToInt(startingPoint.x); i <= Mathf.FloorToInt(endingPoint.x); i++)
        {
            for (int j = Mathf.FloorToInt(startingPoint.y); j <= Mathf.FloorToInt(endingPoint.y); j++)
            {
                // C'est ici que ça freeze
                if (_scratchController.Tex.GetPixel(i, j) == Color.white)
                {
                    _cleanPixelCount++;
                    Debug.Log(i + " : " + j + " = " + "Clean");
                }
                else
                {
                    _dirtyPixelCount++;
                    Debug.Log(i + " : " + j + " = " + "Dirty");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

  

        

        //float averageCleanPixel = _cleanPixelCount / (_cleanPixelCount + _dirtyPixelCount);
        //Debug.Log(averageCleanPixel);
    }
}
