using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int _minutes;
    public int Minutes => _minutes;
    private float _seconds;
    public float Seconds
    {
        get {  return Mathf.RoundToInt(_seconds * 100) / 100; }
    }

    [SerializeField] private int _countDownMinutes;
    [SerializeField] private float _countDownSeconds;

    public event Action OnCountDownOver;

    private void Start()
    {
        _minutes = _countDownMinutes;
        _seconds = _countDownSeconds;
    }

    private void Update()
    {
        if (_seconds <= 0)
        {
            if (_minutes > 0)
            {
                _minutes--;
                _seconds += 60;
            }
            else
            {
                OnCountDownOver?.Invoke();
            }
        }

        _seconds -= Time.deltaTime;
        
    }
}
