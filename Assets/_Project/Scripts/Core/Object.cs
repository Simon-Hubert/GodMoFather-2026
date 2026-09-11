using System;
using UnityEngine;

public struct ScoreEvent
{
    public int score;
    public int threshold;
}

public class Object : MonoBehaviour
{
    private const float LIFETIME = 12f;
    [SerializeField] private int _score;
    [SerializeField] private ItemTexture _itemTexture;
    [SerializeField] private MeasureScratchCompletion _scratchCompletion;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private float _scaledPercentage;

    public static event Action<ScoreEvent> OnScored;

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
            OnScored?.Invoke(new ScoreEvent{score = Mathf.FloorToInt(_score * 0), threshold = 0});
        }
        else if (_scratchCompletion.ScratchCompletion < Mathf.Lerp(0, _scaledPercentage, 0.75f))
        {
            OnScored?.Invoke(new ScoreEvent{score = Mathf.FloorToInt(_score * .5f), threshold = 1});
        }
        else if (_scratchCompletion.ScratchCompletion >= Mathf.Lerp(0, _scaledPercentage, 0.75f))
        {
            OnScored?.Invoke(new ScoreEvent{score = Mathf.FloorToInt(_score), threshold = 2});
        }
    }
}
