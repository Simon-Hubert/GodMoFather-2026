using System;
using UnityEngine;

public class Object : MonoBehaviour
{
    private const float LIFETIME = 12f;
    [SerializeField] private int _score;
    [SerializeField] private ItemTexture _itemTexture;
    [SerializeField] private MeasureScratchCompletion _scratchCompletion;
    [SerializeField] private Sprite _sprite;

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
        OnScored?.Invoke(Mathf.FloorToInt(_score * _scratchCompletion.ScratchCompletion));
    }
}
