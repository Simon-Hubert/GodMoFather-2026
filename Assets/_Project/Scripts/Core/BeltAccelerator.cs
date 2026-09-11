using System;
using NaughtyAttributes;
using UnityEngine;

public class BeltAccelerator : MonoBehaviour
{
    [SerializeField, MinMaxSlider(2f, 10f)] private Vector2 _speed;
    [SerializeField, MinMaxSlider(0.7f, 5f)] private Vector2 _interval;
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private ConveyorBelt _belt;
    [SerializeField] private ConveyorUI _ui1;
    [SerializeField] private ConveyorUI _ui2;
    [SerializeField] private ObjectSpawner _spawner;

    private float _counter = 0f;


    private void Update() {
        float p = Mathf.InverseLerp(0, _duration, _counter);
        p = _curve.Evaluate(p);
        float interval = Mathf.Lerp(_interval.x, _interval.y, 1-p);
        p = Mathf.Lerp(_speed.x, _speed.y, p);

        _belt.speed = p;
        _ui1._speed = p;
        _ui2._speed = p;
        _spawner._interval = interval;
        
        _counter += Time.deltaTime;
    }
}
