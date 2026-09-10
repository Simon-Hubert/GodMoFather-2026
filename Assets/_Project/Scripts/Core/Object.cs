using System;
using UnityEngine;

public class Object : MonoBehaviour
{
    private const float LIFETIME = 12f;
    [SerializeField] private int _score;

    public static event Action<int> OnScored;

    private void Start() {
        _ = Lifetime();
    }

    private async Awaitable Lifetime() {
        await Awaitable.WaitForSecondsAsync(LIFETIME);
        WhenDestroyed();
        await Awaitable.EndOfFrameAsync();
        Destroy(gameObject);
    }
    
    private void WhenDestroyed() {
        OnScored?.Invoke(_score);
    }
}
