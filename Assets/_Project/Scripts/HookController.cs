using System;
using System.Collections;
using SMath;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HookController : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputAction;
    [SerializeField] private float _acceleration, _amorti, _frequence, _speed;

    private SecondOrderDynamics<float> _dynamics;
    private float _input;
    protected float offset;
    private float _target;
    protected float origin;

    public float Target => _target;

    protected abstract float GetOrigin();
    protected abstract void UpdatePos();

    private void Start() {
        _dynamics = new SecondOrderDynamics<float>(_frequence, _amorti, _acceleration, 0f, new Linear1D());
        origin = GetOrigin();
    }

    private void OnEnable() {
        _inputAction.action.performed += Move;
        _inputAction.action.canceled += Move;
    }
    
    private void OnDisable() {
        _inputAction.action.performed -= Move;
        _inputAction.action.canceled -= Move;
    }
    
    private void Move(InputAction.CallbackContext obj) {
        _input = obj.ReadValue<float>();
    }

    private void FixedUpdate() {
        _target += _input * _speed;
        offset = _dynamics.Update(Time.fixedDeltaTime, _target);
        UpdatePos();
    }
}
