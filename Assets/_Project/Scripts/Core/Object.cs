using System;
using UnityEngine;

public class Object : MonoBehaviour
{
    private const float LIFETIME = 12f;
    [SerializeField] private int _score;
    [SerializeField] private ItemTexture _itemTexture;
    [SerializeField] private MeasureScratchCompletion _scratchCompletion;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private float _scaledPercentage;

    public static event Action<int> OnScored;

    private void Start() {
        _itemTexture.SetSprite(_sprite);
        _ = Lifetime();
    }

    private async Awaitable Lifetime() {
        await Awaitable.WaitForSecondsAsync(LIFETIME);
        WhenDestroyed();
        await Awaitable.EndOfFrameAsync();
        Destroy(gameObject);
    }
    
    private void WhenDestroyed() {
        
        if (_scratchCompletion.ScratchCompletion == 0)
        {
            OnScored?.Invoke(Mathf.FloorToInt(_score * 0));
        }
        else if (_scratchCompletion.ScratchCompletion < Mathf.Lerp(0, _scaledPercentage, 0.75f))
        {
            OnScored?.Invoke(Mathf.FloorToInt(_score * .5f));
        }
        else if (_scratchCompletion.ScratchCompletion >= Mathf.Lerp(0, _scaledPercentage, 0.75f))
        {
            OnScored?.Invoke(Mathf.FloorToInt(_score));
        }
    }
}
